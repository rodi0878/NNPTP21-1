using Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1
{
    public class NewtonFractal
    {
        private const int MAX_ITERATION = 30;
        private const double TOLERANCE = 0.5;
        private readonly Color[] colors = new Color[]
        {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
        };

        private int width;
        private int height;

        private double xmin;
        private double xmax;
        private double ymin;
        private double ymax;

        private double xstep;
        private double ystep;

        private List<ComplexNumber> roots = new List<ComplexNumber>();

        private Polynome polynome;
        private Polynome derivedPolynome;
        private ComplexNumber complexNumber;

        private Bitmap bmpOutput;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args">new instance of NewtonFractal class</param>
        public NewtonFractal(string[] args)
        {
            CreateDefaultPolynome();
            derivedPolynome = polynome.Derive();

            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);
            ParseArgs(args);
        }


        private void CreateDefaultPolynome()
        {
            polynome = new Polynome();
            polynome.Coeficients.Add(new ComplexNumber() { Real = 1 });
            polynome.Coeficients.Add(ComplexNumber.Zero);
            polynome.Coeficients.Add(ComplexNumber.Zero);
            polynome.Coeficients.Add(new ComplexNumber() { Real = 1 });
        }

        public Bitmap CreateNewtonFractal()
        {
            PrepareBmpOutput();
            ColorizeBmpOutput();
            return bmpOutput;
        }

        private void ParseArgs(string[] args)
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

            width = intargs[0];
            height = intargs[1];

            xmin = doubleargs[0];
            xmax = doubleargs[1];
            ymin = doubleargs[2];
            ymax = doubleargs[3];

            xstep = (xmax - xmin) / width;
            ystep = (ymax - ymin) / height;
        }

        private void PrepareBmpOutput()
        {
            bmpOutput = new Bitmap(width, height);
        }

        private ComplexNumber CreateComplexNumberAndEditZeroParams(double real, double imaginary)
        {
            ComplexNumber complexNumber = new ComplexNumber { Real = real, Imaginary = imaginary };
            
            if (complexNumber.Real == 0)
                complexNumber.Real = 0.0001;
            if (complexNumber.Imaginary == 0)
                complexNumber.Imaginary = 0.0001;

            return complexNumber;

        }

        private void ColorizeBmpOutput()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double y = ymin + i * ystep;
                    double x = xmin + j * xstep;

                    complexNumber = CreateComplexNumberAndEditZeroParams(x, y);

                    int it = DoNewtonMethod();

                    int index = FindSolutionRootNumber();

                    ColorizePixel(index, it, i, j);
                }
            }
        }

        private int DoNewtonMethod()
        {
            int it = 0;
            for (int i = 0; i < MAX_ITERATION; i++)
            {
                ComplexNumber diff = polynome.Evaluate(complexNumber).Divide(derivedPolynome.Evaluate(complexNumber));
                complexNumber = complexNumber.Subtract(diff);

                if (Math.Pow(diff.Real, 2) + Math.Pow(diff.Imaginary, 2) >= TOLERANCE)
                {
                    i--;
                }
                it++;
            }

            return it;
        }

        private int FindSolutionRootNumber()
        {
            var known = false;
            var index = 0;
            for (int w = 0; w < roots.Count; w++)
            {
                if (Math.Pow(complexNumber.Real - roots[w].Real, 2) + Math.Pow(complexNumber.Imaginary - roots[w].Imaginary, 2) <= 0.01)
                {
                    known = true;
                    index = w;
                    break;
                }
            }
            if (!known)
            {
                roots.Add(complexNumber);
                index = roots.Count;
            }

            return index;
        }

        private void ColorizePixel(int index, int it, int i, int j)
        {
            Color colorForPixel = colors[index % colors.Length];
            colorForPixel = Color.FromArgb(Math.Min(Math.Max(0, colorForPixel.R - it * 2), 255), Math.Min(Math.Max(0, colorForPixel.G - it * 2), 255), Math.Min(Math.Max(0, colorForPixel.B - it * 2), 255));
            bmpOutput.SetPixel(j, i, colorForPixel);
        }
    }
}
