using Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1
{
    public class NewtonFractal
    {
        private const int MaxIterations = 30;
        private const string DefaultFilename= "../../../out.png";
        private const double RootTolerance = 0.01;
        private const double IterationTolerance = 0.5;

        private readonly Resolution resolution;
        private readonly Point2D xPoint;
        private readonly Point2D yPoint;
        private Bitmap bitmap;
        private double xStep;
        private double yStep;
        private readonly List<ComplexNumber> roots = new List<ComplexNumber>();
        private Polynomial polynomial;
        private Polynomial polynomialDerived;

        public Color[] Colors { get; set; } = {  
            Color.Red, 
            Color.Blue, 
            Color.Green, 
            Color.Yellow, 
            Color.Orange, 
            Color.Fuchsia, 
            Color.Gold, 
            Color.Cyan, 
            Color.Magenta 
        };

        public NewtonFractal(Resolution resolution, Point2D xPoint, Point2D yPoint)
        {
            this.resolution = resolution;
            this.xPoint = xPoint;
            this.yPoint = yPoint;
            

            SetBitmapAndSteps();
            CreatePolynomialAndPolynomialDerived();
            CreateNewtonFractal();
        }
        public void SaveFractalAsImage(string filename) {
            bitmap.Save(filename ?? DefaultFilename);
        }

        private void SetBitmapAndSteps()
        {
            bitmap = new Bitmap(resolution.Width, resolution.Height);
            xStep = (xPoint.Y - xPoint.X) / resolution.Width;
            yStep = (yPoint.Y - yPoint.X) / resolution.Height;
        }

        private void CreatePolynomialAndPolynomialDerived()
        {
            List<ComplexNumber> complexNumbersList = new List<ComplexNumber>
            {
                new ComplexNumber() { RealPart = 1 },
                ComplexNumber.Zero,
                ComplexNumber.Zero,
                new ComplexNumber() { RealPart = 1 }
            };
            polynomial = new Polynomial(complexNumbersList);
            polynomialDerived = polynomial.Derive();
        }

        public Bitmap CreateNewtonFractal() {
            Console.WriteLine($"{polynomial}\n{polynomialDerived}");

            for (int i = 0; i < resolution.Width; i++) {
                for (int j = 0; j < resolution.Height; j++)
                {
                    ComplexNumber complexNumber = FindWorldCoordinatesOfPixel(i, j);
                    int iteration = FindSolutionOfEquationUsingNewtonIteration(ref complexNumber);
                    int id = FindRootNumber(complexNumber);
                    Color color = ColorizePixelAccordingToRoot(iteration, id);
                    bitmap.SetPixel(j, i, color);
                }
            }
            return bitmap;
        }

        private Color ColorizePixelAccordingToRoot(int iteration, int id)
        {
            Color color = Colors[id % Colors.Length];
            color = Color.FromArgb(Math.Min(Math.Max(0, color.R - (int)iteration * 2), 255),
                                Math.Min(Math.Max(0, color.G - (int)iteration * 2), 255),
                                Math.Min(Math.Max(0, color.B - (int)iteration * 2), 255));
            return color;
        }

        private int FindRootNumber(ComplexNumber complexNumber)
        {
            bool isRootKnown = false;
            int id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(complexNumber.RealPart - roots[i].RealPart, 2) + Math.Pow(complexNumber.ImaginaryPart - roots[i].ImaginaryPart, 2) <= RootTolerance)
                {
                    isRootKnown = true;
                    id = i;
                }
            }
            if (!isRootKnown)
            {
                roots.Add(complexNumber);
                id = roots.Count;
            }

            return id;
        }

        private int FindSolutionOfEquationUsingNewtonIteration(ref ComplexNumber complexNumber)
        {
            int iteration = 0;
            for (int i = 0; i < MaxIterations; i++)
            {
                ComplexNumber evaluatedPolynomial = polynomial.Evaluate(complexNumber);
                ComplexNumber evaluatedDerivedPolynomial = polynomialDerived.Evaluate(complexNumber);
                ComplexNumber difference = evaluatedPolynomial.Divide(evaluatedDerivedPolynomial);
                complexNumber = complexNumber.Subtract(difference);

                if (Math.Pow(difference.RealPart, 2) + Math.Pow(difference.ImaginaryPart, 2) >= IterationTolerance)
                {
                    i--;
                }
                iteration++;
            }

            return iteration;
        }

        private ComplexNumber FindWorldCoordinatesOfPixel(int y, int x)
        {
            double imaginaryPart = yPoint.X + y * yStep;
            double realPart = xPoint.X + x * xStep;

            ComplexNumber complexNumber = new ComplexNumber()
            {
                RealPart = realPart,
                ImaginaryPart = imaginaryPart
            };

            if (complexNumber.RealPart == 0)
                complexNumber.RealPart = 0.0001;
            if (complexNumber.ImaginaryPart == 0)
                complexNumber.ImaginaryPart = 0.0001;

            return complexNumber;
        }
    }
}
