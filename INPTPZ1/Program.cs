using System;

namespace INPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try {
                NewtonFractal newtonFractal = new NewtonFractal(
                        new Resolution(int.Parse(args[0]), int.Parse(args[1])),
                        new Point2D(double.Parse(args[2]), double.Parse(args[3])),
                        new Point2D(double.Parse(args[4]), double.Parse(args[5]))
                    );

                newtonFractal.SaveFractalAsImage(args[6]);

            } catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }
    }
}
