namespace INPTPZ1.Fractal
{
    public struct Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public int XAsInt { get => (int) X; set => X = value; }
        public int YAsInt { get => (int) Y; set => Y = value; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
