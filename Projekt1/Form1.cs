using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
//wydruk drukaraka kilka naklejek zapisz do png
//   customPictureBox1.BackColor = Color.Transparent;
namespace Projekt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog zdjecie = new OpenFileDialog();
            zdjecie.Filter = "Bitmap|*.jpg|jpeps|*.bmp";
            if (zdjecie.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = zdjecie.FileName;

            }

            Form1.ActiveForm.BackgroundImage = pictureBox1.Image;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog naklejka = new OpenFileDialog();
            naklejka.InitialDirectory = "D:\\C#\\Projekt1\\naklejki";
            naklejka.Filter = "sticer|*.png";

            if (naklejka.ShowDialog() == DialogResult.OK)
            {

                customPictureBox1.Image = System.Drawing.Image.FromFile(naklejka.FileName);

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            
            Bitmap bmp0 = (Bitmap)pictureBox1.Image;
            Bitmap bmpRs = bmp0;
            Bitmap bmpB = (Bitmap)customPictureBox1.Image;
            Graphics g = Graphics.FromImage(bmpRs);
            g.DrawImage(bmpB, customPictureBox1.Location.X/4*3, customPictureBox1.Location.Y/5*3 ,bmp0.Size.Width/8 , bmp0.Size.Height/8 );
            g.Dispose();
            pictureBox1.Image = bmp0;
            Form1.ActiveForm.BackgroundImage = bmp0;
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog zapis = new SaveFileDialog();
            zapis.Filter = "Bitmap|*.jpg|jpeps|*.bmp";
            if (zapis.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(zapis.FileName);

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            if (pd.ShowDialog()==DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
       
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();

        }
        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Point ulCorner = new Point(100, 100);
            e.Graphics.DrawImage(pictureBox1.Image, ulCorner);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = printDoc;
            dlg.ShowDialog();         
        }
      

    }
}

