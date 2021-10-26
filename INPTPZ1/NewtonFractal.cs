using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1
{
    class NewtonFractal
    {
        public const int MAX_ITERATION = 30;
        public Color[] Colors { get; set; }
        public string FilePath { get; set; }
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }
        public double XStep { get; set; }
        public double YStep { get; set; }
        public Bitmap OutputBitmap { get; private set; }

        private Polynomial polynomial;
        private Polynomial derivedPolynomial;
        private List<ComplexNumber> roots;

        public NewtonFractal(string[] args)
        {
            InitializeVariables(args);
            SetPolynomialNumbers();
        }

        public void CreateNewtonFractal()
        {
            for (int i = 0; i < OutputBitmap.Width; i++)
            {
                for (int j = 0; j < OutputBitmap.Height; j++)
                {
                    double xCoordinateOfPixel = XMin + j * XStep;
                    double yCoordinateOfPixel = YMin + i * YStep;

                    ComplexNumber complexNumber = new ComplexNumber()
                    {
                        Re = xCoordinateOfPixel,
                        Im = yCoordinateOfPixel
                    };
                    RecreateZeroComplexNumber(complexNumber);

                    int iteration = NewtonIteration(complexNumber);
                    int rootNumber = FindSolutionRootNumber(complexNumber);

                    OutputBitmap.SetPixel(j, i, GetColorForPixel(iteration,rootNumber));
                }
            }
        }

        public void SaveNewtonFractal()
        {
            OutputBitmap.Save(FilePath ?? "../../../out.png");
        }

        private void InitializeVariables(string[] args)
        {
            OutputBitmap = new Bitmap(int.Parse(args[0]), int.Parse(args[1]));
            XMin = double.Parse(args[2]);
            XMax = double.Parse(args[3]);
            YMin = double.Parse(args[4]);
            YMax = double.Parse(args[5]);
            FilePath = args[6];

            XStep = (XMax - XMin) / OutputBitmap.Width;
            YStep = (YMax - YMin) / OutputBitmap.Height;

            Colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

            roots = new List<ComplexNumber>();
        }

        private void SetPolynomialNumbers()
        {
            polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1 });
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(new ComplexNumber() { Re = 1 });
            derivedPolynomial = polynomial.Derive();
        }

        private void RecreateZeroComplexNumber(ComplexNumber complexNumber)
        {
            if (complexNumber.Re == 0)
            {
                complexNumber.Re = 0.0001;
            }
            if (complexNumber.Im == 0)
            {
                complexNumber.Im = 0.0001;
            }
        }

        private int NewtonIteration(ComplexNumber complexNumber)
        {
            int iteration = 0;
            for (int i = 0; i < MAX_ITERATION; i++)
            {
                ComplexNumber diff = polynomial.Evaluate(complexNumber).Divide(derivedPolynomial.Evaluate(complexNumber));
                complexNumber = complexNumber.Subtract(diff);

                if (Math.Pow(diff.Re, 2) + Math.Pow(diff.Im, 2) >= 0.5)
                {
                    i--;
                }
                iteration++;
            }
            return iteration;
        }

        private int FindSolutionRootNumber(ComplexNumber complexNumber)
        {
            bool known = false;
            int rootNumber = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (IsDistanceOfReAndImFromRootInTolerance(complexNumber, i))
                {
                    known = true;
                    rootNumber = i;
                }
            }
            if (!known)
            {
                roots.Add(complexNumber);
                rootNumber = roots.Count;
            }
            return rootNumber;
        }

        private bool IsDistanceOfReAndImFromRootInTolerance(ComplexNumber complexNumber, int indexOfRoot)
        {
            return Math.Pow(complexNumber.Re - roots[indexOfRoot].Re, 2) + Math.Pow(complexNumber.Im - roots[indexOfRoot].Im, 2) <= 0.01;
        }

        private Color GetColorForPixel(int iteration, int rootNumber)
        {
            Color color = Colors[rootNumber % Colors.Length];
            color = Color.FromArgb(color.R, color.G, color.B);
            color = Color.FromArgb(Math.Min(Math.Max(0, color.R - iteration * 2), 255), Math.Min(Math.Max(0, color.G - iteration * 2), 255), Math.Min(Math.Max(0, color.B - iteration * 2), 255));
            return color;
        }
    }
}
