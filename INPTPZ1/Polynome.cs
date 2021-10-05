using System.Collections.Generic;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class Polynome
        {
            public List<ComplexNumber> Coefficients { get; set; }

            public Polynome()
            {
                Coefficients = new List<ComplexNumber>();
            }

            public Polynome(List<ComplexNumber> coefficients)
            {
                Coefficients = coefficients;
            }

            public void AddCoefficient(ComplexNumber coefficient)
            {
                Coefficients.Add(coefficient);
            }

            public Polynome Derive()
            {
                Polynome result = new Polynome();
                for (int i = 1; i < Coefficients.Count; i++)
                {
                    result.Coefficients.Add(Coefficients[i].Multiply(new ComplexNumber() { Re = i }));
                }

                return result;
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="realNumber">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Eval(double realNumber)
            {
                return Eval(new ComplexNumber() { Re = realNumber, Im = 0 });
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="complexNumber">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Eval(ComplexNumber complexNumber)
            {
                ComplexNumber resultComplexNumber = ComplexNumber.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    ComplexNumber coefficient = Coefficients[i];
                    ComplexNumber multiplier = complexNumber;

                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                            multiplier = multiplier.Multiply(complexNumber);

                        coefficient = coefficient.Multiply(multiplier);
                    }

                    resultComplexNumber = resultComplexNumber.Add(coefficient);
                }

                return resultComplexNumber;
            }


            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    s += Coefficients[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            s += "x";
                        }
                    }
                    if (i + 1 < Coefficients.Count)
                        s += " + ";
                }
                return s;
            }
        }
    }
}
