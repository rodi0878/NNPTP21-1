using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1 {
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
      /*  static void Main(string[] args)
        {
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
            polynom.Coeficients.Add(new ComplexNumber(1,0));
            polynom.Coeficients.Add(ComplexNumber.Zero);
            polynom.Coeficients.Add(ComplexNumber.Zero);
            //p.Coe.Add(Cplx.Zero);
            polynom.Coeficients.Add(new ComplexNumber(1,0));
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
                    //TOM ox - name
                    ComplexNumber root = new ComplexNumber(x, y);
   

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
                        var diff = polynom.Evaluate(root).Divide(derivatedPolynom.Evaluate(root));
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
