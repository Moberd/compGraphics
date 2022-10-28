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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FillandHighlight fillandHighlight = new FillandHighlight();
            fillandHighlight.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SigDraw SigDraw = new SigDraw();
            SigDraw.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            GradientTraing gradientTraing = new GradientTraing();
            gradientTraing.Show(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FillPicture fillpicture = new FillPicture();
            fillpicture.Show(this);

        }
    }
}
