using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Data.SqlClient;
using System.Data;

namespace ReadingCSVfiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ParseReturnCSVCheckInfo();
        }

        private void ParseReturnCSVCheckInfo()
        {
            int ifacetypeid = 66;

            string returnImagePath = @"C:\Users\James Leveille\Desktop\CitywideReturns\";

            foreach (string fileName in Directory.GetFiles(returnImagePath, "*.csv")) 
            {
                string cs = "Server ={cincdb3}; Database ={ 1}; UID = CincUser; PWD = 0tat0pay$A";
                using (SqlConnection conn = new SqlConnection(cs))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandTimeout = 1200;
                    cmd.Connection = conn;

                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        for (int i = 0; !reader.EndOfStream; i++)
                        {
                            string Line = reader.ReadLine();
                            string[] Fields = ParseFields(Line);

                            // Process only if the file is CINFO
                            if (i == 0 && Fields[0].ToString() != "CIFNO")
                            {
                                break;
                            }

                            if (i == 0)
                                continue;

                            // The fields in csv file
                            // CIFNO	CFNA1	STATUS	EHTDATE6	EHACCTN	EHACTYP	EHSEQNO	EHAMT	EHRCODE	ERDESC	EHDESC	EHCHKNO	EHIMAGE#	EHPAYOR

                            string csvMoneyAmount = Fields[7];
                            decimal amount = Convert.ToDecimal(csvMoneyAmount);
                            string csvReturnCode = Fields[8];
                            string csvReason = Fields[9];
                            string csvDescription = Fields[10];
                            string csvCheckNo = Fields[11];
                            string csvFileName = Fields[12] + ".tif";
                            string txtBank = "CWB";
                            


                            FileInfo fi = new FileInfo(fileName);
                            string dteFileDate = (fi.CreationTime).ToString(@"MM\/dd\/yyyy HH:mm:ss");

                            if (!string.IsNullOrEmpty(csvDescription))
                            {
                                csvReason = csvReason + "-" + csvDescription;
                            }

                            try
                            {
                                BinaryReader br = new BinaryReader(File.Open(returnImagePath + @"\" + csvFileName, FileMode.Open));

                                byte[] fileContents = new byte[br.BaseStream.Length];
                                br.Read(fileContents, 0, (int)br.BaseStream.Length);
                                br.Close();
                                SqlParameter param = null;
                                

                                cmd.CommandText = string.Format("insert into fcbinterface..returnimage (txtIPAddress,imgImage, txtFileName,txtCheckNo,mnyAmount,txtReason,txtCode,txtBank,dteFileDate) values('1.1.1.1',@Data, '{0}','{1}',{2}, '{3}', '{4}', '{5}',{6})",
                                sqlStr(csvFileName), sqlStr(csvCheckNo), amount, sqlStr(csvReason), sqlStr(csvReturnCode), sqlStr(txtBank), dteFileDate);
                                param = new SqlParameter("@Data", SqlDbType.VarBinary, fileContents.Length, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Current, fileContents);
                                cmd.Parameters.Add(param);
                                MessageBox.Show(cmd.CommandText);
                                //cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                                param = null;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(string.Format("Form1", "ParseReturnCSVCheckInfo", ex.Message + " SQL: " + cmd.CommandText));
                                MessageBox.Show(string.Format("ParseReturnCSVCheckInfo:" + ex.Message + " SQL: " + cmd.CommandText, true));
                                throw;
                            }
                        }
                    }
                }
            
            }
        }

        private object sqlStr(string phrase)
        {
            phrase = phrase.Replace("\"", string.Empty);
            phrase = phrase.Replace("'", string.Empty);

            return phrase;
        }

        public string[] ParseFields(string sBuf)
        {
            try
            {
                string sReturn = "";
                bool bInStr = false;
                for (int i = 0; i < sBuf.Length; i++)
                {
                    if (!bInStr)
                    {
                        if (sBuf[i] == ',')
                            sReturn += '\v';
                        else if (sBuf[i] == '\"')
                            bInStr = true;
                        else
                            sReturn += sBuf[i];
                    }
                    else
                    {
                        if (sBuf[i] == '\"')
                            bInStr = false;
                        else
                            sReturn += sBuf[i];
                    }
                }
                return sReturn.Split('\v');
            }
            catch { }
            return null;
        }
    }
}
