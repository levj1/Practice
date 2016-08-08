using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace ReadingCSVfiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\James Leveille\Desktop\CitywideReturns\2016 0804 RetChk sample.csv";
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.Delimiters = new string[] { "," };
                while (true)
                {
                    string[] fields = parser.ReadFields();
                    for(int i = 1; i < fields.Length - 1; i++)
                    {
                        MessageBox.Show(String.Format("{0}", fields[i].ToString()));
                    }
                    
                }
            }

            //string TempPath = string.Format("{0}\\temp{1}\\", Directory.GetCurrentDirectory(), _IFaceTypeID);
            //if (!Directory.Exists(TempPath))
            //    Directory.CreateDirectory(TempPath);
            //return TempPath;

        }

        public string[] ParseFields(string sBuf)
        {
            try
            {
                string sReturn = "";
                bool bInStr = false;
                for (int i = 0; i < sBuf.Length; i++)
                {
                    if (!bInStr)
                    {
                        if (sBuf[i] == ',')
                            sReturn += '\v';
                        else if (sBuf[i] == '\"')
                            bInStr = true;
                        else
                            sReturn += sBuf[i];
                    }
                    else
                    {
                        if (sBuf[i] == '\"')
                            bInStr = false;
                        else
                            sReturn += sBuf[i];
                    }
                }
                return sReturn.Split('\v');
            }
            catch { }
            return null;
        }
    }
}
