
namespace INPTPZ1
{
    class Program
    {
        public static void Main(string[] args)
        {
            NewtonFractal newtonFractal = new NewtonFractal(args);
            newtonFractal.DrawNewtonFractalAndSaveToOutputFile();
        }
    }
}
