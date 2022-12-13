using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsHelper;

namespace AdvancedGraphics
{
    enum DisplayType{ TRIANGLES, LINES, NET }

    public partial class FormPlotting : Form
    {
        Func<double, double, double> SelectedFunction { get; set; }
        DisplayType displayType;

        public FormPlotting()
        {
            InitializeComponent();
            displayType = DisplayType.TRIANGLES;
        }

        void setPBStyles(int selectedPBIndex)
        {
            pictureBox1.BorderStyle = selectedPBIndex == 1 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox1.BackColor = selectedPBIndex != 1 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox2.BorderStyle = selectedPBIndex == 2 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox2.BackColor = selectedPBIndex != 2 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox3.BorderStyle = selectedPBIndex == 3 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox3.BackColor = selectedPBIndex != 3 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox4.BorderStyle = selectedPBIndex == 4 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox4.BackColor = selectedPBIndex != 4 ? SystemColors.Control : SystemColors.ControlLight;

            pictureBox5.BorderStyle = selectedPBIndex == 5 ? BorderStyle.Fixed3D : BorderStyle.None;
            pictureBox5.BackColor = selectedPBIndex != 5 ? SystemColors.Control : SystemColors.ControlLight;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => x * x + y * y;
            setPBStyles(2);
            redraw();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => Math.Sin(x) + Math.Cos(y);
            setPBStyles(3);
            redraw();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => Math.Sin(x) * Math.Cos(y);
            setPBStyles(5);
            redraw();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => 5 * (Math.Cos(x * x + y * y + 1) / (x * x + y * y + 1) + 0.1);
            setPBStyles(1);
            redraw();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SelectedFunction = (double x, double y) => (Math.Sin(x) + Math.Sin(y)) * Math.Pow(Math.Cos(x + y), 2);
            setPBStyles(4);
            redraw();
        }

        private void rbTriangles_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTriangles.Checked)
            {
                displayType = DisplayType.TRIANGLES;
            }
            redraw();
        }

        private void rbLines_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLines.Checked)
            {
                displayType = DisplayType.LINES;
            }
            redraw();
        }

        private void rbNet_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNet.Checked)
            {
                displayType = DisplayType.NET;
            }
            redraw();
        }

        private void FormPlotting_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    changeViewAngles(shiftY: 2);
                    break;
                case 'a':
                    changeViewAngles(shiftX: -2);
                    break;
                case 's':
                    changeViewAngles(shiftY: -2);
                    break;
                case 'd':
                    changeViewAngles(shiftX: 2);
                    break;
                default: return;
            }
            redraw();
            e.Handled = true;
        }
    }
}
