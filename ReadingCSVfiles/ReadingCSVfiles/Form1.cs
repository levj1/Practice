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

            //string returnpathTest = @"C:\Users\James Leveille\Desktop\CitywideReturns";
            //string csvPath = returnpathTest + "\\2016 0804 RetChk sample.csv";

            //foreach (string fileName in Directory.GetFiles(returnpathTest, "*.csv"))
            //{
            //    MessageBox.Show(fileName);
            //}
        }

        private void ParseReturnCSVCheckInfo()
        {
            string returnpathTest = @"C:\Users\James Leveille\Desktop\CitywideReturns";
            string csvPath = returnpathTest + "\\2016 0804 RetChk sample.csv";

            foreach (string fileName in Directory.GetFiles(returnpathTest, "*.csv")) 
            {

                using (SqlConnection conn = new SqlConnection())
                using (SqlCommand cmd = new SqlCommand())
                {
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

                            // The fields 
                            // CIFNO	CFNA1	STATUS	EHTDATE6	EHACCTN	EHACTYP	EHSEQNO	EHAMT	EHRCODE	ERDESC	EHDESC	EHCHKNO	EHIMAGE#	EHPAYOR
                            
                            string csvMoneyAmount = Fields[7];
                            decimal amount = Convert.ToDecimal(csvMoneyAmount);
                            string csvReturnCode = Fields[8];
                            string csvReason = Fields[9];
                            string csvDescription = Fields[10];
                            string csvCheckNo = Fields[11];
                            string csvFileName = Fields[12] + ".tif";

                            if (!string.IsNullOrEmpty(csvDescription))
                            {
                                csvReason = csvReason + "-" + csvDescription;
                            }

                            try
                            {
                                BinaryReader br = new BinaryReader(File.Open(returnpathTest + @"\" + csvFileName, FileMode.Open));

                                byte[] fileContents = new byte[br.BaseStream.Length];
                                br.Read(fileContents, 0, (int)br.BaseStream.Length);
                                br.Close();
                                cmd.CommandTimeout = 1200;
                                cmd.Connection = conn;
                                SqlParameter param = null;

                                cmd.CommandText = string.Format("insert into TableName (colName1, colName2, colName3) values('{0}',@Data, '{1}')",
                                    csvFileName, csvCheckNo, amount, csvReason);
                                param = new SqlParameter("@Data", SqlDbType.VarBinary, fileContents.Length, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Current, fileContents);
                                MessageBox.Show(cmd.CommandText); 
                                cmd.Parameters.Add(param);
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
