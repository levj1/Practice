using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CreateUser
{
    public partial class Form1 : Form
    {
        string cs = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=test;Data Source=WIN-S09H3MHKTQT\\SQLEXPRESS";
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string confirm = txtConfirm.Text;

            // Check that all field are entered
            if(string.IsNullOrWhiteSpace(user) ||
                string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Please fill out all fields");
            }
            else if(pass != confirm)
            {
                MessageBox.Show("password and confirm password must match.");                        
            }                    
            else
            {
                CheckUserExistence(user, pass);
            }
        }

        // Check if user exist
        private void CheckUserExistence(string user, string pass)
        {
            SqlDataReader reader = null;
            
            try
            {
                // Create database connection                
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = cs;
                    conn.Open();
                    SqlCommand command = new SqlCommand();

                    command.CommandText = "CheckUserExistence";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@username", user));
                    command.Parameters.Add(new SqlParameter("@password", pass));
                    command.Connection = conn;

                    //execute the reader
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if(reader[0].ToString() == "true")
                        {
                            MessageBox.Show("Username/passowrd already exists, please choose another username");
                            break;
                        }
                        else
                        {
                            CreateNewUser(user, pass);
                        }                      

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateNewUser(string user, string pass)
        {
            SqlDataReader reader = null;

            try
            {
                // Create database connection                
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = cs;
                    conn.Open();
                    SqlCommand command = new SqlCommand();

                    command.CommandText = "CreateUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@username", user));
                    command.Parameters.Add(new SqlParameter("@password", pass));
                    command.Connection = conn;

                    //execute the reader
                    reader = command.ExecuteReader();
                    MessageBox.Show("User/password has been created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
