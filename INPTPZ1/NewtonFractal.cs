using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1
{
    class NewtonFractal
    {
        Color[] COLORS;
        readonly string DEFAULT_FILE_PATH = "..\\..\\..\\out.png";
        string pathToFile;
        int width, height;
        double xmin, ymin, xmax, ymax, xstep, ystep;
        Bitmap image;
        List<ComplexNumber> roots;
        Polynom basePolynom, derivatedPolynom;

        public NewtonFractal(string[] args)
        {
            ParseArguments(args);
        }
        public void CreateNewtonFractal()
        {
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

            roots = new List<ComplexNumber>();
            
            COLORS = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };
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
                    int index = FindRootNumberSolution(complexNumber);
                    ColorizeOnePixel(i, j, iteration, index);
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
            int iteration = 0;
            for (int i = 0; i < 30; i++)
            {
                var diff = basePolynom.Evaluate(complexNumber).Divide(derivatedPolynom.Evaluate(complexNumber));
                complexNumber = complexNumber.Subtract(diff);

                if (Math.Pow(diff.Real, 2) + Math.Pow(diff.Imaginary, 2) >= 0.5)
                {
                    i--;
                }
                iteration++;
            }

            return iteration;
        }

        private int FindRootNumberSolution(ComplexNumber complexNumber)
        {
            var known = false;
            var index = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(complexNumber.Real - roots[i].Real, 2) + Math.Pow(complexNumber.Imaginary - roots[i].Imaginary, 2) <= 0.01)
                {
                    known = true;
                    index = i;
                }
            }
            if (!known)
            {
                roots.Add(complexNumber);
                index = roots.Count;
            }

            return index;
        }

        private void ColorizeOnePixel(int i, int j, float iteration, int index)
        {
            var colorForPixel = COLORS[index % COLORS.Length];
            colorForPixel = Color.FromArgb(Math.Min(Math.Max(0, colorForPixel.R - (int)iteration * 2), 255), Math.Min(Math.Max(0, colorForPixel.G - (int)iteration * 2), 255), Math.Min(Math.Max(0, colorForPixel.B - (int)iteration * 2), 255));
            image.SetPixel(j, i, colorForPixel);
        }
        private void SaveImage()
        {
            image.Save(pathToFile);
        }
    }
}
