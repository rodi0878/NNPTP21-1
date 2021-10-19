using System.Drawing;
using Mathematics;

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
            string output = args[6];

            NewtonFractal newtonFractal = new NewtonFractal(args);
            Bitmap bmp = newtonFractal.CreateNewtonFractal();

            bmp.Save(output ?? "../../../out.png");
        }
    }
}
