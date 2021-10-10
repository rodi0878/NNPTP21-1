using System;
using System.Collections.Generic;
using System.Drawing;
using Mathematics;

namespace INPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        static void Main(string[] args) //resolutionX, resolutionY, xMin, xMax, yMin, yMax, OutputString
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
            Bitmap bitmap = new Bitmap(intargs[0], intargs[1]);
            double xmin = doubleargs[0];
            double xmax = doubleargs[1];
            double ymin = doubleargs[2];
            double ymax = doubleargs[3];

            double xstep = (xmax - xmin) / intargs[0];
            double ystep = (ymax - ymin) / intargs[1];

            List<ComplexNumber> roots = new List<ComplexNumber>();
            // TODO: poly should be parameterised?
            Polynomial p = new Polynomial();
            p.CompleNumbersList.Add(new ComplexNumber() { RealPart = 1 });
            p.CompleNumbersList.Add(ComplexNumber.Zero);
            p.CompleNumbersList.Add(ComplexNumber.Zero);
            p.CompleNumbersList.Add(new ComplexNumber() { RealPart = 1 });
            Polynomial pd = p.Derive();

            Console.WriteLine(p);
            Console.WriteLine(pd);

            Color[] colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

            int maxid = 0;

            // TODO: cleanup!!!
            // for every pixel in image...
            for (int i = 0; i < intargs[0]; i++)
            {
                for (int j = 0; j < intargs[1]; j++)
                {
                    // find "world" coordinates of pixel
                    double y = ymin + i * ystep;
                    double x = xmin + j * xstep;

                    ComplexNumber complexNumber = new ComplexNumber()
                    {
                        RealPart = x,
                        ImaginaryPart = y
                    };

                    if (complexNumber.RealPart == 0)
                        complexNumber.RealPart = 0.0001;
                    if (complexNumber.ImaginaryPart == 0)
                        complexNumber.ImaginaryPart = 0.0001f;


                    // find solution of equation using newton's iteration
                    int iteration = 0;
                    for (int q = 0; q < 30; q++)
                    {
                        ComplexNumber diff = p.Evaluate(complexNumber).Divide(pd.Evaluate(complexNumber));
                        complexNumber = complexNumber.Subtract(diff);

                        if (Math.Pow(diff.RealPart, 2) + Math.Pow(diff.ImaginaryPart, 2) >= 0.5)
                        {
                            q--;
                        }
                        iteration++;
                    }

                    // find solution root number
                    bool known = false;
                    int id = 0;
                    for (int w = 0; w < roots.Count; w++)
                    {
                        if (Math.Pow(complexNumber.RealPart - roots[w].RealPart, 2) + Math.Pow(complexNumber.ImaginaryPart - roots[w].ImaginaryPart, 2) <= 0.01)
                        {
                            known = true;
                            id = w;
                        }
                    }
                    if (!known)
                    {
                        roots.Add(complexNumber);
                        id = roots.Count;
                        maxid = id + 1;
                    }

                    // colorize pixel according to root number
                    Color color = colors[id % colors.Length];
                    color = Color.FromArgb(Math.Min(Math.Max(0, color.R - (int)iteration * 2), 255),
                                        Math.Min(Math.Max(0, color.G - (int)iteration * 2), 255),
                                        Math.Min(Math.Max(0, color.B - (int)iteration * 2), 255));
                    bitmap.SetPixel(j, i, color);
                }
            }
            bitmap.Save(output ?? "../../../out.png");
        }
    }
}
