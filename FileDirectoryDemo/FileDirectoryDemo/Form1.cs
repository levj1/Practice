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

namespace FileDirectoryDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DirectoryInfo dir = new DirectoryInfo(@"C:\TestFiles\");
            MessageBox.Show(dir.Name);


            

        }

        private void DirectoryInfoMeth()
        {
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory().ToString());
            
            StringBuilder sb = new StringBuilder();

            sb.Append("Directory name: " + dir.Name);
            sb.Append(Environment.NewLine);
            sb.Append("Directory FullName: " + dir.FullName);
            sb.Append(Environment.NewLine);
            sb.Append("Directory Root: " + dir.Root);
            sb.Append(Environment.NewLine);
            sb.Append("Directory CreationTime: " + dir.CreationTime);
            sb.Append(Environment.NewLine);
            sb.Append("Directory Parent: " + dir.Parent);
            sb.Append(Environment.NewLine);


            string output = sb.ToString();

            MessageBox.Show(output);
        }
    }
}
