using Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1
{
    public class NewtonFractal
    {
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
        private ComplexNumber ox;

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
                complexNumber.Imaginary = 0.0001f;

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

                    ox = CreateComplexNumberAndEditZeroParams(x, y);

                    int it = DoNewtonMethod();

                    int id = FindSolutionRootNumber();

                    ColorizePixel(id, it, i, j);
                }
            }
        }

        private int DoNewtonMethod()
        {
            int it = 0;
            for (int i = 0; i < 30; i++)
            {
                var diff = polynome.Evaluate(ox).Divide(derivedPolynome.Evaluate(ox));
                ox = ox.Subtract(diff);

                if (Math.Pow(diff.Real, 2) + Math.Pow(diff.Imaginary, 2) >= 0.5)
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
                if (Math.Pow(ox.Real - roots[w].Real, 2) + Math.Pow(ox.Imaginary - roots[w].Imaginary, 2) <= 0.01)
                {
                    known = true;
                    index = w;
                }
            }
            if (!known)
            {
                roots.Add(ox);
                index = roots.Count;
            }

            return index;
        }

        private void ColorizePixel(int id, int it, int i, int j)
        {
            Color colorForPixel = colors[id % colors.Length];
            colorForPixel = Color.FromArgb(Math.Min(Math.Max(0, colorForPixel.R - it * 2), 255), Math.Min(Math.Max(0, colorForPixel.G - it * 2), 255), Math.Min(Math.Max(0, colorForPixel.B - it * 2), 255));
            bmpOutput.SetPixel(j, i, colorForPixel);
        }
    }
}
