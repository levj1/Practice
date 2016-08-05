using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataBiding
{
    class User: INotifyPropertyChanged
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            { 
                firstName = value;
                OnPropertyChanged();
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set 
            {
                if (value != "Leveille")
                {

                }
                else
                {
                    lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public static User GetUser()
        {
            var user = new User
            {
                FirstName = "James",
                LastName = "Leveille"
            };

            return user;
        }

        bool Validate()
        {
            bool isValid = true;
            if (!string.IsNullOrWhiteSpace(FirstName)) isValid = false;
            if (!string.IsNullOrWhiteSpace(LastName)) isValid = false;

            return isValid;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string caller =  "" )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(caller));
            }
        }
    }
}
