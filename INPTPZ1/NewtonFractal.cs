using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class NewtonFractal
    {
        private double xstep;
        private double ystep;

        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }
        public Polynome Polynome { get; set; }

        public Bitmap GenerateNewtonFractalImage()
        {
            Polynome polynome = new Polynome();
            Polynome derivedPolynome = CreatePolynome(polynome);

            Bitmap bitmap = new Bitmap(ImageWidth, ImageHeight);

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

            xstep = (XMax - XMin) / ImageWidth;
            ystep = (YMax - YMin) / ImageHeight;

            for (int i = 0; i < ImageWidth; i++)
            {
                for (int j = 0; j < ImageHeight; j++)
                {
                    ComplexNumber pixelWorldCoordinates = GetPointInWorldCoordinates(XMin, YMin, xstep, ystep, i, j);

                    float iteration = FindSolutionsUsingNewtonIterationMethod(polynome, derivedPolynome, ref pixelWorldCoordinates);

                    int rootIndex = FindRootIndex(roots, pixelWorldCoordinates);

                    ColorizePixel(bitmap, colors, i, j, iteration, rootIndex);
                }
            }

            return bitmap;
        }

        private Polynome CreatePolynome(Polynome p)
        {
            p.Coefficients.Add(new ComplexNumber() { Re = 1 });
            p.Coefficients.Add(ComplexNumber.Zero);
            p.Coefficients.Add(ComplexNumber.Zero);
            p.Coefficients.Add(new ComplexNumber() { Re = 1 });

            return p.Derive();
        }

        private void ColorizePixel(Bitmap bitmap, Color[] colors, int x, int y, float iteration, int rootIndex)
        {
            var color = colors[rootIndex % colors.Length];
            color = Color.FromArgb(
              Math.Min(Math.Max(0, color.R - (int)iteration * 2), 255),
              Math.Min(Math.Max(0, color.G - (int)iteration * 2), 255),
              Math.Min(Math.Max(0, color.B - (int)iteration * 2), 255));
            bitmap.SetPixel(y, x, color);
        }

        private int FindRootIndex(List<ComplexNumber> roots, ComplexNumber pixelWorldCoordinates)
        {
            var isRootIndexKnown = false;
            var id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(pixelWorldCoordinates.Re - roots[i].Re, 2) + Math.Pow(pixelWorldCoordinates.Im - roots[i].Im, 2) <= 0.01)
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

        private float FindSolutionsUsingNewtonIterationMethod(Polynome polynome, Polynome derivedPolynome, ref ComplexNumber pixelWorldCoordinates)
        {
            float iteration = 0;
            for (int i = 0; i < 30; i++)
            {
                var diff = polynome.Eval(pixelWorldCoordinates).Divide(derivedPolynome.Eval(pixelWorldCoordinates));
                pixelWorldCoordinates = pixelWorldCoordinates.Subtract(diff);

                if (Math.Pow(diff.Re, 2) + Math.Pow(diff.Im, 2) >= 0.5)
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

            if (pixelWorldCoordinates.Re == 0)
                pixelWorldCoordinates.Re = 0.0001;
            if (pixelWorldCoordinates.Im == 0)
                pixelWorldCoordinates.Im = 0.0001f;
            return pixelWorldCoordinates;
        }
    }
}
