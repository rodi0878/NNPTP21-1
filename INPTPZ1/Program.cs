using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1 {
    class Program {
        static void Main(string[] args) {
            Point minPoint = new Point(double.Parse(args[2]), Double.Parse(args[4]));
            Point maxPoint = new Point(double.Parse(args[3]), Double.Parse(args[5]));
            Image image = new Image(int.Parse(args[0]), int.Parse(args[1]),args[5]);
            NewtonFractal fractal = new NewtonFractal(minPoint, maxPoint, ref image);
            fractal.setPolynomial();
            fractal.RenderNewtonFractal();
            image.saveImage();
        }
    }
}
