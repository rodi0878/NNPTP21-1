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
        private static readonly double ROOT_FINDING_ACCURACY = 0.5;
        private static readonly double ACCURACY_OF_ROOT_EQUALITY = 0.01;
        private static readonly int MAXIMUM_ITERATIONS_IN_NEWTONS_METHOD = 30;
        private static readonly double NUMBER_CLOSE_TO_ZERO = 0.0001;

        static void Main(string[] args)
        {
            int[] intargs;
            double[] doubleargs;
            string output;
            CategorizeArguments(args, out intargs, out doubleargs, out output);

            Bitmap bitmap = new Bitmap(intargs[0], intargs[1]);
            double xMin = doubleargs[0];
            double xMax = doubleargs[1];
            double yMin = doubleargs[2];
            double yMax = doubleargs[3];

            double xStep = (xMax - xMin) / bitmap.Width;
            double yStep = (yMax - yMin) / bitmap.Height;

            RenderNewtonFractal(bitmap, xMin, yMin, xStep, yStep);

            bitmap.Save(output ?? "../../../out.png");
        }

        private static void CategorizeArguments(string[] args, out int[] intargs, out double[] doubleargs, out string output)
        {
            intargs = new int[2];
            for (int i = 0; i < intargs.Length; i++)
            {
                intargs[i] = int.Parse(args[i]);
            }

            doubleargs = new double[4];
            for (int i = 0; i < doubleargs.Length; i++)
            {
                doubleargs[i] = double.Parse(args[i + 2]);
            }

            output = args[6];
        }

        private static void RenderNewtonFractal(Bitmap bitmap, double xMin, double yMin, double xStep, double yStep)
        {
            List<ComplexNumber> roots = new List<ComplexNumber>();

            Polynomial polynomial, derivativePolynomial;
            CreatePolynome(out polynomial);
            derivativePolynomial = polynomial.Derive();

            Console.WriteLine(polynomial);
            Console.WriteLine(derivativePolynomial);

            for (int yPosition = 0; yPosition < bitmap.Width; yPosition++)
            {
                for (int xPosition = 0; xPosition < bitmap.Height; xPosition++)
                {
                    ComplexNumber pixelCoordinates = GetPointInWorldCoordinates(xMin, yMin, xStep, yStep, yPosition, xPosition);

                    int numberOfIterations = GetNumberOfIterationInNewtonMethod(polynomial, derivativePolynomial, ref pixelCoordinates);

                    int rootNumberId = FindRootNumberIndex(roots, pixelCoordinates);

                    ColorizePixel(bitmap, xPosition, yPosition, numberOfIterations, rootNumberId);
                }
            }
        }

        private static int GetNumberOfIterationInNewtonMethod(Polynomial polynomial, Polynomial derivativePolynomial, ref ComplexNumber pixelCoordinates)
        {
            int numberOfIterations = 0;
            for (int i = 0; i < MAXIMUM_ITERATIONS_IN_NEWTONS_METHOD; i++)
            {
                ComplexNumber difference = polynomial.Evaluate(pixelCoordinates).Divide(derivativePolynomial.Evaluate(pixelCoordinates));
                pixelCoordinates = pixelCoordinates.Subtract(difference);

                if (Math.Pow(difference.Re, 2) + Math.Pow(difference.Im, 2) >= ROOT_FINDING_ACCURACY)
                {
                    i--;
                }
                numberOfIterations++;
            }

            return numberOfIterations;
        }

        private static ComplexNumber GetPointInWorldCoordinates(double xMin, double yMin, double xStep, double yStep, int yPosition, int xPosition)
        {
            double y = yMin + yPosition * yStep;
            double x = xMin + xPosition * xStep;

            ComplexNumber pixelCoordinates = new ComplexNumber()
            {
                Re = x,
                Im = y
            };

            if (pixelCoordinates.Re == 0)
                pixelCoordinates.Re = NUMBER_CLOSE_TO_ZERO;
            if (pixelCoordinates.Im == 0)
                pixelCoordinates.Im = NUMBER_CLOSE_TO_ZERO;
            return pixelCoordinates;
        }

        private static int FindRootNumberIndex(List<ComplexNumber> roots, ComplexNumber pixelCoordinates)
        {
            bool known = false;
            int id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(pixelCoordinates.Re - roots[i].Re, 2) + Math.Pow(pixelCoordinates.Im - roots[i].Im, 2) <= ACCURACY_OF_ROOT_EQUALITY)
                {
                    known = true;
                    id = i;
                }
            }

            if (!known)
            {
                roots.Add(pixelCoordinates);
                id = roots.Count;
            }

            return id;
        }

        private static void ColorizePixel(Bitmap bitmap, int xPosition, int yPosition, int numberOfIterations, int rootNumberIndex)
        {
            Color[] colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green,
                Color.Yellow, Color.Orange, Color.Fuchsia,
                Color.Gold, Color.Cyan, Color.Magenta
            };

            Color color = colors[rootNumberIndex % colors.Length];
            color = Color.FromArgb(
                Math.Min(Math.Max(0, color.R - numberOfIterations * 2), 255),
                Math.Min(Math.Max(0, color.G - numberOfIterations * 2), 255),
                Math.Min(Math.Max(0, color.B - numberOfIterations * 2), 255));

            bitmap.SetPixel(xPosition, yPosition, color);
        }

        private static void CreatePolynome(out Polynomial polynomial)
        {
            polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1 });
            polynomial.Coefficients.Add(ComplexNumber.ZERO);
            polynomial.Coefficients.Add(ComplexNumber.ZERO);
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1 });
        }
    }
}
