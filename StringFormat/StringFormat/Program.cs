using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static string connectionString = @"Data Source=T1000\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";

        //T1000\SQLEXPRESS(T1000\JamesLeveille)
        static void Main(string[] args)
        {
            SqlScalar();

            Console.ReadLine();
        }

        private static void SqlScalar()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select id from contact where firstname = 'james'";
                    Console.WriteLine(Convert.ToInt32(cmd.ExecuteScalar()));

                }
            }
        }

        private static void SqlInsertStatement()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "Insert into contact (firstname,lastname,email,AddressLine1,AddressLine2,City,state,zipcode) " +
                                          "Values('Jean', 'Dulv', 'duls@aol.com', '456 54 street', 'apt 3', 'Loganville', 'Md', '30089') ";
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

            }
        }

        private static void SqlConnDataTable()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (DataTable contacts = new DataTable())
                {
                    SqlCommand cmd = new SqlCommand("select * from contact", conn);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(contacts);
                    }
                    foreach (DataRow contact in contacts.Rows)
                    {
                        Console.WriteLine(contact["firstname"].ToString() + contact["lastname"].ToString());
                    }
                }

            }
        }

        private static void SqlConnDataReader()
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from contact", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " - " + reader[1].ToString());
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}

//firstname,lastname,email,AddressLine1,AddressLine2,City,state,zipcode
