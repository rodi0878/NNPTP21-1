using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1
{
    class NewtonFractal
    {
        readonly Color[] COLORS = new Color[]
         {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
         };
        readonly string DEFAULT_FILE_PATH = "..\\..\\..\\out.png";
        string pathToFile;
        int width, height;
        double xmin, ymin, xmax, ymax, xstep, ystep;
        Bitmap image;
        readonly List<ComplexNumber> roots = new List<ComplexNumber>();
        Polynom basePolynom, derivatedPolynom;

        public NewtonFractal(string[] args)
        {
            ParseArguments(args);
            PreparePolynomes();
            PrintPolynomes();
            ColorizeImageOfNewtonFractal();
            SaveImage();
        }



        private void ParseArguments(string[] arguments)
        {
            int[] intargs = new int[2];
            for (int i = 0; i < intargs.Length; i++)
            {
                intargs[i] = arguments.Length >= 1 ? int.Parse(arguments[i]) : 200;
            }

            double[] doubleargs = new double[4];
            for (int i = 0; i < doubleargs.Length; i++)
            {
                doubleargs[i] = arguments.Length >= 6 ? double.Parse(arguments[i + 2]) : Math.Pow(-1, i) * 100;
            }

            width = intargs[0];
            height = intargs[1];

            pathToFile = arguments.Length < 7 ? DEFAULT_FILE_PATH : arguments[6];
            image = new Bitmap(intargs[0], intargs[1]);

            xmin = doubleargs[0];
            xmax = doubleargs[1];
            ymin = doubleargs[2];
            ymax = doubleargs[3];

            xstep = (xmax - xmin) / intargs[0];
            ystep = (ymax - ymin) / intargs[1];
        }
        private void PreparePolynomes()
        {
            basePolynom = new Polynom();
            basePolynom.Coeficients.Add(new ComplexNumber() { Real = 1 });
            basePolynom.Coeficients.Add(ComplexNumber.Zero);
            basePolynom.Coeficients.Add(ComplexNumber.Zero);
            basePolynom.Coeficients.Add(new ComplexNumber() { Real = 1 });
            derivatedPolynom = basePolynom.Derive();
        }
        private void PrintPolynomes()
        {
            Console.WriteLine(basePolynom);
            Console.WriteLine(derivatedPolynom);
        }
        private void ColorizeImageOfNewtonFractal()
        {
            for (int i = 0; i < width; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < height; j++)
                {
                    double y = ymin + i * ystep;
                    double x = xmin + j * xstep;

                    ComplexNumber complexNumber = CreateComplexNumber(y, x);
                    EditZeroPamaetersInComplexNumber(complexNumber);
                    float iteration = FindEquationSolutionWithNewtonsIteration(ref complexNumber);
                    int id = FindRootNumberSolution(complexNumber);
                    ColorizeOnePixel(i, j, iteration, id);
                }
            }
        }
        private static ComplexNumber CreateComplexNumber(double y, double x)
        {
            return new ComplexNumber()
            {
                Real = x,
                Imaginary = y
            };
        }
        private static void EditZeroPamaetersInComplexNumber(ComplexNumber complexNumber)
        {
            if (complexNumber.Real == 0)
            {
                complexNumber.Real = 0.0001;
            }
            if (complexNumber.Imaginary == 0)
            {
                complexNumber.Imaginary = 0.0001;
            }
        }
        private float FindEquationSolutionWithNewtonsIteration(ref ComplexNumber complexNumber)
        {
            float iteration = 0;
            for (int q = 0; q < 30; q++)
            {
                var diff = basePolynom.Evaluate(complexNumber).Divide(derivatedPolynom.Evaluate(complexNumber));
                complexNumber = complexNumber.Subtract(diff);

                if (Math.Pow(diff.Real, 2) + Math.Pow(diff.Imaginary, 2) >= 0.5)
                {
                    q--;
                }
                iteration++;
            }

            return iteration;
        }

        private int FindRootNumberSolution(ComplexNumber complexNumber)
        {
            var known = false;
            var id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(complexNumber.Real - roots[i].Real, 2) + Math.Pow(complexNumber.Imaginary - roots[i].Imaginary, 2) <= 0.01)
                {
                    known = true;
                    id = i;
                }
            }
            if (!known)
            {
                roots.Add(complexNumber);
                id = roots.Count;
            }

            return id;
        }

        private void ColorizeOnePixel(int i, int j, float it, int id)
        {
            var colorForPixel = COLORS[id % COLORS.Length];
            colorForPixel = Color.FromArgb(colorForPixel.R, colorForPixel.G, colorForPixel.B);
            colorForPixel = Color.FromArgb(Math.Min(Math.Max(0, colorForPixel.R - (int)it * 2), 255), Math.Min(Math.Max(0, colorForPixel.G - (int)it * 2), 255), Math.Min(Math.Max(0, colorForPixel.B - (int)it * 2), 255));
            image.SetPixel(j, i, colorForPixel);
        }
        private void SaveImage()
        {
            image.Save(pathToFile);
        }
    }
}
