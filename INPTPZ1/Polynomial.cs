using System.Collections.Generic;

namespace Mathematics
{
    public class Polynomial
    {
        public List<ComplexNumber> ComplexNumbersList { get; set; }

        public Polynomial()
        {
            ComplexNumbersList = new List<ComplexNumber>();
        }

        public Polynomial(List<ComplexNumber> list) {
            ComplexNumbersList = list;
        }

        public void Add(ComplexNumber complexNumber)
        {
            ComplexNumbersList.Add(complexNumber);
        }

        public Polynomial Derive()
        {
            Polynomial polynomial = new Polynomial();
            for (int i = 1; i < ComplexNumbersList.Count; i++)
            {
                polynomial.ComplexNumbersList.Add(ComplexNumbersList[i].Multiply(new ComplexNumber() { RealPart = i }));
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
            for (int i = 0; i < ComplexNumbersList.Count; i++)
            {
                ComplexNumber coefficient = ComplexNumbersList[i];
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
            for (int i = 0; i < ComplexNumbersList.Count; i++)
            {
                s += ComplexNumbersList[i];
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        s += "x";
                    }
                }
                if (i + 1 < ComplexNumbersList.Count)
                    s += " + ";
            }
            return s;
        }
    }
}

