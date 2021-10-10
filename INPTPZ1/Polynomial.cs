using System.Collections.Generic;

namespace Mathematics
{
    public class Polynomial
    {
        public List<ComplexNumber> CompleNumbersList { get; set; }

        public Polynomial()
        {
            CompleNumbersList = new List<ComplexNumber>();
        }

        public void Add(ComplexNumber complexNumber)
        {
            CompleNumbersList.Add(complexNumber);
        }

        public Polynomial Derive()
        {
            Polynomial polynomial = new Polynomial();
            for (int i = 1; i < CompleNumbersList.Count; i++)
            {
                polynomial.CompleNumbersList.Add(CompleNumbersList[i].Multiply(new ComplexNumber() { RealPart = i }));
            }

            return polynomial;
        }

        public ComplexNumber Evaluate(double x)
        {
            ComplexNumber result = Evaluate(new ComplexNumber() { RealPart = x, ImaginaryPart = 0 });
            return result;
        }

        public ComplexNumber Evaluate(ComplexNumber x)
        {
            ComplexNumber complexNumber = ComplexNumber.Zero;
            for (int i = 0; i < CompleNumbersList.Count; i++)
            {
                ComplexNumber coefficient = CompleNumbersList[i];
                ComplexNumber bx = x;
                int power = i;

                if (i > 0)
                {
                    for (int j = 0; j < power - 1; j++)
                        bx = bx.Multiply(x);

                    coefficient = coefficient.Multiply(bx);
                }

                complexNumber = complexNumber.Add(coefficient);
            }

            return complexNumber;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < CompleNumbersList.Count; i++)
            {
                s += CompleNumbersList[i];
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        s += "x";
                    }
                }
                if (i + 1 < CompleNumbersList.Count)
                    s += " + ";
            }
            return s;
        }
    }
}

