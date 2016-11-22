using System;
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

namespace SQLDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\James Leveille\Desktop\Temp\test.txt";
            string ConnStr = string.Format("");

            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "Select top 10 * from association";
                cmd.ExecuteNonQuery();

                string result = "Id - Name - Address1 - Contact";
                result += Environment.NewLine;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result += reader[0].ToString() + " - " + reader[1].ToString() + " - " + reader[2].ToString() + " - " + reader[3].ToString();
                        result += Environment.NewLine;
                    }

                }
                WriteToFile(path, result);
            }
        }

        private void WriteToFile(string location, string text)
        {
            if (!File.Exists(location))
            {
                File.Create(location);
            }
            try
            {
                File.WriteAllText(location, text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
