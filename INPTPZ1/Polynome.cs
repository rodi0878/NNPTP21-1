using System.Collections.Generic;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class Polynome
        {
            /// <summary>
            /// Coefficients
            /// </summary>
            public List<ComplexNumber> Coefficients { get; set; }

            public Polynome()
            {
                Coefficients = new List<ComplexNumber>();
            }

            public Polynome(List<ComplexNumber> coefficients)
            {
                Coefficients = coefficients;
            }

            public void Add(ComplexNumber coefficient)
            {
                Coefficients.Add(coefficient);
            }

            /// <summary>
            /// Derives this polynomial and creates new one
            /// </summary>
            /// <returns>Derivated polynomial</returns>
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
            /// <param name="x">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Eval(double x)
            {
                return Eval(new ComplexNumber() { Re = x, Im = 0 });
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="x">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Eval(ComplexNumber x)
            {
                ComplexNumber s = ComplexNumber.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    ComplexNumber coef = Coefficients[i];
                    ComplexNumber bx = x;
                    int power = i;

                    if (i > 0)
                    {
                        for (int j = 0; j < power - 1; j++)
                            bx = bx.Multiply(x);

                        coef = coef.Multiply(bx);
                    }

                    s = s.Add(coef);
                }

                return s;
            }

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns>String repr of polynomial</returns>
            public override string ToString()
            {
                string s = "";
                int i = 0;
                for (; i < Coefficients.Count; i++)
                {
                    s += Coefficients[i];
                    if (i > 0)
                    {
                        int j = 0;
                        for (; j < i; j++)
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
