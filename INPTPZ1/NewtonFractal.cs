using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1
{
    class NewtonFractal
    {
        private const int MAX_NUMBER_OF_ITERATIONS = 30;
        private const double ACCURACY_OF_ROOT_INDEX_TOLERANCE = 0.01;
        private const string DEFAULT_OUTPUT_FILE = "../../../out.png";
        private const double ACCURACY_OF_FINDING_NUMBER_OF_ITERATIONS = 0.5;
        private const double ZERO_SUBSTITUTE_VALUE = 0.0001;
        private readonly Color[] COLORS = new Color[]
        {
            Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
        };

        private double xmin, xmax, ymin, ymax, xstep, ystep;
        private int imageWidth, imageHeight;
        private string outputFile;
        private Polynome polynome, derivedPolynome;
        private Bitmap newtonFractalBitmap;


        public NewtonFractal(string[] args)
        {
            ParseArguments(args);
        }

        public void DrawNewtonFractalAndSaveToOutputFile()
        {
            newtonFractalBitmap = new Bitmap(imageWidth, imageHeight);
            List<ComplexNumber> roots = new List<ComplexNumber>();
            InitializePolynomes();
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    ComplexNumber pixelInWorldCoordinates = GetPixelRealWorldCoordinates(x, y);
                    int numberOfIterations = FindNumberOfIterationsByUsingNewtonsIteration(ref pixelInWorldCoordinates);
                    int rootIndex = FindRootIndex(roots, pixelInWorldCoordinates);
                    SetPixelColorFromRootIndex(x, y, rootIndex, numberOfIterations);
                }
            }
            newtonFractalBitmap.Save(outputFile ?? DEFAULT_OUTPUT_FILE);
        }

        private void InitializePolynomes()
        {
            polynome = new Polynome()
            {
                Coefficients = {
                    new ComplexNumber() { Real = 1 },
                    ComplexNumber.ZERO,
                    ComplexNumber.ZERO,
                    new ComplexNumber() { Real = 1 }
                }
            };
            derivedPolynome = polynome.Derive();
        }

        private ComplexNumber GetPixelRealWorldCoordinates(int x, int y)
        {
            ComplexNumber pixelCoordinates = new ComplexNumber()
            {
                Real = xmin + y * xstep,
                Imaginary = ymin + x * ystep
            };
            CheckIfPixelCoordinatesIsZeroAndFixThem(ref pixelCoordinates);
            return pixelCoordinates;
        }

        private void CheckIfPixelCoordinatesIsZeroAndFixThem(ref ComplexNumber pixelCoordinates)
        {
            if (pixelCoordinates.Real == 0)
            {
                pixelCoordinates.Real = ZERO_SUBSTITUTE_VALUE;
            }

            if (pixelCoordinates.Imaginary == 0)
            {
                pixelCoordinates.Imaginary = ZERO_SUBSTITUTE_VALUE;
            }
        }

        private int FindNumberOfIterationsByUsingNewtonsIteration(ref ComplexNumber pixelCoordinates)
        {
            int iterationsCount = 0;
            for (int i = 0; i < MAX_NUMBER_OF_ITERATIONS; i++)
            {
                ComplexNumber diffrenece = polynome.Evaluate(pixelCoordinates).Divide(derivedPolynome.Evaluate(pixelCoordinates));
                pixelCoordinates = pixelCoordinates.Subtract(diffrenece);
                if (Math.Pow(diffrenece.Real, 2) + Math.Pow(diffrenece.Imaginary, 2) >= ACCURACY_OF_FINDING_NUMBER_OF_ITERATIONS)
                {
                    i--;
                }
                iterationsCount++;
            }
            return iterationsCount;
        }

        private int FindRootIndex(List<ComplexNumber> roots, ComplexNumber pixelCoordinates)
        {
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(pixelCoordinates.Real - roots[i].Real, 2) + Math.Pow(pixelCoordinates.Imaginary - roots[i].Imaginary, 2) <= ACCURACY_OF_ROOT_INDEX_TOLERANCE)
                {
                    return i;
                }
            }
            roots.Add(pixelCoordinates);
            return roots.Count;
        }

        private void SetPixelColorFromRootIndex(int x, int y, int rootIndex, int numberOfIterations)
        {
            Color color = COLORS[rootIndex % COLORS.Length];
            color = Color.FromArgb(
              Math.Min(Math.Max(0, color.R - numberOfIterations * 2), 255),
              Math.Min(Math.Max(0, color.G - numberOfIterations * 2), 255),
              Math.Min(Math.Max(0, color.B - numberOfIterations * 2), 255)
            );
            newtonFractalBitmap.SetPixel(y, x, color);
        }

        private void ParseArguments(string[] args)
        {
            imageWidth = int.Parse(args[0]);
            imageHeight = int.Parse(args[1]);
            xmin = double.Parse(args[2]);
            xmax = double.Parse(args[3]);
            ymin = double.Parse(args[4]);
            ymax = double.Parse(args[5]);
            outputFile = args[6];
            xstep = (xmax - xmin) / imageWidth;
            ystep = (ymax - ymin) / imageHeight;
        }
    }
}
