using GraphicsHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdvancedGraphics.CoolStuff;
using Point = GraphicsHelper.Point;

namespace AdvancedGraphics
{
    public partial class Form1 : Form
    {
        BindingList<Shape> sceneShapes;
        List<Shape> scene;
        bool isMoving = false;
        bool pruneNonFacial = false;
        Camera camera;
        LightSource lightSource;
        List<Color> colorrange;
        Shape shapeWithoutNonFacial; // фигура без нелицевых граней
        bool isPruningFaces = false;
        bool is_lighting;
        public Form1()
        {
            sceneShapes = new BindingList<Shape>();
            colorrange = GenerateColors();
            //colorrange = new List<Color> { Color.Red, Color.Blue, Color.Green };
            scene = new List<Shape>();
            InitializeComponent();
            listBox.DataSource = sceneShapes;
            canvas.Image = new Bitmap(canvas.Width, canvas.Height);
            camera = new Camera();
            // lightSource = new LightSource(new Point(100, 100, 100));
            lightSource = new LightSource(new Point(100, 100, 100));
          
            // А здесь задаём точку начала координат
            Point.worldCenter = new PointF(canvas.Width / 2, canvas.Height / 2);
            Point.projection = ProjectionType.PERSPECTIVE;
            Point.setProjection(canvas.Size, 1, 100, 45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new FormPlotting();
            form.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Shape s = Shape.readShape(openFileDialog1.FileName);
                sceneShapes.Add(s);
                s.SetColor(colorrange[sceneShapes.Count() - 1]);
                scene.Add(s);
                changeToolsAccessibility(true);
                redrawScene();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sceneShapes.Remove((Shape) listBox.SelectedValue);
            if (sceneShapes.Count == 0)
            {
                changeToolsAccessibility(false);
            }

            redrawScene();
        }

        void changeToolsAccessibility(bool isOn)
        {
            btnDelete.Enabled = isOn;
            textShiftX.Enabled = isOn;
            textShiftY.Enabled = isOn;
            textShiftZ.Enabled = isOn;
            buttonShift.Enabled = isOn;
            btnShowAxis.Enabled = isOn;
            textScaleX.Enabled = isOn;
            textScaleY.Enabled = isOn;
            textScaleZ.Enabled = isOn;
            textAngle.Enabled = isOn;
            selectAxis.Enabled = isOn;
            buttonScale.Enabled = isOn;
            buttonRotate.Enabled = isOn;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            redrawScene();
        }

        private void rbParallel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPerspective.Checked)
            {
                Point.projection = ProjectionType.PERSPECTIVE;
            }
            else
            {
                Point.projection = ProjectionType.TRIMETRIC;
            }

            redrawScene();
        }

        private void buttonShift_Click(object sender, EventArgs e)
        {
            sceneShapes[listBox.SelectedIndex] = AffineTransformations.shift(sceneShapes[listBox.SelectedIndex],
                int.Parse(textShiftX.Text), int.Parse(textShiftY.Text), int.Parse(textShiftZ.Text));
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    camera.move(forwardbackward: 5);
                    break;
                case 'a':
                    camera.move(leftright: 5);
                    break;
                case 's':
                    camera.move(forwardbackward: -5);
                    break;
                case 'd':
                    camera.move(leftright: -5);
                    break;
                case 'q':
                    camera.move(updown: 5);
                    break;
                case 'e':
                    camera.move(updown: -5);
                    break;
                case 'i':
                    camera.changeView(shiftY: 2);
                    break;
                case 'j':
                    camera.changeView(shiftX: -2);
                    break;
                case 'k':
                    camera.changeView(shiftY: -2);
                    break;
                case 'l':
                    camera.changeView(shiftX: 2);
                    break;
                case 'g':
                    lightSource.move(shiftY: 5);
                    break;
                case 'b':
                    lightSource.move(shiftY: -5);
                    break;
                case 'v':
                    lightSource.move(shiftX: -5);
                    break;
                case 'n':
                    lightSource.move(shiftX: 5);
                    break;
                case 'f':
                    lightSource.move(shiftZ: -5);
                    break;
                case 'h':
                    lightSource.move(shiftZ: 5);
                    break;
                default: return;
            }

            recalculateNonFacial();
            redrawScene();

            //label7.Text = $"{camera.Location}";
            e.Handled = true;
        }

        private void z_buffer_Click(object sender, EventArgs e)
        {
            is_lighting = false;
            List<Shape> l = sceneShapes.ToList();
            Bitmap bmp = Z_buffer.z_buf(canvas.Width, canvas.Height, l, camera,lightSource, colorrange,is_lighting);
            canvas.Image = bmp;
            canvas.Invalidate();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            sceneShapes[listBox.SelectedIndex] = AffineTransformations.rotate(sceneShapes[listBox.SelectedIndex],(AxisType)selectAxis.SelectedIndex, double.Parse(textAngle.Text, CultureInfo.InvariantCulture.NumberFormat));
            
        }

        private void buttonScale_Click(object sender, EventArgs e)
        {
            sceneShapes[listBox.SelectedIndex] = AffineTransformations.scale(sceneShapes[listBox.SelectedIndex],
                double.Parse(textScaleX.Text, CultureInfo.InvariantCulture.NumberFormat), double.Parse(textScaleY.Text, CultureInfo.InvariantCulture.NumberFormat), double.Parse(textScaleZ.Text, CultureInfo.InvariantCulture.NumberFormat));
        }

        string textureFileName = "";
        private void buttonLoadTexture_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textureFileName = openFileDialog2.FileName;
            }
        }

        private void buttonLighting_Click(object sender, EventArgs e)
        {
            //sceneShapes[0].SetColor(Color.Red);
            is_lighting = true;
            List<Shape> l = sceneShapes.ToList();
            //Bitmap bmp = Lighting.Method_Guro(canvas.Width, canvas.Height,l, lightSource, sceneShapes[0].GetColor, camera);
            Bitmap bmp = Z_buffer.z_buf(canvas.Width, canvas.Height, l, camera, lightSource, colorrange, is_lighting);
            canvas.Image = bmp;
            canvas.Invalidate();
            is_lighting = false;
            //redrawScene();
        }

        private void buttonTexturing_Click(object sender, EventArgs e)
        {
            List<Shape> l = sceneShapes.ToList();
            Bitmap bmp = Z_buffer_texturing.z_buf(canvas.Width, canvas.Height, l, camera, lightSource, colorrange, false,textureFileName);
            canvas.Image = bmp;
            canvas.Invalidate();
        }
    }
}