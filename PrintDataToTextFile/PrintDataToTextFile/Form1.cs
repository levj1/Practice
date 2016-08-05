using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrintDataToTextFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cs = "Server=cincdb2; Database=matt; User ID = james; Password = J@mes017";

           

                try
                {
                    using (SqlConnection conn = new SqlConnection(cs))
                    {
                        conn.Open();
                        // Create sql query 
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "SELECT * FROM james_ussers";
                        cmd.Connection = conn;

                        // Execute query 
                        cmd.ExecuteNonQuery();

                        // Create datareader 
                        SqlDataReader reader = cmd.ExecuteReader();
                        label1.Text += "";

                        while (reader.Read())
                        {
                            label1.Text += reader[1].ToString() + " " + reader[2].ToString() + "\t\n";
                        }
                    }
                }
                catch (Exception)
                {
                label1.Text = "Error happenned"; 
                }
            
        }
    }
}
