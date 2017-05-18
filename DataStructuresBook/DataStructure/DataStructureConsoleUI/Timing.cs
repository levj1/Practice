using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace DataStructureConsoleUI
{
    public class Timing
    {
        TimeSpan startingTime;
        TimeSpan duration;
        public Timing()
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }

        public void StopTime()
        {
            duration =
            Process.GetCurrentProcess().Threads[0].
            UserProcessorTime.
            Subtract(startingTime);
        }

        public void startTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime = Process.GetCurrentProcess().Threads[0].
                    UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }

        public virtual void ImportJHXMLImages()
        {
            string FileName = "";
            int FileID = 0;
            string FileText = "";
            string AccountNumber = "";
            decimal CheckAmount = 0;
            string CheckNumber = "";
            string RoutingNumber = "";
            string ImageNumber = "";
            DateTime ProcessingDate = DateTime.Now;
            SqlConnection conn = GetPrimaryConnection();
            using (SqlCommand cmd = new SqlCommand())
            using (DataTable BankFiles = new DataTable())
            {
                cmd.CommandTimeout = 1200;
                cmd.Connection = conn;
                try
                {
                    int RemainingImagesFiles = 0;
                    cmd.CommandText = string.Format("select count(*) from fcbinterface..bankfile where dteparsedate is null and numifacetypeid = {0} and txtfilename like '%xml%'", _IFaceTypeID);
                    RemainingImagesFiles = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    for (int i = 0; i < 50 && RemainingImagesFiles > 0; i++)
                    {
                        cmd.CommandText = string.Format("select top 1 numfileid, txtfilename, txtfile, dtefiledate from fcbinterface..bankfile where dteparsedate is null and numifacetypeid = {0} and txtfilename like '%xml%' order by numfileid", _IFaceTypeID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(BankFiles);
                        }
                        foreach (DataRow bankFile in BankFiles.Rows)
                        {
                            FileID = Convert.ToInt32(bankFile["numfileid"].ToString());
                            FileName = bankFile["txtfilename"].ToString();
                            FileText = bankFile["txtfile"].ToString();

                            XmlDataDocument xmlDoc = new XmlDataDocument();
                            using (MemoryStream ms = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(FileText)))
                            using (DataSet dsXml = new DataSet())
                            {
                                dsXml.ReadXml(ms);
                                if (dsXml.Tables.IndexOf("FrontImage") == -1)
                                {
                                    cmd.CommandText = string.Format("update fcbinterface..bankfile set dteparsedate = getdate() where numfileid = {0}", FileID);
                                    cmd.ExecuteNonQuery();
                                    continue;
                                }
                                if (dsXml.Tables.IndexOf("JHA4Sight") == -1)
                                {
                                    cmd.CommandText = string.Format("update fcbinterface..bankfile set dteparsedate = getdate() where numfileid = {0}", FileID);
                                    cmd.ExecuteNonQuery();
                                    continue;
                                }
                                if (dsXml.Tables.IndexOf("Item") == -1)
                                {
                                    cmd.CommandText = string.Format("update fcbinterface..bankfile set dteparsedate = getdate() where numfileid = {0}", FileID);
                                    cmd.ExecuteNonQuery();
                                    continue;
                                }
                                if (dsXml.Tables.IndexOf("BackImage") == -1)
                                {
                                    cmd.CommandText = string.Format("update fcbinterface..bankfile set dteparsedate = getdate() where numfileid = {0}", FileID);
                                    cmd.ExecuteNonQuery();
                                    continue;
                                }
                                foreach (DataRow image in dsXml.Tables["FrontImage"].Rows)
                                {
                                    DataRow[] aJHA = dsXml.Tables["JHA4Sight"].Select("FrontImage_ID = " + image["FrontImage_ID"].ToString());
                                    if (aJHA.Length == 1)
                                    {
                                        DataRow jha = aJHA[0];
                                        DataRow[] aItem = dsXml.Tables["Item"].Select("JHA4Sight_ID = " + jha["JHA4Sight_ID"].ToString());
                                        if (aItem.Length == 1)
                                        {
                                            DataRow item = aItem[0];
                                            //process details about check
                                            ImageNumber = "";
                                            AccountNumber = "";
                                            CheckAmount = 0;
                                            CheckNumber = "";
                                            RoutingNumber = "";
                                            ProcessingDate = DateTime.Now;
                                            for (int k = 0; k < dsXml.Tables["Item"].Columns.Count; k++)
                                            {
                                                DataColumn col = dsXml.Tables["Item"].Columns[k];
                                                switch (col.ColumnName.ToLower())
                                                {
                                                    case "hostimagenumber":
                                                        if (!item.IsNull(k))
                                                            ImageNumber = item[k].ToString();
                                                        break;
                                                    case "account":
                                                        if (!item.IsNull(k))
                                                            AccountNumber = item[k].ToString();
                                                        break;
                                                    case "amount":
                                                        if (!item.IsNull(k))
                                                            CheckAmount = Convert.ToDecimal(item[k]) / 100;
                                                        break;
                                                    case "serial":
                                                        if (!item.IsNull(k))
                                                            CheckNumber = item[k].ToString();
                                                        break;
                                                    case "tranrouting":
                                                        if (!item.IsNull(k))
                                                            RoutingNumber = item[k].ToString();
                                                        break;
                                                    case "processingdate":
                                                        if (!item.IsNull(k))
                                                        {
                                                            if (!string.IsNullOrEmpty(item[k].ToString()) && item[k].ToString().Length == 8)
                                                                ProcessingDate = Convert.ToDateTime(item[k].ToString().Substring(4, 2) + "/" + item[k].ToString().Substring(6, 2) + "/" + item[k].ToString().Substring(0, 4));
                                                        }
                                                        break;
                                                }
                                            }
                                            cmd.CommandText = string.Format("select count(*) from fcbinterface..bankimage where txtimagenumber = '{0}' and numbackflag = 0", sqlStr(ImageNumber));
                                            if (0 == Convert.ToInt32(cmd.ExecuteScalar()))
                                            {
                                                //insert front of check
                                                byte[] FrontImage = Convert.FromBase64String(jha["ImageData"].ToString());
                                                cmd.CommandText = string.Format("insert into fcbinterface..bankimage (numfileid,mnyamount,txtaccount,txtrouting,txtchecknumber,txtimagenumber,numbackflag,numsize,dteprocessingdate,numifacetypeid,imgimage) " +
                                                    "values ({0},{1},'{2}','{3}','{4}','{5}',0,{6},'{7:d}',{8},@Data)", FileID, CheckAmount, sqlStr(AccountNumber), sqlStr(RoutingNumber), sqlStr(CheckNumber), sqlStr(ImageNumber), FrontImage.Length, ProcessingDate, _IFaceTypeID);
                                                SqlParameter param = new SqlParameter("@Data", SqlDbType.VarBinary, FrontImage.Length, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Current, FrontImage);
                                                cmd.Parameters.Add(param);
                                                cmd.ExecuteNonQuery();
                                                cmd.Parameters.Clear();
                                                param = null;
                                            }
                                        }
                                    }
                                }

                                foreach (DataRow image in dsXml.Tables["BackImage"].Rows)
                                {
                                    DataRow[] aJHA = dsXml.Tables["JHA4Sight"].Select("BackImage_ID = " + image["BackImage_ID"].ToString());
                                    if (aJHA.Length == 1)
                                    {
                                        DataRow jha = aJHA[0];
                                        DataRow[] aItem = dsXml.Tables["Item"].Select("JHA4Sight_ID = " + jha["JHA4Sight_ID"].ToString());
                                        if (aItem.Length == 1)
                                        {
                                            DataRow item = aItem[0];
                                            //process details about check
                                            ImageNumber = "";
                                            AccountNumber = "";
                                            CheckAmount = 0;
                                            CheckNumber = "";
                                            RoutingNumber = "";
                                            for (int k = 0; k < dsXml.Tables["Item"].Columns.Count; k++)
                                            {
                                                DataColumn col = dsXml.Tables["Item"].Columns[k];
                                                switch (col.ColumnName.ToLower())
                                                {
                                                    case "hostimagenumber":
                                                        if (!item.IsNull(k))
                                                            ImageNumber = item[k].ToString();
                                                        break;
                                                    case "account":
                                                        if (!item.IsNull(k))
                                                            AccountNumber = item[k].ToString();
                                                        break;
                                                    case "amount":
                                                        if (!item.IsNull(k))
                                                            CheckAmount = Convert.ToDecimal(item[k]) / 100;
                                                        break;
                                                    case "serial":
                                                        if (!item.IsNull(k))
                                                            CheckNumber = item[k].ToString();
                                                        break;
                                                    case "tranrouting":
                                                        if (!item.IsNull(k))
                                                            RoutingNumber = item[k].ToString();
                                                        break;
                                                }
                                            }
                                            cmd.CommandText = string.Format("select count(*) from fcbinterface..bankimage where txtimagenumber = '{0}' and numbackflag = 1", sqlStr(ImageNumber));
                                            if (0 == Convert.ToInt32(cmd.ExecuteScalar()))
                                            {
                                                //insert back of check
                                                byte[] BackImage = Convert.FromBase64String(jha["ImageData"].ToString());
                                                cmd.CommandText = string.Format("insert into fcbinterface..bankimage (numfileid,mnyamount,txtaccount,txtrouting,txtchecknumber,txtimagenumber,numbackflag,numsize,dteprocessingdate,numifacetypeid,imgimage) " +
                                                    "values ({0},{1},'{2}','{3}','{4}','{5}',1,{6},'{7:d}',{8},@Data)", FileID, CheckAmount, sqlStr(AccountNumber), sqlStr(RoutingNumber), sqlStr(CheckNumber), sqlStr(ImageNumber), BackImage.Length, ProcessingDate, _IFaceTypeID);
                                                SqlParameter param = new SqlParameter("@Data", SqlDbType.VarBinary, BackImage.Length, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Current, BackImage);
                                                cmd.Parameters.Add(param);
                                                cmd.ExecuteNonQuery();
                                                cmd.Parameters.Clear();
                                                param = null;
                                            }
                                        }
                                    }
                                }
                            }
                            cmd.CommandText = string.Format("update fcbinterface..bankfile set dteparsedate = getdate() where numfileid = {0}", FileID);
                            cmd.ExecuteNonQuery();
                        }
                        BankFiles.Clear();
                        cmd.CommandText = string.Format("select count(*) from fcbinterface..bankfile where dteparsedate is null and numifacetypeid = {0} and txtfilename like '%xml%'", _IFaceTypeID);
                        RemainingImagesFiles = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    }
                }
                catch (Exception ex)
                {
                    _Log.LogErr("ProcessBankFiles", "ImportJHXMLImages", string.Format("ERR:{0} SQL:{1}", ex.Message, cmd.CommandText));
                    if (FileID != 0)
                    {
                        cmd.CommandText = string.Format("update fcbinterface..bankfile set dteparsedate = getdate() where numfileid = {0}", FileID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }


}
