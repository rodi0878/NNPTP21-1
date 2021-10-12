using System.Collections.Generic;

namespace INPTPZ1 {

    namespace Mathematics {
        public class Polynom
        {
            /*TOM- dokumentacni komentare podle prednaksy smazat?*/
            /// <summary>
            /// Coe
            /// </summary>
            public List<ComplexNumber> Coeficients { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            public Polynom() {
                Coeficients = new List<ComplexNumber>();
            }

            public void Add(ComplexNumber coeficient) {
                Coeficients.Add(coeficient);
            }
            /// <summary>
            /// Derives this polynomial and creates new one
            /// </summary>
            /// <returns>Derivated polynomial</returns>
            public Polynom Derive()
            {
                /*TOM - p zkratkovité, zmenit na polynom*/
                Polynom polynom = new Polynom();
                for (int i = 1; i < Coeficients.Count; i++)
                {
                    polynom.Coeficients.Add(Coeficients[i].Multiply(new ComplexNumber(i,0)));
                }
                return polynom;
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="pointX">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Evaluate(double pointX)
            {
                return Evaluate(new ComplexNumber(pointX, 0));
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="pointX">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Evaluate(ComplexNumber pointX)
            {
                /*hodne spatny -> coe, s, bx, power je potřeba?, slozenych zavorek?*/
                ComplexNumber valueOfPolynom = ComplexNumber.Zero;
                for (int i = 0; i < Coeficients.Count; i++)
                {
                    ComplexNumber valueOfCoeficient = Coeficients[i];
                    ComplexNumber bx = pointX;

                    if (i > 0)
                    {
                        for (int j = 0; j < i - 1; j++)
                            bx = bx.Multiply(pointX);

                        valueOfCoeficient = valueOfCoeficient.Multiply(bx);
                    }
                    valueOfPolynom = valueOfPolynom.Add(valueOfCoeficient);
                }

                return valueOfPolynom;
            }

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns>String repr of polynomial</returns>
            public override string ToString()
            {
                string s = "";
                int i = 0;
                for (; i < Coeficients.Count; i++)
                {
                    s += Coeficients[i];
                    if (i > 0)
                    {
                        int j = 0;
                        for (; j < i; j++)
                        {
                            s += "x";
                        }
                    }
                    if (i+1<Coeficients.Count)
                    s += " + ";
                }
                return s;
            }
        }
    }
}
