using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsvAchInfo
{
    public struct csvInformation
    {
        public string sCompanyID;
        public string sCompanyEntryDescr;
        public string sRoutingNo;
        public string sAccountNo;
        public decimal dAmount;
        public string sIndividualID;
        public string sIndividualName;
        public string sReturnCode;
        public string sTraceNum;
        public string sReturnReason;
        public string sAltReturnReason;

        public csvInformation(string companyID, string companyEntryDescr, string routing, string accountNo, decimal amount, string individualID, string individualName, string returnCode, string traceNum, string returnReason, string altReturnReason)
        {
            sCompanyID = companyID;
            sCompanyEntryDescr = companyEntryDescr;
            sRoutingNo = routing;
            sAccountNo = accountNo;
            dAmount = amount;
            sIndividualID = individualID;
            sIndividualName = individualName;
            sReturnCode = returnCode;
            sTraceNum = traceNum;
            sReturnReason = returnReason;
            sAltReturnReason = altReturnReason;
        }
    };

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ParseReturnCSVACHInfo();
        }

        private void ParseReturnCSVACHInfo()
        {


            ArrayList csvInfo = new ArrayList();
            string companyID, companyEntryDescr, routing, account, parsedAmount;
            decimal amount;
            string individualID, individualName, returnCode, traceNum, altReturnReason, returnReason, line;

            string tempPath = @"C:\TestFiles";
            foreach (string fileName in Directory.GetFiles(tempPath, "*.csv"))
            {
                using (StreamReader rdr = new StreamReader(fileName))
                {
                    companyID = "";
                    companyEntryDescr = "";
                    routing = "";
                    account = "";
                    parsedAmount = "";
                    amount = -9999;
                    individualID = "";
                    individualName = "";
                    returnCode = "";
                    traceNum = "";
                    altReturnReason = "";
                    returnReason = "";
                    int i = 0;
                    string[] returnCSV;

                    while ((line = rdr.ReadLine()) != null)
                    {
                        returnCSV = line.Split(',');

                        // Process only if the file is CINFO
                        if (i == 0 && returnCSV[0].ToString() != "AC5COM")
                        {
                            break;
                        }

                        if (i == 0)
                        {
                            i++;
                            continue;
                        }

                        companyID = returnCSV[1];
                        companyEntryDescr = returnCSV[0];

                        routing = returnCSV[11];
                        account = returnCSV[3].TrimStart('0').TrimEnd(' ');
                        parsedAmount = returnCSV[7];//line.Substring(92, 10) + "." + line.Substring(37, 2); //Parse the amount and add the decimal place
                        amount = Convert.ToDecimal(parsedAmount);
                        individualID = returnCSV[4].TrimEnd(' ').TrimStart(' ');
                        individualName = returnCSV[2].TrimEnd(' ').TrimStart(' ');

                        returnCode = returnCSV[9];
                        traceNum = returnCSV[10];
                        altReturnReason = returnCSV[12].TrimEnd(' ').TrimStart(' ');

                        string cs = "server=cincdb3;database=CincCustomer;uid=CincUser;pwd=0tat0pay$A";
                        using (SqlConnection conn = new SqlConnection(cs))
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            conn.Open();
                            try
                            {
                                cmd.CommandTimeout = 1200;
                                cmd.Connection = conn;
                                //check the bankreturncode table for a return reason based on the return code that we parsed.
                                cmd.CommandText = string.Format("select isnull(txtreturnreason,'') as [txtreturnreason] from fcbinterface..bankreturncode where txtreturncode = '{0}'", returnCode);
                                using (SqlDataReader sqlrdr = cmd.ExecuteReader())
                                {
                                    if (sqlrdr.Read())
                                        returnReason = sqlrdr["txtreturnreason"].ToString();
                                    else
                                        returnReason = altReturnReason;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Form1", "ParseTheACHInfo" + ex.Message + " SQL: " + cmd.CommandText);
                                MessageBox.Show("BankReturnParser: ParseTheACHInfo" + ex.Message + " SQL: " + cmd.CommandText);
                            }
                        }
                        //Add the current CSV Information and reset the values.
                        csvInfo.Add(new csvInformation(companyID, companyEntryDescr, routing, account, amount, individualID, individualName, returnCode, traceNum, returnReason, altReturnReason));
                        companyID = "";
                        companyEntryDescr = "";
                        routing = "";
                        account = "";
                        parsedAmount = "";
                        amount = -9999;
                        individualID = "";
                        individualName = "";
                        returnCode = "";
                        traceNum = "";
                        altReturnReason = "";
                        returnReason = "";

                    }
                }

            }
        }
    }
}
