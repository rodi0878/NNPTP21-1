using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        private static readonly int ImageWidthIndex = 0;
        private static readonly int ImageHeightIndex = 1;
        private static readonly int XMinIndex = 0;
        private static readonly int XMaxIndex = 1;        
        private static readonly int YMinIndex = 2;
        private static readonly int YMaxIndex = 3;
        private static readonly int OutputPathIndex = 6;
        static void Main(string[] args)
        {
            int[] imageDimensions = new int[2];
            for (int i = 0; i < imageDimensions.Length; i++)
            {
                imageDimensions[i] = int.Parse(args[i]);
            }
            double[] boundaryCoordinates = new double[4];
            for (int i = 0; i < boundaryCoordinates.Length; i++)
            {
                boundaryCoordinates[i] = double.Parse(args[i + 2]);
            }
            string outputPath = args[OutputPathIndex];
            // TODO: add parameters from args?
            double xmin = boundaryCoordinates[XMinIndex];
            double xmax = boundaryCoordinates[XMaxIndex];
            double ymin = boundaryCoordinates[YMinIndex];
            double ymax = boundaryCoordinates[YMaxIndex];

            NewtonFractal fractal = new NewtonFractal()
            {
                ImageHeight = imageDimensions[ImageHeightIndex],
                ImageWidth = imageDimensions[ImageWidthIndex],
                XMin = xmin,
                XMax = xmax,
                YMin = ymin,
                YMax = ymax
            };

            Bitmap bitmap = fractal.GenerateNewtonFractalImage();

            //// TODO: poly should be parameterised?
            //Polynome polynome = new Polynome();
            //Polynome derivedPolynome = CreatePolynome(polynome);

            bitmap.Save(outputPath ?? "../../../out.png");
        }
    }
}
