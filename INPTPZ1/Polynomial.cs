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

        public ComplexNumber Evaluate(double realPart)
        {
            ComplexNumber result = Evaluate(new ComplexNumber() { RealPart = realPart, ImaginaryPart = 0 });
            return result;
        }

        public ComplexNumber Evaluate(ComplexNumber pointOfEvaluation)
        {
            ComplexNumber complexNumber = ComplexNumber.Zero;
            for (int i = 0; i < ComplexNumbersList.Count; i++)
            {
                ComplexNumber coefficient = ComplexNumbersList[i];
                ComplexNumber copyPoint = pointOfEvaluation;
                int power = i;

                if (i > 0)
                {
                    for (int j = 0; j < power - 1; j++)
                        copyPoint = copyPoint.Multiply(pointOfEvaluation);

                    coefficient = coefficient.Multiply(copyPoint);
                }

                complexNumber = complexNumber.Add(coefficient);
            }

            return complexNumber;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < ComplexNumbersList.Count; i++)
            {
                result += ComplexNumbersList[i];
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        result += "x";
                    }
                }
                if (i + 1 < ComplexNumbersList.Count)
                    result += " + ";
            }
            return result;
        }
    }
}

