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
        private const int NUMBER_OF_ITERATIONS = 30;
        private const double LEVEL_OF_TOLERANCE = 0.5;
        private const double ROOT_LEVEL_OF_TOLERANCE = 0.01;

        private static Bitmap bitmap;
        private static double xmin, xmax, ymin, ymax, xstep, ystep;
        private static Polynome polynome, derivedPolynome;
        private static List<ComplexNumber> roots;
        private static readonly Color[] colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

        static void Main(string[] args)
        {
            //TODO: přidat tu try catch (v případě, že argumenty nebudou ok)
            ValueInitialization(args, out string output);
            PolynomeInitialization();
            CreateImage();
            bitmap.Save(output ?? "../../../out.png");
        }

        private static void CreateImage()
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    ComplexNumber resultCoordinates = CalculatePixelCoordinates(i, j);
                    int iterations = CalculateNewtonIteration(ref resultCoordinates);
                    int rootNumber = CalculateRootNumber(resultCoordinates);
                    Color pixelColor = CalculatePixelColor(iterations, rootNumber);
                    bitmap.SetPixel(j, i, pixelColor);
                }
            }
        }

        private static void ValueInitialization(string[] args, out string output)
        {
            if (int.TryParse(args[0], out int bitmapWidth) &&
                int.TryParse(args[1], out int bitmapHeight) &&
                    double.TryParse(args[2], out xmin) &&
                    double.TryParse(args[3], out xmax) &&
                    double.TryParse(args[4], out ymin) &&
                    double.TryParse(args[5], out ymax))
            {
                bitmap = new Bitmap(bitmapWidth, bitmapHeight);
                output = args[6];
                xstep = (xmax - xmin) / bitmap.Width;
                ystep = (ymax - ymin) / bitmap.Height;
                roots = new List<ComplexNumber>();
            }
            else
            {
                throw new FormatException("Bad arguments.");
            }
        }

        private static void PolynomeInitialization()
        {
            polynome = new Polynome()
            {
                Coefficients =
                {
                    new ComplexNumber() { Re = 1 },
                    ComplexNumber.Zero,
                    ComplexNumber.Zero,
                    new ComplexNumber() { Re = 1 }
                }
            };
            derivedPolynome = polynome.Derive();

            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);
        }

        private static Color CalculatePixelColor(int iterations, int rootNumber)
        {
            Color pixelColor = colors[rootNumber % colors.Length];
            pixelColor = Color.FromArgb(
                Math.Min(Math.Max(0, pixelColor.R - iterations * 2), 255), 
                Math.Min(Math.Max(0, pixelColor.G - iterations * 2), 255), 
                Math.Min(Math.Max(0, pixelColor.B - iterations * 2), 255));
            return pixelColor;
        }

        private static int CalculateRootNumber(ComplexNumber resultCoordinates)
        {
            bool isRootKnown = false;
            int rootNumber = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(resultCoordinates.Re - roots[i].Re, 2) + Math.Pow(resultCoordinates.Im - roots[i].Im, 2) <= ROOT_LEVEL_OF_TOLERANCE)
                {
                    isRootKnown = true;
                    rootNumber = i;
                }
            }
            if (!isRootKnown)
            {
                roots.Add(resultCoordinates);
                rootNumber = roots.Count;
            }

            return rootNumber;
        }

        private static int CalculateNewtonIteration(ref ComplexNumber resultCoordinates)
        {
            int iterations = 0;
            for (int i = 0; i < NUMBER_OF_ITERATIONS; i++)
            {
                ComplexNumber difference = polynome.Evaluation(resultCoordinates).Divide(derivedPolynome.Evaluation(resultCoordinates));
                resultCoordinates = resultCoordinates.Subtract(difference);

                if (Math.Pow(difference.Re, 2) + Math.Pow(difference.Im, 2) >= LEVEL_OF_TOLERANCE)
                {
                    i--;
                }
                iterations++;
            }

            return iterations;
        }

        private static ComplexNumber CalculatePixelCoordinates(int bitmapY, int bitmapX)
        {
            double x = xmin + bitmapX * xstep;
            double y = ymin + bitmapY * ystep;

            ComplexNumber resultCoordinates = new ComplexNumber()
            {
                Re = x,
                Im = y
            };

            if (resultCoordinates.Re == 0)
            {
                resultCoordinates.Re = 0.0001;
            }

            if (resultCoordinates.Im == 0)
            {
                resultCoordinates.Im = 0.0001f;
            }

            return resultCoordinates;
        }
    }
}
