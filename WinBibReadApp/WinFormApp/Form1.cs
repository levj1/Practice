using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibRead.BL;

namespace WinFormApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
           
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string pass = txtPassword.Text;

            Login login = new Login(username, pass);
            bool correctCreden = login.CanLogIn();
            if (correctCreden)
            {
                lblResponse.Text = "Login Successfull";
            }
            else
            {
                lblResponse.Text = "Login unsuccessful";
            }
        }
    }
}
