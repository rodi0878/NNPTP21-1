using Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class NewtonFractal
    {
        private const int MaxIterations = 30;
        private Resolution resolution;
        private Point2D xPoint;
        private Point2D yPoint;
        private Bitmap bitmap;
        private double xStep;
        private double yStep;
        private List<ComplexNumber> roots = new List<ComplexNumber>();
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

        public NewtonFractal(string[] args)
        {
            this.resolution = new Resolution(int.Parse(args[0]), int.Parse(args[1]));
            this.xPoint = new Point2D(double.Parse(args[2]), double.Parse(args[3]));
            this.yPoint = new Point2D(double.Parse(args[4]), double.Parse(args[5]));
            String filename = args[6];

            SetBitmapAndSteps();
            CreatePolynomialAndPolynomialDerived();
            CreateNewtonFractal();

            bitmap.Save(filename ?? "../../../out.png");
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
            bool known = false;
            int id = 0;
            for (int w = 0; w < roots.Count; w++)
            {
                if (Math.Pow(complexNumber.RealPart - roots[w].RealPart, 2) + Math.Pow(complexNumber.ImaginaryPart - roots[w].ImaginaryPart, 2) <= 0.01)
                {
                    known = true;
                    id = w;
                }
            }
            if (!known)
            {
                roots.Add(complexNumber);
                id = roots.Count;
            }

            return id;
        }

        private int FindSolutionOfEquationUsingNewtonIteration(ref ComplexNumber complexNumber)
        {
            int iteration = 0;
            for (int q = 0; q < MaxIterations; q++)
            {
                ComplexNumber diff = polynomial.Evaluate(complexNumber).Divide(polynomialDerived.Evaluate(complexNumber));
                complexNumber = complexNumber.Subtract(diff);

                if (Math.Pow(diff.RealPart, 2) + Math.Pow(diff.ImaginaryPart, 2) >= 0.5)
                {
                    q--;
                }
                iteration++;
            }

            return iteration;
        }

        private ComplexNumber FindWorldCoordinatesOfPixel(int i, int j)
        {
            double y = yPoint.X + i * yStep;
            double x = xPoint.X + j * xStep;

            ComplexNumber complexNumber = new ComplexNumber()
            {
                RealPart = x,
                ImaginaryPart = y
            };

            if (complexNumber.RealPart == 0)
                complexNumber.RealPart = 0.0001;
            if (complexNumber.ImaginaryPart == 0)
                complexNumber.ImaginaryPart = 0.0001f;

            return complexNumber;
        }
    }
}
