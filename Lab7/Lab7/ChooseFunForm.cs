using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class ChooseFunForm : Form
    {
        public Func<double,double,double> SelectedFunction { get; set; }
        public Image Formula { get; set; }
        public Size ImageSize { get; set; }
        public ChooseFunForm()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return x * x + y * y; };
            Formula = pictureBox2.Image;
            ImageSize = pictureBox2.Size;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return 5*(Math.Cos(x*x + y*y + 1)/(x * x + y * y + 1) + 0.1); };
            Formula = pictureBox1.Image;
            ImageSize = pictureBox1.Size;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return Math.Sin(x) + Math.Cos(y); };
            Formula = pictureBox3.Image;
            ImageSize = pictureBox3.Size;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return Math.Sin(x) * Math.Cos(y); };
            Formula = pictureBox5.Image;
            ImageSize = pictureBox5.Size;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => { return (Math.Sin(x) + Math.Sin(y)) * Math.Pow(Math.Cos(x+y),2); };
            Formula = pictureBox4.Image;
            ImageSize = pictureBox4.Size;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
