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
    public class Program
    {
        private const double FIND_ROOT_INDEX_ACCURACY = 0.01;
        private const string DEFAULT_IMAGE_FILENAME = "../../../out.png";
        private const double FIND_ROOT_ACCURACY = 0.5;
        private const int NEWTON_ITERATION_THRESHOLD = 30;
        private const double ZERO_IN_WORLD_COORDINATES = 0.0001;
        private readonly static Color[] COLOURS = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

        static void Main(string[] args)
        {
            int imageWidth = int.Parse(args[0]);
            int imageHeight = int.Parse(args[1]);
            double[] doubleArguments = new double[4];
            for (int i = 0; i < doubleArguments.Length; i++)
            {
                doubleArguments[i] = double.Parse(args[i + 2]);
            }
            string filename = args[6];
            double xmin = doubleArguments[0];
            double xmax = doubleArguments[1];
            double ymin = doubleArguments[2];
            double ymax = doubleArguments[3];
            double xstep = (xmax - xmin) / imageWidth;
            double ystep = (ymax - ymin) / imageHeight;

            Bitmap bitmapImage = new Bitmap(imageWidth, imageHeight);
            List<ComplexNumber> roots = new List<ComplexNumber>();
            Polynomial polynomial = new Polynomial(new ComplexNumber() { Re = 1 }, ComplexNumber.ZERO, ComplexNumber.ZERO, new ComplexNumber() { Re = 1 });
            Polynomial polynomialDerived = polynomial.Derive();

            Console.WriteLine(polynomial);
            Console.WriteLine(polynomialDerived);

            for (int i = 0; i < imageWidth; i++)
            {
                for (int j = 0; j < imageHeight; j++)
                {
                    ComplexNumber pixelInWorldCoordinates = GetPointInWorldCoordinates(xmin, ymin, xstep, ystep, i, j);
                    int iteration = FindSolutionUsingNewtonIterationMethod(polynomial, polynomialDerived, ref pixelInWorldCoordinates);
                    int index = FindRootIndex(roots, pixelInWorldCoordinates);
                    ColorizePixel(bitmapImage, i, j, iteration, index);
                }
            }
            bitmapImage.Save(filename ?? DEFAULT_IMAGE_FILENAME);
        }

        private static int FindRootIndex(List<ComplexNumber> roots, ComplexNumber pixelInWorldCoordinates)
        {
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(pixelInWorldCoordinates.Re - roots[i].Re, 2) + Math.Pow(pixelInWorldCoordinates.Im - roots[i].Im, 2) <= FIND_ROOT_INDEX_ACCURACY)
                {
                    return i;
                }
            }
            roots.Add(pixelInWorldCoordinates);
            return roots.Count;
        }

        private static void ColorizePixel(Bitmap bitmapImage, int i, int j, int iterationCount, int index)
        {
            Color color = COLOURS[index % COLOURS.Length];
            color = Color.FromArgb(
                Math.Min(Math.Max(0, color.R - (int)iterationCount * 2), 255),
                Math.Min(Math.Max(0, color.G - (int)iterationCount * 2), 255),
                Math.Min(Math.Max(0, color.B - (int)iterationCount * 2), 255));
            bitmapImage.SetPixel(j, i, color);
        }

        private static int FindSolutionUsingNewtonIterationMethod(Polynomial polynomial, Polynomial polynomialDerived, ref ComplexNumber pixelInWorldCoordinates)
        {
            int iterationCount = 0;
            for (int i = 0; i < NEWTON_ITERATION_THRESHOLD; i++)
            {
                ComplexNumber differentiable = polynomial.EvaluateAtPointX(pixelInWorldCoordinates).Divide(polynomialDerived.EvaluateAtPointX(pixelInWorldCoordinates));
                pixelInWorldCoordinates = pixelInWorldCoordinates.Subtract(differentiable);

                if (Math.Pow(differentiable.Re, 2) + Math.Pow(differentiable.Im, 2) >= FIND_ROOT_ACCURACY)
                    i--;
                iterationCount++;
            }

            return iterationCount;
        }

        private static ComplexNumber GetPointInWorldCoordinates(double xmin, double ymin, double xstep, double ystep, int i, int j)
        {
            ComplexNumber pointInWorldCoordinates = new ComplexNumber()
            {
                Re = xmin + j * xstep,
                Im = ymin + i * ystep
            };

            if (pointInWorldCoordinates.Re == 0)
                pointInWorldCoordinates.Re = ZERO_IN_WORLD_COORDINATES;
            if (pointInWorldCoordinates.Im == 0)
                pointInWorldCoordinates.Im = ZERO_IN_WORLD_COORDINATES;
            return pointInWorldCoordinates;
        }
    }
}
