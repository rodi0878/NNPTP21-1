using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1 {

    class NewtonFractal
    {

        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }

        public double xstep { get; }
        public double ystep { get; }

        public int height { get; set; }
        public int width { get; set; }

        private Bitmap bitmap;


        Polynom polynom { get; set; }
        Polynom derivatedPolynom { get; set; }

        public Color[] colors = new Color[]
             {
                 Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
    };

    List<ComplexNumber> roots;

        public NewtonFractal(double minX, double maxX, double minY, double maxY, int width, int height) {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
            this.height = height;
            this.width = width;
            roots = new List<ComplexNumber>();
            xstep= (MaxX - MinX) / width;
            ystep = (MaxY - MinY) / height;
            polynom = new Polynom();
            derivatedPolynom = polynom.Derive();

            bitmap =new Bitmap(width, height);
            roots = new List<ComplexNumber>();
        }
        public void Add(ComplexNumber complexNumber) {
            this.polynom.Coeficients.Add(complexNumber);
        }

        static void Main(string[] args) {
            NewtonFractal fractal = new NewtonFractal(-0.02, 0.02, -0.02, 0.02, 100, 100);

            fractal.Add(new ComplexNumber(1, 0));
            fractal.Add(ComplexNumber.Zero);
            fractal.Add(ComplexNumber.Zero);
            fractal.Add(new ComplexNumber(1, 0));

            for (int i = 0; i < fractal.width; i++) {
                for (int j = 0; j < fractal.height; j++) {

                }
            }
            /*
             int[] intargs = new int[2];
             for (int i = 0; i < intargs.Length; i++)
             {
                 intargs[i] = int.Parse(args[i]);
             }
             double[] doubleargs = new double[4];
             for (int i = 0; i < doubleargs.Length; i++)
             {
                 doubleargs[i] = double.Parse(args[i + 2]);
             }
             string output = args[6];
             // TODO: add parameters from args?
             Bitmap bmp = new Bitmap(intargs[0], intargs[1]);
             double xmin = doubleargs[0];
             double xmax = doubleargs[1];
             double ymin = doubleargs[2];
             double ymax = doubleargs[3];

             double xstep = (xmax - xmin) / intargs[0];
             double ystep = (ymax - ymin) / intargs[1];

             List<ComplexNumber> roots = new List<ComplexNumber>();
             // TODO: poly should be parameterised?
             Polynom polynom = new Polynom();
             polynom.Coeficient.Add(new ComplexNumber() { Re = 1 });
             polynom.Coeficient.Add(ComplexNumber.Zero);
             polynom.Coeficient.Add(ComplexNumber.Zero);
             polynom.Coeficient.Add(new ComplexNumber() { Re = 1 });
             Polynom derivatedPolynom = polynom.Derive();

             Console.WriteLine(polynom);
             Console.WriteLine(derivatedPolynom);
             Console.WriteLine(xstep);

             var colors = new Color[]
             {
                 Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
             };


             // TODO: cleanup!!!
             // for every pixel in image...
             for (int i = 0; i < intargs[0]; i++)
             {
                 for (int j = 0; j < intargs[1]; j++)
                 {
                     // find "world" coordinates of pixel
                     double y = ymin + i * ystep;
                     double x = xmin + j * xstep;
                     //ox - name
                     ComplexNumber root = new ComplexNumber()
                     {
                         Re = x,
                         Im = y
                     };

                     if (root.Re == 0)
                         root.Re = 0.0001;
                     if (root.Im == 0)
                         root.Im = 0.0001f;

                     //Console.WriteLine(ox);

                     // find solution of equation using newton's iteration
                     float it = 0;
                     //TOM minCountIt
                     for (int k = 0; k< 30; k++)
                     {
                         var diff = polynom.Eval(root).Divide(derivatedPolynom.Eval(root));
                         root = root.Subtract(diff);

                         if (Math.Pow(diff.Re, 2) + Math.Pow(diff.Im, 2) >= 0.5)
                         {
                             k--;
                         }
                         it++;
                     }


                     // find solution root number
                     var known = false;
                     var id = 0;
                     for (int w = 0; w <roots.Count;w++)
                     {
                         if (Math.Pow(root.Re- roots[w].Re, 2) + Math.Pow(root.Im - roots[w].Im, 2) <= 0.01)
                         {
                             known = true;
                             id = w;
                         }
                     }
                     if (!known)
                     {
                         roots.Add(root);
                         id = roots.Count;
                     }

                     // colorize pixel according to root number
                     var vv = colors[id % colors.Length];
                  //TOM   vv = Color.FromArgb(vv.R, vv.G, vv.B);
                    // vv = Color.FromArgb(Math.Min(Math.Max(0, vv.R-(int)it*2), 255), Math.Min(Math.Max(0, vv.G - (int)it*2), 255), Math.Min(Math.Max(0, vv.B - (int)it*2), 255));
                     bmp.SetPixel(j, i, vv);
                 }
             }

                     bmp.Save(output ?? "../../../out.png");
         }*/
        }
    }
