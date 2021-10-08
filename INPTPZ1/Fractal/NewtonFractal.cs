using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace INPTPZ1.Fractal
{
    public class NewtonFractal
    {
        private readonly int IterationMultiplier = 2;
        private readonly int ColorMax = 255;
        private readonly int ColorMin = 0;
        private readonly double DeterminantThreshold = 0.01;
        private readonly double IterationMaximumThreshold = 0.5;
        private readonly double NumberZeroValue = 0;
        private readonly double NumberMinimalValue = 0.0001;
        private readonly int MaximumNumberOfIterations = 30;

        private readonly double xstep;
        private readonly double ystep;

        private readonly Color[] colors;

        private readonly List<ComplexNumber> roots;

        private readonly Polynome polynome;
        private readonly Polynome derivedPolynome;

        private readonly Bitmap bitmap;

        public Dimension2D ImageDimensions { get; set; }
        public Point2D MinCoordinates { get; set; }
        public Point2D MaxCoordinates { get; set; }

        public NewtonFractal(Dimension2D imageDimensions, Point2D minCoordinates, Point2D maxCoordinates)
        {
            ImageDimensions = imageDimensions;
            MinCoordinates = minCoordinates;
            MaxCoordinates = maxCoordinates;

            xstep = (MaxCoordinates.X - MinCoordinates.X) / ImageDimensions.Width;
            ystep = (MaxCoordinates.Y - MinCoordinates.Y) / ImageDimensions.Height;

            colors = GenerateColorPallette();

            roots = new List<ComplexNumber>();

            polynome = Polynome.DefaultPolynome;
            derivedPolynome = polynome.Derive();

            bitmap = new Bitmap(ImageDimensions.Width, ImageDimensions.Height);
        }

        public Bitmap GenerateNewtonFractalImage()
        {
            Console.WriteLine(polynome);
            Console.WriteLine(derivedPolynome);

            for (int i = 0; i < ImageDimensions.Width; i++)
            {
                for (int j = 0; j < ImageDimensions.Height; j++)
                {
                    ComplexNumber pixelWorldCoordinates = GetPointInWorldCoordinates(i, j);
                    int iteration = FindSolutionsUsingNewtonIterationMethod(ref pixelWorldCoordinates);
                    int rootIndex = FindRootIndex(pixelWorldCoordinates);

                    ColorizePixel(new Point2D(i, j), iteration, rootIndex);
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

        private void ColorizePixel(Point2D pixelCoordinates, int iteration, int rootIndex)
        {
            Color color = colors[rootIndex % colors.Length];
            color = Color.FromArgb(
              GetValueForColorComponent(color.R, iteration),
              GetValueForColorComponent(color.G, iteration),
              GetValueForColorComponent(color.B, iteration));
            bitmap.SetPixel(pixelCoordinates.YAsInt, pixelCoordinates.XAsInt, color);
        }

        private int GetValueForColorComponent(byte colorByte, int iteration)
        {
            return Math.Min(Math.Max(ColorMin, GetColorValueByIteration(colorByte, iteration)), ColorMax);
        }

        private int GetColorValueByIteration(byte colorByte, int iteration)
        {
            return colorByte - iteration * IterationMultiplier;
        }

        private int FindRootIndex(ComplexNumber pixelWorldCoordinates)
        {
            bool isRootIndexKnown = false;
            int id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (IsCoordinateDifferenceSmallEnough(roots[i], pixelWorldCoordinates))
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

        private bool IsCoordinateDifferenceSmallEnough(ComplexNumber root, ComplexNumber complexNumber)
        {
            return complexNumber.SquareAndAddRealAndImaginaryDifferences(root) <= DeterminantThreshold;
        }

        private int FindSolutionsUsingNewtonIterationMethod(ref ComplexNumber pixelWorldCoordinates)
        {
            int numberOfIterations = 0;
            for (int i = 0; i < MaximumNumberOfIterations; i++)
            {
                ComplexNumber evaluatedPolynome = polynome.Eval(pixelWorldCoordinates);
                ComplexNumber evaluatedDerivedPolynome = derivedPolynome.Eval(pixelWorldCoordinates);
                ComplexNumber difference = evaluatedPolynome.Divide(evaluatedDerivedPolynome);
                pixelWorldCoordinates = pixelWorldCoordinates.Subtract(difference);

                if (IsComplexConjugateProductBigEnough(difference))
                {
                    i--;
                }
                numberOfIterations++;
            }

            return numberOfIterations;
        }

        private bool IsComplexConjugateProductBigEnough(ComplexNumber diff)
        {
            return diff.GetComplexConjugateProduct() >= IterationMaximumThreshold;
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

            if (IsNumberZero(pixelWorldCoordinates.Re))
                pixelWorldCoordinates.Re = NumberMinimalValue;
            if (IsNumberZero(pixelWorldCoordinates.Im))
                pixelWorldCoordinates.Im = NumberMinimalValue;
            return pixelWorldCoordinates;
        }

        private bool IsNumberZero(double number)
        {
            return number == NumberZeroValue;
        }
    }
}
