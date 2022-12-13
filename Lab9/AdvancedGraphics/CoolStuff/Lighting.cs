using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsHelper
{
    using FastBitmap;
    //для реализации освещения по модели Ламберта 
    class Lighting
    {
        //Вычислить цвет в каждой вершине по модели Ламберта (рассеянную часть).
        //Закрасить грань, интерполируя цвет между цветами вершин(билинейная интерполяция).
        //Добавить возможность применения аффинных преобразований к объекту.
        /// <summary>
        /// Получить значение освещенности в вершине
        /// </summary>
        /// <param name="v">Вершина</param>
        /// <param name="light">Источник освещения</param>
        
        public static  double GetLightness(Vertex v, AdvancedGraphics.CoolStuff.LightSource light)
        {
            var normv = v.normVector;
            var raytovertex = new Vector(v.Xf - light.Position.Xf, v.Yf - light.Position.Yf, v.Zf - light.Position.Zf);
            //
            //cos α = a·b/
            //|a |·| b |
            double cos =Math.Max( Vector.GetCos(normv, raytovertex),0.0);
            //добавить max(cos,0)
            return cos;
        }
        //Имеется также простая зависимость между силой света, излучаемого плоской рассеивающей площадкой {\displaystyle dS}dS в каком-либо направлении, от угла {\displaystyle \alpha }\alpha  между этим направлением и перпендикуляром к {\displaystyle dS}dS:
        //Ia=I0*cosa
        /// <summary>
        /// Алгоритм 
        /// </summary>
        /// <param name="lightness">Освещение</param>
        /// <param name="c"></param>

        public static double GetIntense(double lightness)
        {
            return (lightness+1) /2;//у Яны в презентации (1+cos)/2
            //return lightness*0.3*0.7;//что-то интуитивные коэффициенты не помогают

        }
        //вектор нормали к вершине считается как сумма векторов нормалей прилежащих к этой вершине граней, поделенная на количество этих граней
        /// <summary>
        /// Считает вектор нормали к вершине
        /// </summary>
        /// <param name="faces">Список граней, которым принадлежит эта вершина</param>
        /// <param name="s">Фигура</param>
       
        public static Vector NormalVertex(List<Face> faces, Shape s)
        {
            Vector res=new Vector(0,0,0);
            foreach (var face in faces)
            {
                res.Xf += face.NormVector.Xf;
                res.Yf += face.NormVector.Yf;
                res.Zf += face.NormVector.Zf;
            }
            res.Xf = res.Xf / faces.Count();
            res.Yf = res.Yf / faces.Count();
            res.Zf = res.Zf / faces.Count();
            return res;
        }
        /// <summary>
        /// Для каждой вершины считает освещенность по методу Ламберта, пересчитывает нормали(что-то у нас с obj нормалями не то)
        /// </summary>
        /// <param name="s">Фигура</param>
        /// <param name="light">Источник освещения</param>
      
        public static void CalculateLambert(Shape s,AdvancedGraphics.CoolStuff.LightSource light)
        {
            Dictionary<Vertex, Vector> normales = new Dictionary<Vertex, Vector>();
            for (int i = 0; i < s.Faces.Count; i++)
            {
                Face f = s.Faces[i];
                foreach (var vert in f.Vertices)
                {
                    List<Face> faces = s.Faces.Where(x => x.Vertices.Contains(vert)).ToList();//все грани, содержащие данную вершину
                    vert.normVector = NormalVertex(faces, s);
                   // normales.Add(vert, NormalVertex(faces, s));
                }

               // List<Face> neededFaces = s.Faces.Where(x => x.Contains(i)).ToList();
               // pointNormal.Add(i, Vectors.CalculateNormal(neededFaces, polyhedron));
            }

            //посчитать вектор нормали для каждой вершины
            foreach (var f in s.Faces)
            {
                //посчитать яркость в каждой вершине многоугольника
                foreach (var vert in f.Vertices)
                {
                    double lamb = GetLightness(vert, light);
                    double intense = GetIntense(lamb);
                    vert.lightness = intense;
                }
            }
        }
        //public static void CalculateLambertFigure(Shape s, AdvancedGraphics.CoolStuff.LightSource light)
        //{
        //считаем для каждой грани
        // foreach (var face in s.Faces)
        // {
        //для каждой вершины грани
        //   CalculateLambert(s, s.GetColor, light);
        //}
        //}
        /// <summary>
        /// Алгоритм освещения по Гуро(цвет считается в вершинах и интерполируется)
        /// </summary>
        /// <param name="width">Ширина канваса</param>
        /// <param name="height">Высота канваса</param>
        /// <param name="scene">Множество фигур на сцене</param>
        /// <param name="light">Источник освещения</param>
        /// <param name="color">Цвет</param>
        /// <param name="camera">Камера</param>
        public static Bitmap Method_Guro(int width, int height, List<Shape> scene, AdvancedGraphics.CoolStuff.LightSource light, Color color,Camera camera)
        {
           foreach (var shape in scene)
            {
               
                CalculateLambert(shape, light);
            }  
       
            bool mode = true;
            Bitmap canvas = new Bitmap(width, height);
            //new FastBitmap(bitmap);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    canvas.SetPixel(i, j, Color.White);//new System.Drawing.Point(i, j)
           
            //z-буфер
            double[,] zbuffer = new double[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuffer[i, j] = double.MaxValue; //Изначально, буфер
            // инициализируется значением z = zmax
           List< List<List<Point>>> rasterscene = new List<List<List<Point>>>();
            for (int i = 0; i < scene.Count(); i++)
            {
                rasterscene.Add(GraphicsHelper.Z_buffer.RasterFigure(scene[i], camera, mode)); //растеризовали все фигуры
            }
            //rasterscene =GraphicsHelper.Z_buffer.RasterFigure(shape, camera,mode); //растеризовали все фигуры
            int withmiddle = width / 2;
            int heightmiddle = height / 2;
            //int index = 0;
            for (int i = 0; i < rasterscene.Count(); i++)
            {
                Color color1 = scene[i].GetColor;
                for (int j = 0; j < rasterscene[i].Count(); j++)
                {
                    List<Point> current = rasterscene[i][j]; //это типа грань но уже растеризованная

                   // Color c1 = scene[j].GetColor;
                    foreach (Point p in current)
                    {
                        int x = (int)(p.X); //

                        int y = (int)(p.Y); // + heightmiddle 

                        if (x < width && y < height && y > 0 && x > 0)
                        {
                            if (p.Zf < zbuffer[x, y])
                            {
                                zbuffer[x, y] = p.Zf;
                                canvas.SetPixel(x, y, Color.FromArgb((int)(p.lightness * color1.R), (int)(p.lightness * color1.G), (int)(p.lightness * color1.B))); //canvas.Height - 
                            }
                        }
                    }

                    //index++;

                }
            }

            return canvas;
           
        }
    }

}