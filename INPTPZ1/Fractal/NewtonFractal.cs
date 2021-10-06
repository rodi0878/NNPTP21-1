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
        private readonly int MaximumNumberOfIterations = 30;

        private double xstep;
        private double ystep;

        public Dimension2D ImageDimensions { get; set; }
        public Point2D MinCoordinates { get; set; }
        public Point2D MaxCoordinates { get; set; }
        public Polynome Polynome { get; set; }

        public NewtonFractal(Dimension2D imageDimensions, Point2D minCoordinates, Point2D maxCoordinates)
        {
            ImageDimensions = imageDimensions;
            MinCoordinates = minCoordinates;
            MaxCoordinates = maxCoordinates;

            xstep = (MaxCoordinates.X - MinCoordinates.X) / ImageDimensions.Width;
            ystep = (MaxCoordinates.Y - MinCoordinates.Y) / ImageDimensions.Height;
        }

        public Bitmap GenerateNewtonFractalImage()
        {
            Bitmap bitmap = new Bitmap(ImageDimensions.Width, ImageDimensions.Height);
            
            Polynome polynome = Polynome.DefaultPolynome;
            Polynome derivedPolynome = polynome.Derive();

            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);

            Color[] colors = GenerateColorPallette();

            List<ComplexNumber> roots = new List<ComplexNumber>();

            for (int i = 0; i < ImageDimensions.Width; i++)
            {
                for (int j = 0; j < ImageDimensions.Height; j++)
                {
                    ComplexNumber pixelWorldCoordinates = GetPointInWorldCoordinates(i, j);
                    int iteration = FindSolutionsUsingNewtonIterationMethod(polynome, derivedPolynome, ref pixelWorldCoordinates);
                    int rootIndex = FindRootIndex(roots, pixelWorldCoordinates);

                    ColorizePixel(bitmap, colors, i, j, iteration, rootIndex);
                }
            }

            return bitmap;
        }

        private Color[] GenerateColorPallette()
        {
            return new Color[]
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
        }

        private void ColorizePixel(Bitmap bitmap, Color[] colors, int x, int y, int iteration, int rootIndex)
        {
            Color color = colors[rootIndex % colors.Length];
            color = Color.FromArgb(
              Math.Min(Math.Max(MinColorValue, color.R - iteration * IterationMultiplier), MaxColorValue),
              Math.Min(Math.Max(MinColorValue, color.G - iteration * IterationMultiplier), MaxColorValue),
              Math.Min(Math.Max(MinColorValue, color.B - iteration * IterationMultiplier), MaxColorValue));
            bitmap.SetPixel(y, x, color);
        }

        private int FindRootIndex(List<ComplexNumber> roots, ComplexNumber pixelWorldCoordinates)
        {
            bool isRootIndexKnown = false;
            int id = 0;
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

        private int FindSolutionsUsingNewtonIterationMethod(Polynome polynome, Polynome derivedPolynome, ref ComplexNumber pixelWorldCoordinates)
        {
            int iteration = 0;
            for (int i = 0; i < MaximumNumberOfIterations; i++)
            {
                ComplexNumber diff = polynome.Eval(pixelWorldCoordinates).Divide(derivedPolynome.Eval(pixelWorldCoordinates));
                pixelWorldCoordinates = pixelWorldCoordinates.Subtract(diff);

                if (Math.Pow(diff.Re, SquareExponent) + Math.Pow(diff.Im, SquareExponent) >= IterationMaximumThreshold)
                {
                    i--;
                }
                iteration++;
            }

            return iteration;
        }

        private ComplexNumber GetPointInWorldCoordinates(int yValue, int xValue)
        {
            double y = MinCoordinates.Y + yValue * ystep;
            double x = MinCoordinates.X + xValue * xstep;

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
