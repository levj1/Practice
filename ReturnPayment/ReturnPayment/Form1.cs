using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ReturnPayment
{
    public partial class Form1 : Form
    {
        private List<SqlConnection> _Connections = new List<SqlConnection>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BankReturnEchecAch();
        }

        private void BankReturnEchecAch()
        {
            string sServer = "cincdb2";
            string sDatabase = string.Empty;
            string emailBody = "";
            string emailSubject = "";

            int customerId = 0;

            SetupConnections();

            //SqlConnection primaryConn = GetPrimaryConnection();

            using (SqlCommand cmd = new SqlCommand())
                // loop through database servers
                foreach (SqlConnection ServerConnection in GetConnections())
                {
                    using (DataSet dsCustomer = new DataSet())
                    {
                        // Create logging class
                        //CApplicationLog log = new CApplicationLog("BankReturnEchecAch", "BankReturnEchecAch", primaryConn);
                        try
                        {
                            cmd.CommandTimeout = 1200;
                            cmd.Connection = ServerConnection;
                            cmd.CommandText = string.Format("select txtname,txtdatabase, numCustomerID from cinccustomer..customer where dtedeleted is null and numLive = 1 and txtdatabase not like '%test%' and txtdatabase not like '%cma%' and txtdatabase not like '%matt%' order by numcustomerid");
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dsCustomer, "Customer");
                            }
                            foreach (DataRow customer in dsCustomer.Tables["Customer"].Rows)
                            {
                                //log.m_database = customer["txtdatabase"].ToString();
                                sDatabase = customer["txtdatabase"].ToString();
                                cmd.CommandText = string.Format("use [{0}]", customer["txtdatabase"]);
                                cmd.ExecuteNonQuery();
                                emailBody = "";
                                cmd.CommandText = "select * from bankreturn  where txtReturncode IN ('R02', 'R03', 'R04', 'R05', 'R07', 'R010') AND txtRefType IN ('ach', 'echeck')";

                                using (DataSet dsBankReturn = new DataSet())
                                {
                                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                    {
                                        da.Fill(dsBankReturn, "BankReturn");
                                    }

                                    foreach (DataRow bkReturn in dsBankReturn.Tables["BankReturn"].Rows)
                                    {
                                        cmd.CommandText = string.Format("select * from bankreturn where numreturnid = {0}", bkReturn["numreturnid"].ToString());
                                        MessageBox.Show(cmd.CommandText);
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("Form1 Form1_Load", ex.Message + " SQL:" + cmd.CommandText));
                            // log.LogErr("Form1", "Form1_Load", ex.Message + " SQL:" + cmd.CommandText);
                        }
                    }
                }

        }


        public SqlConnection[] GetConnections()
        {
            try
            {
                return _Connections.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("FormMain GetConnections", string.Format("ERR:{0}", ex.Message));
            }
            return null;
        }

        private void SetupConnections()
        {
            string PrimaryServer = "cincdb2";
            List<string> Servers = new List<string>();
            using (SqlConnection conn = new SqlConnection(string.Format("server={0};database=fcbinterface;uid=CincUser;pwd=0tat0pay$A", PrimaryServer)))
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandTimeout = 1200;
                    cmd.Connection = conn;
                    cmd.CommandText = "select distinct txtserver from cinccustomer..customerfull where dtedeleted is null and numlive = 1 order by txtserver";
                    using (SqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                            Servers.Add(Reader["txtserver"].ToString());
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("FormMain SetupConnections", string.Format("ERR:{0} SQL:{1}", ex.Message, cmd.CommandText)));
                }
            }
        }

    }
}
