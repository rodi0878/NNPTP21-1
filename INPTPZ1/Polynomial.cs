using System.Collections.Generic;

namespace INPTPZ1.Mathematics
{
    public class Polynomial
    {

        public List<ComplexNumber> Coefficients { get; set; }

        public Polynomial()
        {
            Coefficients = new List<ComplexNumber>();
        }

        public Polynomial(params ComplexNumber[] coeficients) : this()
        {
            foreach (ComplexNumber coeficient in coeficients)
                Add(coeficient);
        }

        public void Add(ComplexNumber coeficient)
        {
            Coefficients.Add(coeficient);
        }

        public Polynomial Derive()
        {
            Polynomial derivedPolynomial = new Polynomial();
            for (int i = 1; i < Coefficients.Count; i++)
            {
                derivedPolynomial.Coefficients.Add(Coefficients[i].Multiply(new ComplexNumber() { Re = i }));
            }

            return derivedPolynomial;
        }

        public ComplexNumber EvaluateAtPointX(double x)
        {
            return EvaluateAtPointX(new ComplexNumber() { Re = x, Im = 0 });
        }

        public ComplexNumber EvaluateAtPointX(ComplexNumber x)
        {
            ComplexNumber result = ComplexNumber.ZERO;
            for (int i = 0; i < Coefficients.Count; i++)
            {
                ComplexNumber coeficient = Coefficients[i];
                ComplexNumber exponentialFromBaseX = x;

                if (i > 0)
                {
                    for (int j = 0; j < i - 1; j++)
                        exponentialFromBaseX = exponentialFromBaseX.Multiply(x);

                    coeficient = coeficient.Multiply(exponentialFromBaseX);
                }

                result = result.Add(coeficient);
            }

            return result;
        }

        public override string ToString()
        {
            string resultString = "";
            for (int i = 0; i < Coefficients.Count; i++)
            {
                resultString += Coefficients[i];
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        resultString += "x";
                    }
                }
                if (i + 1 < Coefficients.Count)
                    resultString += " + ";
            }
            return resultString;
        }
    }
}
