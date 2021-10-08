using System.Collections.Generic;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class Polynome
        {
            public List<ComplexNumber> Coefficients { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            public Polynome()
            {
                Coefficients = new List<ComplexNumber>();
            }

            public void Add(ComplexNumber coeficient)
            {
                Coefficients.Add(coeficient);
            }

            /// <summary>
            /// Derives this polynomial and creates new one
            /// </summary>
            /// <returns>Derivated polynomial</returns>
            public Polynome Derive()
            {
                Polynome polynome = new Polynome();
                for (int i = 1; i < Coefficients.Count; i++)
                {
                    polynome.Coefficients.Add(Coefficients[i].Multiply(new ComplexNumber() { Re = i }));
                }

                return polynome;
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="realPartOfEvaluationPoint">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Evaluation(double realPartOfEvaluationPoint)
            {
                return Evaluation(new ComplexNumber() { Re = realPartOfEvaluationPoint, Im = 0 });
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="pointOfEvaluation">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Evaluation(ComplexNumber pointOfEvaluation)
            {
                ComplexNumber resultPolynomial = ComplexNumber.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    ComplexNumber coefficient = Coefficients[i];
                    ComplexNumber copiedPointOfEvaluation = pointOfEvaluation;

                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                        {
                            copiedPointOfEvaluation = copiedPointOfEvaluation.Multiply(pointOfEvaluation);
                        }
                        coefficient = coefficient.Multiply(copiedPointOfEvaluation);
                    }

                    resultPolynomial = resultPolynomial.Add(coefficient);
                }

                return resultPolynomial;
            }

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns>String repr of polynomial</returns>
            public override string ToString()
            {
                string resultPolynomial = "";
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    resultPolynomial += Coefficients[i];
                    if (i > 0)
                    {
                        for (int j = 0 ; j < i; j++)
                        {
                            resultPolynomial += "x";
                        }
                    }
                    if (i + 1 < Coefficients.Count)
                    {
                        resultPolynomial += " + ";
                    }
                    
                }
                return resultPolynomial;
            }
        }
    }
}
