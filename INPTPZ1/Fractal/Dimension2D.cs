using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1.Fractal
{
    public struct Dimension2D
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Dimension2D(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
