using System;

namespace INPTPZ1 {

    namespace Mathematics {
        public class ComplexNumber
        {
          
            public double Re { get; set; }
            public double Im { get; set; }

            /*TOM kouknout na logiku metod, nejde to udelat lepe? poměrně složité jsou tam dvě čísla a nějaké složité vzorečky */
          public   ComplexNumber(double Re, double Im) {
                this.Re = Re;
                this.Im = Im;
            }

            public readonly static ComplexNumber Zero = new ComplexNumber(0, 0);
            public override bool Equals(object obj)
            {
                if (obj is ComplexNumber)
                {
                    ComplexNumber x = obj as ComplexNumber;
                    return x.Re == Re && x.Im == Im;
                }
                return base.Equals(obj);
            }


            public ComplexNumber Multiply(ComplexNumber b)
            {
                return new ComplexNumber(this.Re * b.Re - this.Im * b.Im, this.Re * b.Im + this.Im * b.Re);
           /*     {
                    Re = a.Re * b.Re - a.Im * b.Im,
                    Im = a.Re * b.Im + a.Im * b.Re
                };*/
            }
            public double GetAbs()
            {
                return Math.Sqrt( Re * Re + Im * Im);
            }
            //TOM - jenomGetAngle
            public double GetAngleInRadian() {
                return Math.Atan(Im / Re);
            }

            public ComplexNumber Add(ComplexNumber b)
            {
                return new ComplexNumber(this.Re + b.Re, this.Im + b.Im);
              /*  {
                    Re = a.Re + b.Re,
                    Im = a.Im + b.Im
                };*/
            }
         
            public ComplexNumber Subtract(ComplexNumber b)
            {
                return new ComplexNumber(this.Re - b.Re, this.Im - b.Im);
            }

            public override string ToString()
            {
                return $"({Re} + {Im}i)";
            }

            /*TOM - TMP lépe pojmenovat nebo nějak jinak vyřešit?? tmp tmp2*/

            public ComplexNumber Divide(ComplexNumber b)
            {   
                                var numerator = this.Multiply(new ComplexNumber(b.Re, -b.Im));
                                var denumerator = b.Re * b.Re + b.Im * b.Im;

                return new ComplexNumber(numerator.Re / denumerator, numerator.Im / denumerator);
           
            }
        }
    }
}
