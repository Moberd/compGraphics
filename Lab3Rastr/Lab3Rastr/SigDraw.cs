using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Rastr
{
    public partial class SigDraw : Form
    {
        public SigDraw()
        {
            InitializeComponent();
            g.Clear(Color.White);
        }

        //Правильное закрытие окна
        private void SigDraw_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }


        static Bitmap bmp = new Bitmap(776, 426);

        public Graphics g = Graphics.FromImage(bmp);

        Pen myPen = new Pen(Color.Black);

        public int X0;
        public int Y0;

        bool mouse_Down = false;

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouse_Down = true;
            this.X0 = e.X;
            this.Y0 = e.Y;

        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mouse_Down)
            {
                g.Clear(Color.White);
                if (radioButton1.Checked)
                {
                    Line_Bres(X0, Y0, Math.Min(pictureBox1.Width - 1, Math.Max(e.X, 1)), Math.Min(pictureBox1.Height - 1, Math.Max(e.Y, 1)));
                }
                else if (radioButton2.Checked)
                {
                    Line_Vu(X0, Y0, Math.Min(pictureBox1.Width - 1, Math.Max(e.X, 1)), Math.Min(pictureBox1.Height - 1, Math.Max(e.Y, 1)));
                }
                else
                {
                    MessageBox.Show("Please, select a method.");
                }
            }
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            mouse_Down = false;

        }

        static void Swap(ref int x, ref int y)
        {
            int t = x;
            x = y;
            y = t;
        }

        //Алгоритмом Брезенхема
        void Line_Bres(int x0, int y0, int x1, int y1)
        {
            int xtemp0 = x0;
            int xtemp1 = x1;
            int ytemp0 = y0;
            int ytemp1 = y1;
            if (Math.Abs(x1 - x0) < Math.Abs(y1 - y0))
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            int deltax = Math.Abs(x1 - x0);
            int deltay = Math.Abs(y1 - y0);
            int error = 0;
            int deltaerr = (deltay + 1);
            int y = y0;
            int diry = y1 - y0;
            if (diry > 0)
                diry = 1;
            if (diry < 0)
                diry = -1;
            for (int x = x0; x <= x1; x++)
            {
                bmp.SetPixel(Math.Abs(ytemp1 - ytemp0) > Math.Abs(xtemp1 - xtemp0) ? y : x, Math.Abs(ytemp1 - ytemp0) > Math.Abs(xtemp1 - xtemp0) ? x : y, Color.Black);
                error = error + deltaerr;
                if (error >= deltax + 1)
                {
                    y += diry;
                    error = error - (deltax + 1);
                }
            }
            pictureBox1.Image = bmp;
        }

        void DrawPoint(int x, int y, float intensive)
        {
            Color col = bmp.GetPixel(x, y);
            bmp.SetPixel(x, y, Color.FromArgb(255, (int)(col.R * (1 - intensive)), (int)(col.G * (1 - intensive)), (int)(col.B * (1 - intensive))));
        }

        //Алгоритмом ВУ
        void Line_Vu(int x0, int y0, int x1, int y1) 
        {
            int xtemp0 = x0;
            int xtemp1 = x1;
            int ytemp0 = y0;
            int ytemp1 = y1;
            if (Math.Abs(x1 - x0) < Math.Abs(y1 - y0))
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (var x = x0 + 1; x <= x1 - 1; x++)
            {
                DrawPoint(Math.Abs(xtemp1 - xtemp0) < Math.Abs(ytemp1 - ytemp0) ? (int)y : x, Math.Abs(xtemp1 - xtemp0) < Math.Abs(ytemp1 - ytemp0) ? x : (int)y, 1 - (y - (int)y));
                DrawPoint(Math.Abs(xtemp1 - xtemp0) < Math.Abs(ytemp1 - ytemp0) ? (int)y + 1 : x, Math.Abs(xtemp1 - xtemp0) < Math.Abs(ytemp1 - ytemp0) ? x : (int)y + 1, y - (int)y);
                y += gradient;
            }
            pictureBox1.Image = bmp;
        }

    }
}
