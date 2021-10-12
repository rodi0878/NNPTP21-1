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

            public void Add(ComplexNumber complexNumber)
            {
                Coefficients.Add(complexNumber);
            }


            public Polynome Derive()
            {
                Polynome polynome = new Polynome();
                for (int i = 1; i < Coefficients.Count; i++)
                {
                    polynome.Coefficients.Add(Coefficients[i].Multiply(new ComplexNumber() { Real = i }));
                }
                return polynome;
            }

            public ComplexNumber Evaluate(double realNumberPointOfEvaluation)
            {
                return Evaluate(new ComplexNumber() { Real = realNumberPointOfEvaluation, Imaginary = 0 });
            }

            public ComplexNumber Evaluate(ComplexNumber pointOfEvaluation)
            {
                ComplexNumber result = ComplexNumber.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    ComplexNumber coefficient = Coefficients[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                        {
                            pointOfEvaluation = pointOfEvaluation.Multiply(pointOfEvaluation);
                        }

                        coefficient = coefficient.Multiply(pointOfEvaluation);
                    }
                    result = result.Add(coefficient);
                }
                return result;
            }

            public override string ToString()
            {
                string resultPolynomeString = "";
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    resultPolynomeString += Coefficients[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            resultPolynomeString += "x";
                        }
                    }
                    if (i + 1 < Coefficients.Count)
                    {
                        resultPolynomeString += " + ";
                    }
                }
                return resultPolynomeString;
            }
        }
    }
}
