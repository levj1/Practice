using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibRead.BL
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Login()
        {

        }

        public Login(string usern, string pass)
        {
            UserName = usern;
            Password = pass;
        }

        public bool CanLogIn()
        {
            bool output = false;
            if (UserName == "james" && Password == "pass")
                output = true;

            return output;
        }
    }
}
