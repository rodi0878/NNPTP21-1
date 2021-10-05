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

        private static void ColorizePixel(Bitmap bitmap, Color[] colors, int i, int j, float iteration, int rootIndex)
        {
            var color = colors[rootIndex % colors.Length];
            color = Color.FromArgb(
              Math.Min(Math.Max(0, color.R - (int)iteration * 2), 255),
              Math.Min(Math.Max(0, color.G - (int)iteration * 2), 255),
              Math.Min(Math.Max(0, color.B - (int)iteration * 2), 255));
            bitmap.SetPixel(j, i, color);
        }

        private static int FindRootIndex(List<ComplexNumber> roots, ref int maxid, ComplexNumber pixelWorldCoordinates)
        {
            var isRootIndexKnown = false;
            var id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(pixelWorldCoordinates.Re - roots[i].Re, 2) + Math.Pow(pixelWorldCoordinates.Im - roots[i].Im, 2) <= 0.01)
                {
                    isRootIndexKnown = true;
                    id = i;
                }
            }
            if (!isRootIndexKnown)
            {
                roots.Add(pixelWorldCoordinates);
                id = roots.Count;
                maxid = id + 1;
            }

            return id;
        }

        private static float FindSolutionsUsingNewtonIterationMethod(Polynome polynome, Polynome derivedPolynome, ref ComplexNumber pixelWorldCoordinates)
        {
            float iteration = 0;
            for (int i = 0; i < 30; i++)
            {
                var diff = polynome.Eval(pixelWorldCoordinates).Divide(derivedPolynome.Eval(pixelWorldCoordinates));
                pixelWorldCoordinates = pixelWorldCoordinates.Subtract(diff);

                if (Math.Pow(diff.Re, 2) + Math.Pow(diff.Im, 2) >= 0.5)
                {
                    i--;
                }
                iteration++;
            }

            return iteration;
        }

        private static ComplexNumber GetPointInWorldCoordinates(double xmin, double ymin, double xstep, double ystep, int i, int j)
        {
            double y = ymin + i * ystep;
            double x = xmin + j * xstep;

            ComplexNumber pixelWorldCoordinates = new ComplexNumber()
            {
                Re = x,
                Im = (float)(y)
            };

            if (pixelWorldCoordinates.Re == 0)
                pixelWorldCoordinates.Re = 0.0001;
            if (pixelWorldCoordinates.Im == 0)
                pixelWorldCoordinates.Im = 0.0001f;
            return pixelWorldCoordinates;
        }
    }
}
