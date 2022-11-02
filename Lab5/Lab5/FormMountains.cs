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


    public partial class FormMountains : System.Windows.Forms.Form
    {
        bool drawingMode;
        double n;
        double r;
        public FormMountains() 
        {
            InitializeComponent();
            g = canvas.CreateGraphics();
            canvas.Image = new Bitmap(1300, 900);
            drawingMode = false;
        }
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        private int x1, y1, x2, y2;
        private List<Point> points = new List<Point>();
        private Pen pen = new Pen(Color.Brown);
        private Graphics g;
        private int count = 0;


        void drawPoint(MouseEventArgs e)
        {
            if (count == 0)
            {
                Point p1 = e.Location;
                x1 = p1.X;
                y1 = p1.Y;
                points.Add(p1);
                count++;
                g.FillEllipse(blackBrush, e.X - 3, e.Y - 3, 7, 7);
            }
            
            else if (count == 1)
            {
                Point p2 = e.Location;
                x2 = p2.X;
                y2 = p2.Y;
                points.Add(p2);
                count++;
                g.FillEllipse(blackBrush, e.X - 3, e.Y - 3, 7, 7);
                g.DrawLine(pen, points[0], p2);
            }

            

        }
        void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawingMode)
            {

                drawPoint(e);

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawingMode = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            DrawMountain();

        }
        private void DrawMountain()
        {
            g.Clear(Form.DefaultBackColor);
           
            List<Point> points_new = new List<Point>();

            for (long i=0;i<points.Count-1;i++)
            {
                //концы текущего отрезка
                x1 = points[(int)i].X;
                y1 = points[(int)i].Y;
                x2 = points[(int)(i + 1)].X;
                y2 = points[(int)(i + 1)].Y;

                //длина отрезка
                var l = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                {
                    var R = double.Parse(comboBox1.SelectedItem.ToString());
                    var r = new Random();
       
                    //координаты новой точки
                    var y = (int)((y1 + y2) / 2.0 + r.NextDouble()*2*R*l - R*l);
                    var x = (int)((x1 + x2) / 2.0);

                    Point p = new Point(x, y);
                    points_new.Add(p);
                }
            }

            int ind = 1;
            for(long i=0;i<points_new.Count;i++)
            {
                if (ind < points.Count)
                {
                    AddByIndex(ref points, ind, points_new[(int)i]);
                    ind += 2;
                }
            }

            for (int i = 0; i < points.Count-1; i++)
            {
                g.DrawLine(pen, points[(int)i], points[(int)(i + 1)]);
            }
        }
        
        private void AddByIndex(ref List<Point> lp, int ind,Point p)
        {
            lp.Add(p);
            int i = lp.Count - 1;
            while(i-1>=ind)
            {
                Point pp = lp[i-1];
                lp[i - 1] = lp[i];
                lp[i] = pp;
                i--;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            points.Clear();
            count = 0;
            drawingMode = false;

        }
    }
}
