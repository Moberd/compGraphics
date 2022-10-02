﻿using System;
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
    public partial class FillandHighlight : Form
    {
        public FillandHighlight()
        {
            InitializeComponent();
            g.Clear(Color.White);
        }

        //Правильное закрытие окна
        private void FillandHighlight_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
        static Bitmap bmp = new Bitmap(485, 491);

        bool mouse_Down = false;

        bool is_fill = false;

        public Graphics g = Graphics.FromImage(bmp);

        Pen myPen = new Pen(Color.Black, 3f);

        Pen pen_fill = new Pen(Color.Black);

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_Down = true;
            is_fill = true;
            points[0] = new Point(e.X, e.Y);
            myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            myPen.Color = colorDialog1.Color;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_Down = false;

            if (radioButton1.Checked)
            {
                if (is_fill)
                    FloodFill(e.X, e.Y);
            }
            else if (radioButton2.Checked)
            {
                if (is_fill)
                    FloodFillImg(e.X, e.Y);
                
            }
            else if (radioButton3.Checked)
            {
                if (is_fill)
                    Connected(e.X, e.Y);
            }

        }

        Point[] points = new Point[2];
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            is_fill = false;
            if (mouse_Down)
            {
                points[1] = new Point(e.X, e.Y);
                g.DrawLines(myPen, points);
                pictureBox1.Image = bmp;
                points[0] = points[1];
                points[1] = new Point(e.X, e.Y);
            }
        }


        void FloodFill(int x, int y)
        {
            Color col = bmp.GetPixel(x, y);
            pen_fill.Color = colorDialog1.Color;

            if (!(pen_fill.Color.R == col.R && pen_fill.Color.G == col.G && pen_fill.Color.B == col.B))
            {
                int left_x_bound = x;
                int cur_y = y;
                Color cur_col = bmp.GetPixel(left_x_bound, cur_y);
                while (left_x_bound != 1 && cur_col == col)
                {
                    left_x_bound--;
                    cur_col = bmp.GetPixel(left_x_bound, cur_y);
                }
                left_x_bound++;

                int right_x_bound = x;
                cur_col = bmp.GetPixel(right_x_bound, cur_y);
                while (right_x_bound != pictureBox1.Width - 1 && cur_col == col)
                {
                    right_x_bound++;
                    cur_col = bmp.GetPixel(right_x_bound, cur_y);
                }
                right_x_bound--;
                g.DrawLine(pen_fill, new Point(left_x_bound, y), new Point(right_x_bound, y));
                pictureBox1.Image = bmp;

                int check_x = left_x_bound;
                while (bmp.GetPixel(++check_x, y + 1) != col && check_x < right_x_bound) { }
                if (y + 1 < pictureBox1.Height - 1 && col == bmp.GetPixel(check_x, y + 1))
                {
                    FloodFill(check_x, y + 1);
                }

                check_x = right_x_bound;
                while (bmp.GetPixel(--check_x, y + 1) != col && check_x > left_x_bound) { }
                if (y + 1 < pictureBox1.Height - 1 && col == bmp.GetPixel(check_x, y + 1))
                {
                    FloodFill(check_x, y + 1);
                }

                check_x = left_x_bound;
                while (bmp.GetPixel(++check_x, y - 1) != col && check_x < right_x_bound) { }
                if (y - 1 > 0 && col == bmp.GetPixel(check_x, y - 1))
                {
                    FloodFill(check_x, y - 1);
                }

                check_x = right_x_bound;
                while (bmp.GetPixel(--check_x, y - 1) != col && check_x > left_x_bound) { }
                if (y - 1 > 0 && col == bmp.GetPixel(check_x, y - 1))
                {
                    FloodFill(check_x, y - 1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        public string img;
        public Bitmap bmp_pic;

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpeg;*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.img = ofd.FileName;
                    bmp_pic = new Bitmap(this.img);
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpeg;*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.img = ofd.FileName;
                    bmp_pic = new Bitmap(this.img);
                }
                pictureBox1.Image = bmp_pic;
            }
        }

        void FloodFillImg(int x, int y)
        {
            Color col = bmp.GetPixel(x, y);
            pen_fill.Color = colorDialog1.Color;
            int left_x_bound = x;
            int cur_y = y;
            Color cur_col = bmp.GetPixel(left_x_bound, cur_y);
            int right_x_bound = x;
            Color cur_col2 = bmp.GetPixel(right_x_bound, cur_y);
            if (!(pen_fill.Color.R == col.R && pen_fill.Color.G == col.G && pen_fill.Color.B == col.B) && bmp_pic != null)
            {
                while (left_x_bound != 1 && cur_col == col)
                {
                    cur_col = bmp.GetPixel(left_x_bound, cur_y);
                    bmp.SetPixel(left_x_bound, cur_y, bmp_pic.GetPixel(left_x_bound % bmp_pic.Width, cur_y % bmp_pic.Height));
                    left_x_bound--;
                }
                left_x_bound++;

                while (right_x_bound != pictureBox1.Width - 1 && cur_col2 == col)
                {
                    right_x_bound++;
                    cur_col2 = bmp.GetPixel(right_x_bound, cur_y);
                    bmp.SetPixel(right_x_bound, cur_y, bmp_pic.GetPixel(right_x_bound % bmp_pic.Width, cur_y % bmp_pic.Height));
                }
                right_x_bound--;
                pictureBox1.Image = bmp;

                int check_x = left_x_bound;
                while (bmp.GetPixel(++check_x, y + 1) != col && check_x < right_x_bound) { }
                if (y + 1 < pictureBox1.Height - 1 && col == bmp.GetPixel(check_x, y + 1))
                {
                    FloodFillImg(check_x, y + 1);
                }

                check_x = right_x_bound;
                while (bmp.GetPixel(--check_x, y + 1) != col && check_x > left_x_bound) { }
                if (y + 1 < pictureBox1.Height - 1 && col == bmp.GetPixel(check_x, y + 1))
                {
                    FloodFillImg(check_x, y + 1);
                }

                check_x = left_x_bound;
                while (bmp.GetPixel(++check_x, y - 1) != col && check_x < right_x_bound) { }
                if (y - 1 > 0 && col == bmp.GetPixel(check_x, y - 1))
                {
                    FloodFillImg(check_x, y - 1);
                }

                check_x = right_x_bound;
                while (bmp.GetPixel(--check_x, y - 1) != col && check_x > left_x_bound) { }
                if (y - 1 > 0 && col == bmp.GetPixel(check_x, y - 1))
                {
                    FloodFillImg(check_x, y - 1);
                }
            }
        }

        void Connected(int x, int y)
        {
            Color col = bmp_pic.GetPixel(x, y);
            Color cur_col = col;
            int left_bound = x;
            while (left_bound != 1 && cur_col == col)
            {
                left_bound--;
                cur_col = bmp_pic.GetPixel(left_bound, y);
            }
            left_bound++;
            int x_cur = left_bound;
            int y_cur = y;
            while (true)
            {
                pictureBox1.Image = bmp_pic;

                if (x_cur - 1 != 1 && bmp_pic.GetPixel(x_cur - 1, y_cur) == col && bmp_pic.GetPixel(x_cur, y_cur + 1) != col/* && bmp_pic.GetPixel(x_cur, y_cur -1) != col*/)
                {
                    cur_col = bmp_pic.GetPixel(x_cur - 1, y_cur);
                    x_cur--;
                    while (x_cur != 1 && cur_col == col)
                    {

                        cur_col = bmp_pic.GetPixel(x_cur, y_cur);
                        bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
                    }
                }

                else if (y_cur - 1 != 1 && bmp_pic.GetPixel(x_cur, y_cur - 1) == col && bmp_pic.GetPixel(x_cur - 1, y_cur) != col)
                {
                    cur_col = bmp_pic.GetPixel(x_cur, y_cur - 1);
                    y_cur--;
                    while (y_cur != 1 && cur_col == col)
                    {

                        cur_col = bmp_pic.GetPixel(x_cur, y_cur);
                        bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
                    }
                }
                else
                if (x_cur + 1 != pictureBox1.Width - 1 && bmp_pic.GetPixel(x_cur + 1, y_cur) == col)
                {
                    cur_col = bmp_pic.GetPixel(x_cur + 1, y_cur);
                    x_cur++;
                    while (x_cur != 1 && cur_col == col)
                    {

                        cur_col = bmp_pic.GetPixel(x_cur, y_cur);
                        bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
                    }
                }
                else if (y_cur + 1 != pictureBox1.Height - 1 && bmp_pic.GetPixel(x_cur, y_cur + 1) == col)
                {
                    cur_col = bmp_pic.GetPixel(x_cur, y_cur + 1);
                    y_cur++;
                    while (x_cur != 1 && cur_col == col)
                    {

                        cur_col = bmp_pic.GetPixel(x_cur, y_cur);
                        bmp_pic.SetPixel(x_cur, y_cur, Color.Black);
                    }
                }

                else
                    break;
                pictureBox1.Image = bmp_pic;
            }
            pictureBox1.Image = bmp_pic;
        }

        
    }
}
