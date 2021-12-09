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
    class NewtonFractal
    {
        private const double POWER = 2;
        private const double POLYNOMIAL_QUOTIENT_TOLERANCE = 0.5;
        private const double ROOT_TOLERANCE = 0.01;
        private const int MAX_NEWTONS_ITERATIONS = 30;
        private const double INITIAL_COORDINATES = 0.0001;
        private const string DEFAUL_FILENAME = "../../../out.png";

        private static int ResultPictureWidth, ResultPictureHeight;
        private static double XMin, YMin, XMax, YMax;
        private static string FileName;
        private static readonly Color[] Colors = new Color[]
           {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
           };


        static void Main(string[] args)
        {
            ParseArguments(args);
            Console.WriteLine("Processing the Newton fractal...");
            CreatePicture();

            Console.WriteLine("Result picture successfully saved.");
            Console.WriteLine("Press any key to leave");
            Console.ReadKey();
        }

        private static void ParseArguments(string[] arguments)
        {
            ResultPictureWidth = int.Parse(arguments[0]);
            ResultPictureHeight = int.Parse(arguments[1]);
            XMin = double.Parse(arguments[2]);
            XMax = double.Parse(arguments[3]);
            YMin = double.Parse(arguments[4]);
            YMax = double.Parse(arguments[5]);
            FileName = arguments[6];
        }

        private static void CreatePicture()
        {
            List<ComplexNumber> roots = new List<ComplexNumber>();
            Bitmap bmp = new Bitmap(ResultPictureWidth, ResultPictureHeight);
            double xStep = (XMax - XMin) / ResultPictureWidth;
            double yStep = (YMax - YMin) / ResultPictureHeight;
            Polynomial polynomial = CreatePolynomial();
            Polynomial polynomialDerivation = polynomial.Derive();
            Console.WriteLine("Polynimial: " + polynomial);
            Console.WriteLine("Polynomial derivation: " + polynomialDerivation);

            // for every pixel in image...
            for (int i = 0; i < ResultPictureWidth; i++)
            {
                for (int j = 0; j < ResultPictureHeight; j++)
                {
                    // find "world" coordinates of pixel
                    double y = YMin + i * yStep;
                    double x = XMin + j * xStep;

                    ComplexNumber root = new ComplexNumber()
                    {
                        RealPart = x,
                        ImaginaryPart = (float)(y)
                    };

                    if (root.RealPart == 0)
                        root.RealPart = INITIAL_COORDINATES;
                    if (root.ImaginaryPart == 0)
                        root.ImaginaryPart = (float) INITIAL_COORDINATES;

                    // find solution of equation using newton's iteration
                    float it = SolveEquation(ref root, polynomial, polynomialDerivation);
                   
                    // find solution root number
                    int rootId = FindRoots(root, ref roots);

                    // colorize pixel according to root number
                    Color vv = Colors[rootId % Colors.Length];
                    vv = Color.FromArgb(Math.Min(Math.Max(0, vv.R - (int)it * 2), 255), Math.Min(Math.Max(0, vv.G - (int)it * 2), 255), Math.Min(Math.Max(0, vv.B - (int)it * 2), 255));
                    bmp.SetPixel(j, i, vv);
                }
            }

            bmp.Save(FileName ?? DEFAUL_FILENAME);
        }

        private static Polynomial CreatePolynomial()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.AddCoefficient(new ComplexNumber() { RealPart = 1 });
            polynomial.AddCoefficient(ComplexNumber.Zero);
            polynomial.AddCoefficient(ComplexNumber.Zero);
            polynomial.AddCoefficient(new ComplexNumber() { RealPart = 1 });
            return polynomial;

        }

        private static float SolveEquation(ref ComplexNumber root, Polynomial polynomial, Polynomial polynomialDerivation)
        {
            float it = 0;
            for (int i = 0; i < MAX_NEWTONS_ITERATIONS; i++)
            {
                var quotient = polynomial.Evaluate(root).Divide(polynomialDerivation.Evaluate(root));
                root = root.Subtract(quotient);

                if (Math.Pow(quotient.RealPart, POWER) + Math.Pow(quotient.ImaginaryPart, POWER) >= POLYNOMIAL_QUOTIENT_TOLERANCE)
                {
                    i--;
                }
                it++;
            }
            return it;
        }

        private static int FindRoots(ComplexNumber root, ref List<ComplexNumber> roots)
        {
            var known = false;
            var rootId = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(root.RealPart - roots[i].RealPart, POWER) + Math.Pow(root.ImaginaryPart - roots[i].ImaginaryPart, POWER) <= ROOT_TOLERANCE)
                {
                    known = true;
                    rootId = i;
                }
            }
            if (!known)
            {
                roots.Add(root);
                rootId = roots.Count;
            }
            return rootId;
        }


    }
}
