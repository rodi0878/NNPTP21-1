using Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1
{
    class NewtonFractal
    {
        private List<ComplexNumber> roots = new List<ComplexNumber>();

        private Color[] colors = new Color[]
        {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
        };

        private Polynome polynome;
        private Polynome derivedPolynome;
        private ComplexNumber ox;

        private int [] intargs;
        private double[] doubleargs;
        
        private Bitmap bmpOutput;
        

        public NewtonFractal(string []args)
        {
            polynome = new Polynome();
            polynome.Coeficients.Add(new ComplexNumber() { Real = 1 });
            polynome.Coeficients.Add(ComplexNumber.Zero);
            polynome.Coeficients.Add(ComplexNumber.Zero);
            polynome.Coeficients.Add(new ComplexNumber() { Real = 1 });

            derivedPolynome = polynome.Derive();

            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);
            ParseArgs(args);
        }

        public Bitmap CreateNewtonFractal ()
        {
            PrepareBmpOutput();
            ColorizeBmpOutput();
            return bmpOutput;
        }

        private void ParseArgs(string[] args)
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
        }

        private void PrepareBmpOutput()
        {
            bmpOutput = new Bitmap(intargs[0], intargs[1]);
        }

        private void ColorizeBmpOutput()
        {
            double xmin = doubleargs[0];
            double xmax = doubleargs[1];
            double ymin = doubleargs[2];
            double ymax = doubleargs[3];

            double xstep = (xmax - xmin) / intargs[0];
            double ystep = (ymax - ymin) / intargs[1];

            for (int i = 0; i < intargs[0]; i++)
            {
                for (int j = 0; j < intargs[1]; j++)
                {
                    double y = ymin + i * ystep;
                    double x = xmin + j * xstep;

                    ox = new ComplexNumber()
                    {
                        Real = x,
                        Imaginari = y
                    };

                    if (ox.Real == 0)
                        ox.Real = 0.0001;
                    if (ox.Imaginari == 0)
                        ox.Imaginari = 0.0001f;

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

                if (Math.Pow(diff.Real, 2) + Math.Pow(diff.Imaginari, 2) >= 0.5)
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
            var id = 0;
            for (int w = 0; w < roots.Count; w++)
            {
                if (Math.Pow(ox.Real - roots[w].Real, 2) + Math.Pow(ox.Imaginari - roots[w].Imaginari, 2) <= 0.01)
                {
                    known = true;
                    id = w;
                }
            }
            if (!known)
            {
                roots.Add(ox);
                id = roots.Count;
            }

            return id;
        }

        private void ColorizePixel(int id, int it, int i, int j)
        {
            Color vv = colors[id % colors.Length];
            vv = Color.FromArgb(vv.R, vv.G, vv.B);
            vv = Color.FromArgb(Math.Min(Math.Max(0, vv.R - it * 2), 255), Math.Min(Math.Max(0, vv.G - it * 2), 255), Math.Min(Math.Max(0, vv.B - it * 2), 255));
            bmpOutput.SetPixel(j, i, vv);
        }
    }
}
