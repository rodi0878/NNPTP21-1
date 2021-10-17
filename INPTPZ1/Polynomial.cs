using System.Collections.Generic;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class Polynomial
        {
            public List<ComplexNumber> Coefficients { get; set; }

            public Polynomial()
            {
                Coefficients = new List<ComplexNumber>();
            }

            public void Add(ComplexNumber coefficient)
            {
                Coefficients.Add(coefficient);
            }

            public Polynomial Derive()
            {
                Polynomial polynomial = new Polynomial();
                for (int i = 1; i < Coefficients.Count; i++)
                {
                    polynomial.Coefficients.Add(Coefficients[i].Multiply(new ComplexNumber() { Re = i }));
                }
                return polynomial;
            }

            public ComplexNumber Evaluate(double x)
            {
                ComplexNumber result = Evaluate(new ComplexNumber() { Re = x, Im = 0 });
                return result;
            }


            public ComplexNumber Evaluate(ComplexNumber pointOfEvaluation)
            {
                ComplexNumber newComplexNumber = ComplexNumber.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    ComplexNumber coef = Coefficients[i];
                    ComplexNumber bx = pointOfEvaluation;
                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                        {
                            bx = bx.Multiply(pointOfEvaluation);
                        }

                        coef = coef.Multiply(bx);
                    }
                    newComplexNumber = newComplexNumber.Add(coef);
                }
                return newComplexNumber;
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
                    {
                        resultString += " + ";
                    }
                }
                return resultString;
            }
        }
    }
}
