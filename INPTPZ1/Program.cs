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
            int[] imageDimensions = new int[2];
            for (int i = 0; i < imageDimensions.Length; i++)
            {
                imageDimensions[i] = int.Parse(args[i]);
            }
            double[] boundaryCoordinates = new double[4];
            for (int i = 0; i < boundaryCoordinates.Length; i++)
            {
                boundaryCoordinates[i] = double.Parse(args[i + 2]);
            }
            string outputPath = args[6];
            // TODO: add parameters from args?
            Bitmap bitmap = new Bitmap(imageDimensions[0], imageDimensions[1]);
            double xmin = boundaryCoordinates[0];
            double xmax = boundaryCoordinates[1];
            double ymin = boundaryCoordinates[2];
            double ymax = boundaryCoordinates[3];

            double xstep = (xmax - xmin) / imageDimensions[0];
            double ystep = (ymax - ymin) / imageDimensions[1];

            List<ComplexNumber> roots = new List<ComplexNumber>();
            // TODO: poly should be parameterised?
            Polynome polynome = new Polynome();
            Polynome derivedPolynome = CreatePolynome(polynome);

            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);

            var colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

            var maxid = 0;

            for (int i = 0; i < imageDimensions[0]; i++)
            {
                for (int j = 0; j < imageDimensions[1]; j++)
                {
                    ComplexNumber pixelWorldCoordinates = GetPointInWorldCoordinates(xmin, ymin, xstep, ystep, i, j);

                    float iteration = FindSolutionsUsingNewtonIterationMethod(polynome, derivedPolynome, ref pixelWorldCoordinates);

                    int rootIndex = FindRootIndex(roots, ref maxid, pixelWorldCoordinates);

                    ColorizePixel(bitmap, colors, i, j, iteration, rootIndex);
                }
            }

            bitmap.Save(outputPath ?? "../../../out.png");
        }

        private static Polynome CreatePolynome(Polynome p)
        {
            p.Coefficients.Add(new ComplexNumber() { Re = 1 });
            p.Coefficients.Add(ComplexNumber.Zero);
            p.Coefficients.Add(ComplexNumber.Zero);
            p.Coefficients.Add(new ComplexNumber() { Re = 1 });

            return p.Derive();
        }

        private static void ColorizePixel(Bitmap bmp, Color[] clrs, int i, int j, float it, int id)
        {
            var color = clrs[id % clrs.Length];
            color = Color.FromArgb(
              Math.Min(Math.Max(0, color.R - (int)it * 2), 255),
              Math.Min(Math.Max(0, color.G - (int)it * 2), 255),
              Math.Min(Math.Max(0, color.B - (int)it * 2), 255));
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

        private static float FindSolutionsUsingNewtonIterationMethod(Polynome p, Polynome pd, ref ComplexNumber ox)
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
                Im = (float)(y)
            };

            if (ox.Re == 0)
                ox.Re = 0.0001;
            if (ox.Im == 0)
                ox.Im = 0.0001f;
            return ox;
        }
    }
}
