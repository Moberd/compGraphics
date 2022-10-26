using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKek
{
    partial class Form1
    {
        bool isScaling = false;
        bool isRotating = false;
       
        private void buttonShift_Click(object sender, EventArgs e)
        {
            shift(int.Parse(textShiftX.Text), int.Parse(textShiftY.Text));
            redrawPolygon();
            setFlags(isAffineTransformationsEnabled: true);
        }

        private void buttonScale_Click(object sender, EventArgs e)
        {
            isScaling = true;
            setFlags(isPointChoosing: true);
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            isRotating = true;
            setFlags(isPointChoosing: true);
        }

        void onPointChosen(PointF p)
        {
            if (isRotating)
            {
                rotateAroundPoint(p, canvas.Size);
                redrawPolygon();
                isRotating = false;
            }
            else if (isScaling)
            {
                scaleAroundPoint(p);
                redrawPolygon();
                isScaling = false;
            }
            setFlags(isAffineTransformationsEnabled: true);
        }

        private void buttonСhooseCentre_Click(object sender, EventArgs e)
        {
            setFlags();
            var center = new PointF(0, 0);
            foreach (var p in polygonPoints)
            {
                center.X += p.X;
                center.Y += p.Y;
            }
            center.X /= (float)polygonPoints.Count;
            center.Y /= (float)polygonPoints.Count;
            onPointChosen(center);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            setFlags();
            var center = new PointF(0, 0);
            center.X = (float)(canvas.Width / 2.0);
            center.Y = (float)(canvas.Height / 2.0);
            onPointChosen(center);
        }
        

        private double degreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        void rotateAroundPoint(PointF rpoint, SizeF screenSize)
        {
            double angle = double.Parse(textAngle.Text);
            for(int i = 0; i < polygonPoints.Count; i++)
            {
                var shift1 = new Matrix(3,3).fillAffine(1, 0, 0, 1,  -rpoint.X, -rpoint.Y);
                var rotation = new Matrix(3, 3).fillAffine((float)Math.Cos(degreesToRadians(angle)), (float)-Math.Sin(degreesToRadians(angle)), (float)Math.Sin(degreesToRadians(angle)), (float)Math.Cos(degreesToRadians(angle)), 0, 0);
                var shift2 = new Matrix(3, 3).fillAffine(1, 0, 0, 1, rpoint.X, rpoint.Y);
                var vals = new Matrix(1, 3).fill(polygonPoints[i].X, polygonPoints[i].Y, 1);
                var prom = (shift1 * rotation * shift2);
                var res = vals * prom;
                polygonPoints[i] = new PointF(res[0,0],res[0,1]);
            }
        }

        void shift(int dx, int dy)
        {
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                var shift = new Matrix(3, 3).fillAffine(1, 0, 0, 1, dx, dy);
                var vals = new Matrix(1, 3).fill(polygonPoints[i].X, polygonPoints[i].Y, 1);
                var res = vals * shift;
                polygonPoints[i] = new PointF(res[0, 0], res[0, 1]);
            }
        }

        void scaleAroundPoint(PointF rpoint)
        {
            float scaleX = float.Parse(textScaleX.Text);
            float scaleY = float.Parse(textScaleY.Text);
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                var shift1 = new Matrix(3, 3).fillAffine(1, 0, 0, 1, -rpoint.X, -rpoint.Y);
                var scaling = new Matrix(3, 3).fillAffine(scaleX,0,0,scaleY, 0, 0);
                var shift2 = new Matrix(3, 3).fillAffine(1, 0, 0, 1, rpoint.X, rpoint.Y);
                var vals = new Matrix(1, 3).fill(polygonPoints[i].X, polygonPoints[i].Y, 1);
                var prom = (shift1 * scaling * shift2);
                var res = vals * prom;
                polygonPoints[i] = new PointF(res[0, 0], res[0, 1]);
            }
        }
    }
}
