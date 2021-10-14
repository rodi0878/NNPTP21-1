using System;
using System.Collections.Generic;
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
            try {
                NewtonFractal newtonFractal = new NewtonFractal(args);
            } catch (Exception exception) {
                Console.WriteLine(exception);
            }
        }
    }
}
