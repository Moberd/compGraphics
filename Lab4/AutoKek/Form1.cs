using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKek
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            g = canvas.CreateGraphics();
        }

        bool isDrawingMode = false;
        bool isSomethingOnScreen = false;
        bool isPointChoosingMode = false;
        int twolinesmode = 0;

        bool isPointClassifyMode = false;
        bool isPointInPolygonMode = false;


        /// <summary>
        /// Самое главное здесь - набор точек (и для полигона, и для отрезка, и для всего...)
        /// </summary>
        List<PointF> polygonPoints = new List<PointF>();

        // координаты отрезка для классификации точки
        List<PointF> polygonPointsForClassify = new List<PointF>();

        /// <summary>
        /// Для рисования
        /// </summary>
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen blackPen = new Pen(Color.Black, 3);
        Graphics g;

        void setFlags(bool isDrawingMode = false, bool isAffineTransformationsEnabled = false, bool isPointChoosing = false)
        {
            this.isDrawingMode = isDrawingMode;
            comboBoxShape.Enabled = isDrawingMode;

            textShiftX.Enabled = isAffineTransformationsEnabled;
            textShiftY.Enabled = isAffineTransformationsEnabled;
            buttonShift.Enabled = isAffineTransformationsEnabled;
            buttonRotate.Enabled = isAffineTransformationsEnabled;
            textAngle.Enabled = isAffineTransformationsEnabled;
            buttonScale.Enabled = isAffineTransformationsEnabled;
            textScaleX.Enabled = isAffineTransformationsEnabled;
            textScaleY.Enabled = isAffineTransformationsEnabled;

            buttonRotateLine.Enabled = isAffineTransformationsEnabled && comboBoxShape.SelectedIndex == 1;
            buttonCrossLines.Enabled = isAffineTransformationsEnabled && comboBoxShape.SelectedIndex == 1;

            buttonClassifyPoint.Enabled = isAffineTransformationsEnabled && comboBoxShape.SelectedIndex == 1;
            buttonIsPointInPolygon.Enabled = isAffineTransformationsEnabled && comboBoxShape.SelectedIndex == 1;

            isPointChoosingMode = isPointChoosing;
            buttonСhooseCentre.Visible = isPointChoosing;
            buttonСhooseCentre.Enabled = isPointChoosing;
            button1.Visible = isPointChoosing;
            button1.Enabled = isPointChoosing;
            labelChoodePoint.Visible = isPointChoosing;

        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDrawingMode)
            {
                switch (comboBoxShape.SelectedIndex)
                {
                    case 0: drawPolygon(e); break;
                    case 1: drawLine(e); break;
                    case 2: drawPoint(e); break;
                }
            } else if (isPointChoosingMode)
            {
                onPointChosen(e.Location);
            }
            else if (isPointClassifyMode)
            {
                drawPoint(e);
                isPointClassifyMode = false;
                ClassifyPoint(polygonPointsForClassify[0], polygonPointsForClassify[1], e.Location);
            }
            else if (isPointInPolygonMode)
            {
                drawPoint(e);                
                PointInPolygon(e.Location);
                isPointInPolygonMode = false;
                buttonIsPointInPolygon.Enabled = true;
            }
            if (twolinesmode==1)
            {
                DrawSec(e);
                
            }
            if (twolinesmode == 2)
            {
               // DrawSec(e);
                PointF p=CrossLines();
                if (p.X!=int.MaxValue && p.Y!=int.MaxValue)
                g.FillEllipse(new SolidBrush(Color.Red), p.X - 3, p.Y - 3, 7, 7);
                setFlags();
            }

        }

        private void comboBoxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            canvas.Image = new Bitmap(1300, 900);
            polygonPoints.Clear();
            polygonPointsForClassify.Clear();
        }
    }
}