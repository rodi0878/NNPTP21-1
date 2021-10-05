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
        private static readonly int ImageWidthIndex = 0;
        private static readonly int ImageHeightIndex = 1;
        private static readonly int XMinIndex = 0;
        private static readonly int XMaxIndex = 1;        
        private static readonly int YMinIndex = 2;
        private static readonly int YMaxIndex = 3;
        private static readonly int OutputPathIndex = 6;
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
            string outputPath = args[OutputPathIndex];
            // TODO: add parameters from args?
            Bitmap bitmap = new Bitmap(imageDimensions[ImageWidthIndex], imageDimensions[ImageHeightIndex]);
            double xmin = boundaryCoordinates[XMinIndex];
            double xmax = boundaryCoordinates[XMaxIndex];
            double ymin = boundaryCoordinates[YMinIndex];
            double ymax = boundaryCoordinates[YMaxIndex];

            double xstep = (xmax - xmin) / imageDimensions[ImageWidthIndex];
            double ystep = (ymax - ymin) / imageDimensions[ImageHeightIndex];

            // TODO: poly should be parameterised?
            Polynome polynome = new Polynome();
            Polynome derivedPolynome = CreatePolynome(polynome);

            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);

            var colors = new Color[]
            {
                Color.Red, 
                Color.Blue, 
                Color.Green, 
                Color.Yellow, 
                Color.Orange, 
                Color.Fuchsia, 
                Color.Gold, 
                Color.Cyan, 
                Color.Magenta
            };

            List<ComplexNumber> roots = new List<ComplexNumber>();

            for (int i = 0; i < imageDimensions[ImageWidthIndex]; i++)
            {
                for (int j = 0; j < imageDimensions[ImageHeightIndex]; j++)
                {
                    ComplexNumber pixelWorldCoordinates = GetPointInWorldCoordinates(xmin, ymin, xstep, ystep, i, j);

                    float iteration = FindSolutionsUsingNewtonIterationMethod(polynome, derivedPolynome, ref pixelWorldCoordinates);

                    int rootIndex = FindRootIndex(roots, pixelWorldCoordinates);

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

        private static void ColorizePixel(Bitmap bitmap, Color[] colors, int x, int y, float iteration, int rootIndex)
        {
            var color = colors[rootIndex % colors.Length];
            color = Color.FromArgb(
              Math.Min(Math.Max(0, color.R - (int)iteration * 2), 255),
              Math.Min(Math.Max(0, color.G - (int)iteration * 2), 255),
              Math.Min(Math.Max(0, color.B - (int)iteration * 2), 255));
            bitmap.SetPixel(y, x, color);
        }

        private static int FindRootIndex(List<ComplexNumber> roots, ComplexNumber pixelWorldCoordinates)
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
                Im = y
            };

            if (pixelWorldCoordinates.Re == 0)
                pixelWorldCoordinates.Re = 0.0001;
            if (pixelWorldCoordinates.Im == 0)
                pixelWorldCoordinates.Im = 0.0001f;
            return pixelWorldCoordinates;
        }
    }
}
