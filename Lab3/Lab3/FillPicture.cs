using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Rastr
{
    public partial class FillPicture : Form
    {
        String picPath = "";
        Bitmap bmp;
        Bitmap picBmp;
        public static Color backColor;
        public static Color borderColor;
        int centX;
        int centY;
        Pen myPen = new Pen(Color.Black, 3f);

        static int leftBorder;

        Point lastPoint = Point.Empty;
        bool isMouseDown = new Boolean();

        public FillPicture()
        {
            InitializeComponent();
        }

        private void FillPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
                if (lastPoint != null)
                {
                    if (pictureBox1.Image == null)
                    {
                        Bitmap bmp1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Image = bmp1;
                    }
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                    {
                        g.DrawLine(myPen, lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.None;
                    }
                    pictureBox1.Invalidate();
                    lastPoint = e.Location;
                }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
            myPen.StartCap = LineCap.Round;
            myPen.EndCap = LineCap.Round;
            myPen.Color = colorDialog1.Color;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;

            if (picBmp != null && e.Button == MouseButtons.Right)
            {
                bmp = new Bitmap(pictureBox1.Image);
                centX = e.X;
                centY = e.Y;
                fillPicture(e.X, e.Y);
                pictureBox1.Image = bmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
                Invalidate();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String path = openFileDialog1.FileName;
                picPath = path;
            }
            picBmp = new Bitmap(Image.FromFile(picPath));
        }

        public void fillPicture(int x, int y)
        {

            Color backColor = bmp.GetPixel(x, y);
            while (bmp.GetPixel(x, y) == backColor && x > 0)
                x--;
            Color bord = bmp.GetPixel(x, y);
            leftBorder = ++x;
            while (bmp.GetPixel(x, y) == backColor && x < pictureBox1.Width - 1)
            {
                try { bmp.SetPixel(x, y, picBmp.GetPixel(x - centX + picBmp.Width / 2, y - centY + picBmp.Height / 2)); }
                catch (Exception e) { bmp.SetPixel(x, y, Color.Blue); }
                //pictureBox1.Image = bmp;
                ///pictureBox1.Update();
                x++;
            }
            x = leftBorder;

            while ((bmp.GetPixel(x, y) == Color.Blue) || (bmp.GetPixel(x, y) == picBmp.GetPixel(x - centX + picBmp.Width / 2, y - centY + picBmp.Height / 2)) && y > 0 && y < pictureBox1.Height - 1)
            {
                if (bmp.GetPixel(x, y - 1) == backColor)
                    fillPicture(x, y - 1);

                if (bmp.GetPixel(x, y + 1) == backColor)
                    fillPicture(x, y + 1);

                ++x;
            }
        }

    }
}
