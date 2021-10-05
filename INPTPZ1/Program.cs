using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    ///// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        static void Main(string[] args)
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

            List<ComplexNumber> koreny = new List<ComplexNumber>();
            // TODO: poly should be parameterised?
            Polynome p, pd;
            CreatePolynome(out p, out pd);

            Console.WriteLine(p);
            Console.WriteLine(pd);

            var clrs = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

            var maxid = 0;

            for (int i = 0; i < intargs[0]; i++)
            {
                for (int j = 0; j < intargs[1]; j++)
                {
                    ComplexNumber point = GetPointInWorldCoordinates(xmin, ymin, xstep, ystep, i, j);
                    float iterations = FindSolutionUsingNewtonIterationMethod(p, pd, ref point);
                    int index = FindRootIndex(koreny, ref maxid, point);
                    ColorizePixel(bmp, clrs, i, j, iterations, index);
                }
            }

            bmp.Save(output ?? "../../../out.png");
        }

        private static void CreatePolynome(out Polynome p, out Polynome pd)
        {
            p = new Polynome();
            p.Coefficients.Add(new ComplexNumber() { Re = 1 });
            p.Coefficients.Add(ComplexNumber.Zero);
            p.Coefficients.Add(ComplexNumber.Zero);
            //p.Coe.Add(Cplx.Zero);
            p.Coefficients.Add(new ComplexNumber() { Re = 1 });
            Polynome ptmp = p;
            pd = p.Derive();
        }

        private static void ColorizePixel(Bitmap bmp, Color[] clrs, int i, int j, float iterations, int index)
        {
            var color = clrs[index % clrs.Length];
            color = Color.FromArgb(
                Math.Min(Math.Max(0, color.R - (int)iterations * 2), 255),
                Math.Min(Math.Max(0, color.G - (int)iterations * 2), 255),
                Math.Min(Math.Max(0, color.B - (int)iterations * 2), 255));

            bmp.SetPixel(j, i, color);
        }

        private static int FindRootIndex(List<ComplexNumber> koreny, ref int maxid, ComplexNumber ox)
        {
            var known = false;
            var id = 0;
            for (int w = 0; w < koreny.Count; w++)
            {
                if (Math.Pow(ox.Re - koreny[w].Re, 2) + Math.Pow(ox.Im - koreny[w].Im, 2) <= 0.01)
                {
                    known = true;
                    id = w;
                }
            }
            if (!known)
            {
                koreny.Add(ox);
                id = koreny.Count;
                maxid = id + 1;
            }

            return id;
        }

        private static float FindSolutionUsingNewtonIterationMethod(Polynome p, Polynome pd, ref ComplexNumber ox)
        {
            float it = 0;
            for (int q = 0; q < 30; q++)
            {
                var diff = p.Eval(ox).Divide(pd.Eval(ox));
                ox = ox.Subtract(diff);

                //Console.WriteLine($"{q} {ox} -({diff})");
                if (Math.Pow(diff.Re, 2) + Math.Pow(diff.Im, 2) >= 0.5)
                {
                    q--;
                }
                it++;
            }

            return it;
        }

        private static ComplexNumber GetPointInWorldCoordinates(double xmin, double ymin, double xstep, double ystep, int i, int j)
        {
            double y = ymin + i * ystep;
            double x = xmin + j * xstep;

            ComplexNumber ox = new ComplexNumber()
            {
                Re = x,
                Im = y
            };

            if (ox.Re == 0)
                ox.Re = 0.0001;
            if (ox.Im == 0)
                ox.Im = 0.0001f;
            return ox;
        }
    }

}
