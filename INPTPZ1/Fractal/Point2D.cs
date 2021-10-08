namespace INPTPZ1.Fractal
{
    public struct Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public int XAsInt { get; set; }
        public int YAsInt { get; set; }

        public Point2D(double x, double y)
        {
            X = x;
            XAsInt = (int)x;
            Y = y;
            YAsInt = (int)y;
        }
    }
}
