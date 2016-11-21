using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandleFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWriteToFile_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = @"C:\Users\James Leveille\Documents\GitHub\test\" + txtFilename.Text;
                string fileData = rchWFiledate.Text;

                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }

                File.WriteAllText(fileName, fileData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = @"C:\Users\James Leveille\Documents\GitHub\test\" + txtReadFileName.Text;
                string fileData = "";

                using (StreamReader rd = new StreamReader(fileName))
                {
                    string line = rd.ReadToEnd();
                    fileData = line;
                }

                rchReadFileDate.Text = fileData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
