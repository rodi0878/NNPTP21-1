using System;
using System.Drawing;
using INPTPZ1.Fractal;

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
        private static readonly int XMinIndex = 2;
        private static readonly int XMaxIndex = 3;
        private static readonly int YMinIndex = 4;
        private static readonly int YMaxIndex = 5;
        private static readonly int OutputPathIndex = 6;
        static void Main(string[] args)
        {
            try
            {
                NewtonFractal fractal = new NewtonFractal(
                    new Dimension2D(int.Parse(args[ImageWidthIndex]), int.Parse(args[ImageHeightIndex])),
                    new Point2D(double.Parse(args[XMinIndex]), double.Parse(args[YMinIndex])),
                    new Point2D(double.Parse(args[XMaxIndex]), double.Parse(args[YMaxIndex]))
                    );

                Bitmap bitmap = fractal.GenerateNewtonFractalImage();

                string outputPath = args[OutputPathIndex];
                bitmap.Save(outputPath ?? "../../../out.png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
