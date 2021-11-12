using System.Collections.Generic;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class Polynom
        {
            public List<ComplexNumber> Coeficients { get; set; }

            public Polynom()
            {
                Coeficients = new List<ComplexNumber>();
            }

            public void Add(ComplexNumber coeficient)
            {
                Coeficients.Add(coeficient);
            }

            public Polynom Derive()
            {
                Polynom derivedPolynom = new Polynom();
                for (int i = 1; i < Coeficients.Count; i++)
                {
                    derivedPolynom.Coeficients.Add(Coeficients[i].Multiply(new ComplexNumber() { Real = i }));
                }

                return derivedPolynom;
            }

            public ComplexNumber Evaluate(double realPartOfComplexNumber)
            {
                return Evaluate(new ComplexNumber() { Real = realPartOfComplexNumber, Imaginary = 0 });
            }

            public ComplexNumber Evaluate(ComplexNumber complexNumber)
            {
                ComplexNumber result = ComplexNumber.Zero;
                for (int i = 0; i < Coeficients.Count; i++)
                {
                    ComplexNumber coeficient = Coeficients[i];
                    ComplexNumber complexNumberToMultiply = complexNumber;

                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                        {
                            complexNumberToMultiply = complexNumberToMultiply.Multiply(complexNumber);
                        }

                        coeficient = coeficient.Multiply(complexNumberToMultiply);
                    }

                    result = result.Add(coeficient);
                }

                return result;
            }
            public override string ToString()
            {
                string polynomInString = "";
                for (int i = 0; i < Coeficients.Count; i++)
                {
                    polynomInString += Coeficients[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            polynomInString += "x";
                        }
                    }
                    if (i + 1 < Coeficients.Count)
                    {
                        polynomInString += " + ";
                    }
                }
                return polynomInString;
            }
        }
    }
}
