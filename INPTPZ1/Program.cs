using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArgs = new int[2];
            for (int i = 0; i < intArgs.Length; i++)
            {
                intArgs[i] = int.Parse(args[i]);
            }
            double[] doubleArgs = new double[4];
            for (int i = 0; i < doubleArgs.Length; i++)
            {
                doubleArgs[i] = double.Parse(args[i + 2]);
            }
            string output = args[6];
            // TODO: add parameters from args?
            Bitmap bmp = new Bitmap(intArgs[0], intArgs[1]);
            double xMin = doubleArgs[0];
            double xMax = doubleArgs[1];
            double yMin = doubleArgs[2];
            double yMax = doubleArgs[3];

            double xStep = (xMax - xMin) / intArgs[0];
            double yStep = (yMax - yMin) / intArgs[1];

            List<ComplexNumber> roots = new List<ComplexNumber>();
            // TODO: poly should be parameterised?
            Polynomial polynomial = new Polynomial();
            polynomial.AddCoefficient(new ComplexNumber() { RealPart = 1 });
            polynomial.AddCoefficient(ComplexNumber.Zero);
            polynomial.AddCoefficient(ComplexNumber.Zero);
            //p.Coe.Add(Cplx.Zero);
            polynomial.AddCoefficient(new ComplexNumber() { RealPart = 1 });
            Polynomial polynomialDerivation = polynomial.Derive();

            Console.WriteLine(polynomial);
            Console.WriteLine(polynomialDerivation);

            var colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

            var maxId = 0;

            // TODO: cleanup!!!
            // for every pixel in image...
            for (int i = 0; i < intArgs[0]; i++)
            {
                for (int j = 0; j < intArgs[1]; j++)
                {
                    // find "world" coordinates of pixel
                    double y = yMin + i * yStep;
                    double x = xMin + j * xStep;

                    ComplexNumber ox = new ComplexNumber()
                    {
                        RealPart = x,
                        ImaginaryPart = (float)(y)
                    };

                    if (ox.RealPart == 0)
                        ox.RealPart = 0.0001;
                    if (ox.ImaginaryPart == 0)
                        ox.ImaginaryPart = 0.0001f;

                    //Console.WriteLine(ox);

                    // find solution of equation using newton's iteration
                    float it = 0;
                    for (int k = 0; k< 30; k++)
                    {
                        var diff = polynomial.Evaluate(ox).Divide(polynomialDerivation.Evaluate(ox));
                        ox = ox.Subtract(diff);

                        //Console.WriteLine($"{q} {ox} -({diff})");
                        if (Math.Pow(diff.RealPart, 2) + Math.Pow(diff.ImaginaryPart, 2) >= 0.5)
                        {
                            k--;
                        }
                        it++;
                    }

                    //Console.ReadKey();

                    // find solution root number
                    var known = false;
                    var id = 0;
                    for (int w = 0; w <roots.Count;w++)
                    {
                        if (Math.Pow(ox.RealPart- roots[w].RealPart, 2) + Math.Pow(ox.ImaginaryPart - roots[w].ImaginaryPart, 2) <= 0.01)
                        {
                            known = true;
                            id = w;
                        }
                    }
                    if (!known)
                    {
                        roots.Add(ox);
                        id = roots.Count;
                        maxId = id + 1; 
                    }

                    // colorize pixel according to root number
                    //int vv = id;
                    //int vv = id * 50 + (int)it*5;
                    var vv = colors[id % colors.Length];
                    vv = Color.FromArgb(vv.R, vv.G, vv.B);
                    vv = Color.FromArgb(Math.Min(Math.Max(0, vv.R-(int)it*2), 255), Math.Min(Math.Max(0, vv.G - (int)it*2), 255), Math.Min(Math.Max(0, vv.B - (int)it*2), 255));
                    //vv = Math.Min(Math.Max(0, vv), 255);
                    bmp.SetPixel(j, i, vv);
                    //bmp.SetPixel(j, i, Color.FromArgb(vv, vv, vv));
                }
            }

            // TODO: delete I suppose...
            //for (int i = 0; i < 300; i++)
            //{
            //    for (int j = 0; j < 300; j++)
            //    {
            //        Color c = bmp.GetPixel(j, i);
            //        int nv = (int)Math.Floor(c.R * (255.0 / maxid));
            //        bmp.SetPixel(j, i, Color.FromArgb(nv, nv, nv));
            //    }
            //}

                    bmp.Save(output ?? "../../../out.png");
            //Console.ReadKey();
        }
    }
}
