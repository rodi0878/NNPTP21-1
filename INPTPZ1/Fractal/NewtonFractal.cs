using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1.Fractal
{
    public class NewtonFractal
    {
        private readonly int IterationMultiplier = 2;
        private readonly int MaxColorValue = 255;
        private readonly int MinColorValue = 0;
        private readonly int SquareExponent = 2;
        private readonly double DeterminantThreshold = 0.01;
        private readonly double IterationMaximumThreshold = 0.5;
        private readonly double NumberZeroValue = 0;
        private readonly double NumberMinimalValue = 0.0001;
        private readonly int InitialRealNumberValue = 1;
        private readonly int MaximumNumberOfIterations = 30;

        public Dimension2D ImageDimensions { get; set; }
        public Point2D MinCoordinates { get; set; }
        public Point2D MaxCoordinates { get; set; }
        public Polynome Polynome { get; set; }

        public Bitmap GenerateNewtonFractalImage()
        {
            //// TODO: poly should be parameterised?
            //Polynome polynome = new Polynome();
            //Polynome derivedPolynome = CreatePolynome(polynome);
            Polynome polynome = new Polynome();
            Polynome derivedPolynome = CreatePolynome(polynome);

            Bitmap bitmap = new Bitmap(ImageDimensions.Width, ImageDimensions.Height);

            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);

            var colors = new Color[]
{
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

            List<ComplexNumber> roots = new List<ComplexNumber>();

            double xstep = (MaxCoordinates.X - MinCoordinates.X) / ImageDimensions.Width;
            double ystep = (MaxCoordinates.Y - MinCoordinates.Y) / ImageDimensions.Height;

            for (int i = 0; i < ImageDimensions.Width; i++)
            {
                for (int j = 0; j < ImageDimensions.Height; j++)
                {
                    ComplexNumber pixelWorldCoordinates = GetPointInWorldCoordinates(MinCoordinates.X, MinCoordinates.Y, xstep, ystep, i, j);

                    float iteration = FindSolutionsUsingNewtonIterationMethod(polynome, derivedPolynome, ref pixelWorldCoordinates);

                    int rootIndex = FindRootIndex(roots, pixelWorldCoordinates);

                    ColorizePixel(bitmap, colors, i, j, iteration, rootIndex);
                }
            }

            return bitmap;
        }

        private Polynome CreatePolynome(Polynome polynome)
        {
            polynome.Coefficients.Add(new ComplexNumber() { Re = InitialRealNumberValue });
            polynome.Coefficients.Add(ComplexNumber.Zero);
            polynome.Coefficients.Add(ComplexNumber.Zero);
            polynome.Coefficients.Add(new ComplexNumber() { Re = InitialRealNumberValue });

            return polynome.Derive();
        }

        private void ColorizePixel(Bitmap bitmap, Color[] colors, int x, int y, float iteration, int rootIndex)
        {
            var color = colors[rootIndex % colors.Length];
            color = Color.FromArgb(
              Math.Min(Math.Max(MinColorValue, color.R - (int)iteration * IterationMultiplier), MaxColorValue),
              Math.Min(Math.Max(MinColorValue, color.G - (int)iteration * IterationMultiplier), MaxColorValue),
              Math.Min(Math.Max(MinColorValue, color.B - (int)iteration * IterationMultiplier), MaxColorValue));
            bitmap.SetPixel(y, x, color);
        }

        private int FindRootIndex(List<ComplexNumber> roots, ComplexNumber pixelWorldCoordinates)
        {
            var isRootIndexKnown = false;
            var id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (IsDeterminantSmallEnough(roots[i], pixelWorldCoordinates))
                {
                    isRootIndexKnown = true;
                    id = i;
                }
            }
            if (!isRootIndexKnown)
            {
                roots.Add(pixelWorldCoordinates);
                id = roots.Count;
            }

            return id;
        }

        private bool IsDeterminantSmallEnough(ComplexNumber root, ComplexNumber complexNumber)
        {
            return Math.Pow(complexNumber.Re - root.Re, SquareExponent) + Math.Pow(complexNumber.Im - root.Im, SquareExponent) <= DeterminantThreshold;
        }

        private float FindSolutionsUsingNewtonIterationMethod(Polynome polynome, Polynome derivedPolynome, ref ComplexNumber pixelWorldCoordinates)
        {
            float iteration = 0;
            for (int i = 0; i < MaximumNumberOfIterations; i++)
            {
                var diff = polynome.Eval(pixelWorldCoordinates).Divide(derivedPolynome.Eval(pixelWorldCoordinates));
                pixelWorldCoordinates = pixelWorldCoordinates.Subtract(diff);

                if (Math.Pow(diff.Re, SquareExponent) + Math.Pow(diff.Im, SquareExponent) >= IterationMaximumThreshold)
                {
                    i--;
                }
                iteration++;
            }

            return iteration;
        }

        private ComplexNumber GetPointInWorldCoordinates(double xmin, double ymin, double xstep, double ystep, int i, int j)
        {
            double y = ymin + i * ystep;
            double x = xmin + j * xstep;

            ComplexNumber pixelWorldCoordinates = new ComplexNumber()
            {
                Re = x,
                Im = y
            };

            if (pixelWorldCoordinates.Re == NumberZeroValue)
                pixelWorldCoordinates.Re = NumberMinimalValue;
            if (pixelWorldCoordinates.Im == NumberZeroValue)
                pixelWorldCoordinates.Im = NumberMinimalValue;
            return pixelWorldCoordinates;
        }
    }
}
