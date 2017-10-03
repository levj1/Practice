using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageBorderInInche
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string imageFilePath = @"C:\Reservations\S 2016\75476\Original\754760001.jpg";
            ChangePictureBox(imageFilePath, true);
        }

        private static void ShowBorderLineOnPicture(Bitmap fileBMP, bool showLine)
        {
            if (showLine)
            {
                Pen redPen = new Pen(Color.Red, 3);
                using (var graphics = Graphics.FromImage(fileBMP))
                {
                    Rectangle rectangle = new Rectangle(50, 50, fileBMP.Width - 100, fileBMP.Height - 100);
                    graphics.DrawRectangle(redPen, rectangle);
                }
            }
        }
        private void ChangePictureBox(string imageFilePath, bool showLine = false)
        {
            try
            {
                using (var fileBMP = new Bitmap(imageFilePath))
                {
                    if (showLine)
                    {
                        ShowBorderLineOnPicture(fileBMP, showLine);
                    }
                    pictureBox1.Image = new Bitmap(fileBMP);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an issue trying to display the image: \n " + ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DrawImageRectRect(PaintEventArgs e)
        {

            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");

            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(100, 100, 450, 150);

            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;

            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, srcRect, units);
        }
    }
}
