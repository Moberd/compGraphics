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

namespace Lab6
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        bool isInteractiveMode = false;
        double shiftx=0;
        double shifty =0;
        double shiftz =0;

        public Form1()
        {
            InitializeComponent();
            selectShape.SelectedIndex = 0;
            g = canvas.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            // ����� �� ����� ��������� ������� ��������� �� �������
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -(float)canvas.Height);

            // � ����� ����� ����� ������ ���������
            Point.worldCenter = new PointF(canvas.Width / 2, canvas.Height / 2);
            setFlags();
        }
        void setFlags(bool interactiveMode = false)
        {
            isInteractiveMode = interactiveMode;
            selectAxis.Enabled = interactiveMode;
            buttonRotate.Enabled = interactiveMode;
            buttonScale.Enabled = interactiveMode;
            buttonShift.Enabled = interactiveMode;
            rbPerspective.Enabled = interactiveMode;
            rbIsometric.Enabled = interactiveMode;
            rbCavalier.Enabled = interactiveMode;
            btnShowAxis.Enabled = interactiveMode;
            textAngle.Enabled = interactiveMode;
            textScaleX.Enabled = interactiveMode;
            textScaleY.Enabled = interactiveMode;
            textScaleZ.Enabled = interactiveMode;
            textShiftX.Enabled = interactiveMode;
            textShiftY.Enabled = interactiveMode;
            textShiftZ.Enabled = interactiveMode;
            selectMirrorAxis.Enabled = interactiveMode;
            rbWorldCenter.Enabled = interactiveMode;
            rbCenter.Enabled = interactiveMode;
            buttonMirror.Enabled = interactiveMode;
            buttonRoll.Enabled = interactiveMode;
            selectRollAxis.Enabled = interactiveMode;
            buttonRotateAroundLine.Enabled = interactiveMode;
            textX1.Enabled = interactiveMode;
            textX2.Enabled = interactiveMode;
            textY1.Enabled = interactiveMode;
            textY2.Enabled = interactiveMode;
            textZ1.Enabled = interactiveMode;
            textZ2.Enabled = interactiveMode;
            textAngleForLineRotation.Enabled = interactiveMode;
            textBoxAngleRotCenter.Enabled = interactiveMode;

            buttonShape.Text = interactiveMode ? "��������" : "����������";
            selectShape.Enabled = !interactiveMode;
        }

        private void comboBoxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (selectShape.SelectedIndex)
            {
                case 0: currentShapeType = ShapeType.TETRAHEDRON; break;
                case 1: currentShapeType = ShapeType.HEXAHEDRON; break;
                case 2: currentShapeType = ShapeType.OCTAHEDRON; break;
                case 3: currentShapeType = ShapeType.ICOSAHEDRON; break;
                case 4: currentShapeType = ShapeType.DODECAHEDRON; break;
                default: throw new Exception("������� �� ������� :(");
            }
        }
        private void selectRollAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (selectRollAxis.SelectedIndex)
            {
                case 0: currentRollAxis = AxisType.X; break;
                case 1: currentRollAxis = AxisType.Y; break;
                case 2: currentRollAxis = AxisType.Z; break;
                default: throw new Exception("����������� ��� �� ������� :(");
            }
        }

        private void rbPerspective_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPerspective.Checked)
            {
                Point.projection = ProjectionType.PERSPECTIVE;
                redraw();
            }
        }
        
        private void textScaleX_TextChanged(object sender, EventArgs e)
        {
            if(textScaleX.Text == "")
            {
                textScaleX.Text = "1";
            }
        }

        private void textScaleY_TextChanged(object sender, EventArgs e)
        {
            if (textScaleY.Text == "")
            {
                textScaleY.Text = "1";
            }
        }

        private void textScaleZ_TextChanged(object sender, EventArgs e)
        {
            if (textScaleZ.Text == "")
            {
                textScaleZ.Text = "1";
            }
        }
        
        private void textShiftX_TextChanged(object sender, EventArgs e)
        {
            if (textShiftX.Text == "")
            {
                textShiftX.Text = "0";
            }
        }

        private void textShiftY_TextChanged(object sender, EventArgs e)
        {
            if (textShiftY.Text == "")
            {
                textShiftY.Text = "0";
            }
        }

        private void textShiftZ_TextChanged(object sender, EventArgs e)
        {
            if (textShiftZ.Text == "")
            {
                textShiftZ.Text = "0";
            }
        }

        private void rbIsometric_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIsometric.Checked)
            {
                Point.projection = ProjectionType.ISOMETRIC;
                redraw();
            }
        }
        private void selectAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (selectAxis.SelectedIndex)
            {
                case 0: currentAxis = AxisType.X; break;
                case 1: currentAxis = AxisType.Y; break;
                case 2: currentAxis = AxisType.Z; break;
                default: throw new Exception("��� �� ������� :(");
            }
        }
        private void buttonRoll_Click(object sender, EventArgs e)
        {
            rotationThroughTheCenter(ref currentShape, currentRollAxis, int.Parse(textBoxAngleRotCenter.Text));
            redraw();
        }
        private void rbWorldCenter_CheckedChanged(object sender, EventArgs e)
        {
            isScaleModeWorldCenter = rbWorldCenter.Checked;
        }
        private void buttonMirror_Click(object sender, EventArgs e)
        {
            reflectionAboutTheAxis(ref currentShape, currentMirrorAxis);
            redraw();
        }
        private void selectMirrorAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (selectMirrorAxis.SelectedIndex)
            {
                case 0: currentMirrorAxis = AxisType.X; break;
                case 1: currentMirrorAxis = AxisType.Y; break;
                case 2: currentMirrorAxis = AxisType.Z; break;
                default: throw new Exception("���������� ��� �� ������� :(");
            }
        }
        private void buttonRotateAroundLine_Click(object sender, EventArgs e)
        {
            int angle = int.Parse(textAngleForLineRotation.Text);
            Point p1 = new Point(int.Parse(textX1.Text), int.Parse(textY1.Text), int.Parse(textZ1.Text));
            Point p2 = new Point(int.Parse(textX2.Text), int.Parse(textY2.Text), int.Parse(textZ2.Text));
            if (p1.Z ==0 && p1.X==0&&p1.Y==0&& (p2.Z != 0 ||p2.Y ==0 || p2.X==0) )
              
            {
                Point tmp = p1;
                p1 = p2;
                p2 = tmp;
            }
            if (p2.Z == 0 && p2.X == 0 && p2.Y == 0 && (p1.Z != 0 || p1.Y == 0 || p1.X == 0))

            {
                Point tmp = p1;
                p1 = p2;
                p2 = tmp;
            }

            rotate_around_line(ref currentShape, angle,p1,p2);
            double A = p1.Yf - p2.Yf;//����� ��������� ������, ���������� ����� �������� �����
            double B = p2.Xf - p1.Xf;//������ ������� 
            double C = p1.Xf * p2.Yf - p2.Xf *p1.Yf;
            Point p3 = new Point(p2.Xf - p1.Xf,  p2.Yf- p1.Yf,  p2.Zf - p1.Zf);
            // ��������, ��� ��� �����
            //redraw();
            shift(ref currentShape, p1.Xf-shiftx, p1.Yf-shifty, p1.Zf-shiftz);
            shiftx = p1.Xf;
            shifty = p1.Yf;
            shiftz = p1.Zf;
            redraw();
            drawLine(new Line(p1, p2), new Pen(Color.Aquamarine, 4));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCavalier.Checked)
            {
                Point.projection = ProjectionType.CAVALIER;
                redraw();
            }
        }
    }
}