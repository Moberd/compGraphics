using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFrac_Click(object sender, EventArgs e)
        {
            FormFractal form = new FormFractal();
            form.Show();
        }

        private void buttonMountains_Click(object sender, EventArgs e)
        {
            FormMountains form = new FormMountains();
            form.Show();
        }

        private void buttonBezier_Click(object sender, EventArgs e)
        {
            FormBezier form = new FormBezier();
            form.Show();
        }
    }
}
