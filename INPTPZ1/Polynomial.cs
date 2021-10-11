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
                Polynomial derivative = new Polynomial();
                for (int i = 1; i < Coefficients.Count; i++)
                {
                    derivative.Coefficients.Add(Coefficients[i].Multiply(new ComplexNumber() { Re = i }));
                }

                return derivative;
            }

            public ComplexNumber Evaluate(double realNumber)
            {
                return Evaluate(new ComplexNumber() { Re = realNumber, Im = 0 });
            }

            public ComplexNumber Evaluate(ComplexNumber variableX)
            {
                ComplexNumber solution = ComplexNumber.ZERO;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    ComplexNumber coefficient = Coefficients[i];
                    ComplexNumber multiplication = variableX;

                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                            multiplication = multiplication.Multiply(variableX);

                        coefficient = coefficient.Multiply(multiplication);
                    }

                    solution = solution.Add(coefficient);
                }

                return solution;
            }

            public override string ToString()
            {
                string outcome = "";
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    outcome += Coefficients[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            outcome += "x";
                        }
                    }

                    if (i+1 < Coefficients.Count)
                    {
                        outcome += " + ";
                    }
                }
                return outcome;
            }
        }
    }
}
