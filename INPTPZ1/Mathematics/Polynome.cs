using System.Collections.Generic;

namespace Mathematics
{
    public class Polynome
    {
        /// <summary>
        /// Coeficients
        /// </summary>
        public List<ComplexNumber> Coeficients { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Polynome()
        {
            Coeficients = new List<ComplexNumber>();
        }

        public void Add(ComplexNumber coe)
        {
            Coeficients.Add(coe);
        }

        /// <summary>
        /// Derives this polynomial and creates new one
        /// </summary>
        /// <returns>Derivated polynomial</returns>
        public Polynome Derive()
        {
            Polynome derivedPolynome = new Polynome();
            for (int i = 1; i < Coeficients.Count; i++)
            {
                derivedPolynome.Coeficients.Add(Coeficients[i].Multiply(new ComplexNumber() { Real = i }));
            }

            return derivedPolynome;
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="x">point of evaluation</param>
        /// <returns>y</returns>
        public ComplexNumber Evaluate(double x)
        {
            ComplexNumber evaluetedComplexNumber = Evaluate(new ComplexNumber() { Real = x, Imaginari = 0 });
            return evaluetedComplexNumber;
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="x">point of evaluation</param>
        /// <returns>y</returns>
        public ComplexNumber Evaluate(ComplexNumber x)
        {
            ComplexNumber evaluatedComplexNumber = ComplexNumber.Zero;
            for (int i = 0; i < Coeficients.Count; i++)
            {
                ComplexNumber coeficient = Coeficients[i];
                ComplexNumber bx = x;
                int power = i;

                if (i > 0)
                {
                    for (int j = 0; j < power - 1; j++)
                        bx = bx.Multiply(x);

                    coeficient = coeficient.Multiply(bx);
                }

                evaluatedComplexNumber = evaluatedComplexNumber.Add(coeficient);
            }

            return evaluatedComplexNumber;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>String repr of polynomial</returns>
        public override string ToString()
        {
            string polynomeInString = "";
            for (int i = 0; i < Coeficients.Count; i++)
            {
                polynomeInString += Coeficients[i];
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        polynomeInString += "x";
                    }
                }
                if (i + 1 < Coeficients.Count)
                {
                    polynomeInString += " + ";
                }
            }
            return polynomeInString;
        }
    }
}

