using ClassLibrary;
using ClassLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFApp
{
    public partial class AddContactForm : Form
    {
        public AddContactForm()
        {
            InitializeComponent();
        }

        private void lblState_Click(object sender, EventArgs e)
        {

        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // Get all the data 
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string addressLine1 = txtAddress1.Text;
            string addressLine2 = txtAddress2.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string zipCode = txtZipCode.Text;

            Dictionary<string, string> fieldAndValues = new Dictionary<string, string>
            {
                {"First name", firstName },
                {"Last name", lastName },
                {"Email", email },
                {"Address Line 1", addressLine1 },
                {"Address Line 2", addressLine2 },
                {"City", city },
                {"State", state },
                {"Zip Code", zipCode }
            };

            string output = "";
            foreach (KeyValuePair<string, string> item in fieldAndValues)
            {                
                if(item.Key != "Address Line 2" && string.IsNullOrEmpty(item.Value))
                {
                    output += item.Key + " can't be empty.";
                    output += Environment.NewLine;
                }
            }
            if (!ValidateEmail(email))
                output += "Email must be of correct format.";

            if (output == "")
            {
                // call function to add to database
                Address address = new Address(addressLine1, addressLine2, city, state, zipCode);
                Contact contact = new Contact(firstName, lastName, address);
                ContactRepository contactRep = new ContactRepository();
                contactRep.AddContact(contact);
            }
            else
            {
                MessageBox.Show(output);
            }
        }

        private bool ValidateEmail(string email)
        {
            bool isValid = false;
            if (email.IndexOf('@') > 0 && email.IndexOf('.') > 0)
                isValid = true;
            return isValid;
        }
    }
}
