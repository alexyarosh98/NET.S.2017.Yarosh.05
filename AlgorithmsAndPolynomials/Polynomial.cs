using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndPolynomials
{
    public class Polynomial
    {
        public double[] Coefficients { get; }
        public Polynomial(params double[] coef)
        {
            Coefficients = new double[coef.Length];
            Array.Copy(coef, Coefficients, coef.Length);
        }

        public Polynomial(double number)
        {
            Coefficients=new double[]{number};
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            if (Coefficients.Length == 1) return $"0*x={-1*Coefficients[0]}";
            for (int i = Coefficients.Length - 1; i >= 1; i--)
            {
                res.Append(String.Format("{0} {1}*x^{2} {3}", Coefficients[i] > 0 ? "+" : "-", Math.Abs(Coefficients[i]),
                    (i), i == 1 ? "= " + -1*Coefficients[0] : ""));
            }

            return res.ToString();
        }

        public override bool Equals(object poly)
        {
            if (poly == null) return false;
            Polynomial polynomial = poly as Polynomial;
            if (polynomial == null) return false;
            if (polynomial.Coefficients.Length != Coefficients.Length) return false;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] != polynomial.Coefficients[i]) return false;
            }

            return true;
        }

        public Polynomial NormolizeThePoly()
        {
            if (Coefficients.Length == 1) return this;
            double[] coeff=new double[Coefficients.Length];

            for (int i = 0; i < Coefficients.Length; i++)
            {
                coeff[i] = Coefficients[i] / Coefficients[Coefficients.Length - 1];
            }
            return new Polynomial(coeff);
        }

        public static Polynomial operator +(Polynomial obj1, Polynomial obj2)
        {
            if (obj1 == null || obj2 == null) throw new ArgumentException();
            if(obj1.Coefficients.Length==0) return new Polynomial(obj2.Coefficients.Trim());
            if(obj2.Coefficients.Length==0) return new Polynomial(obj1.Coefficients.Trim());

            int maxLength = Math.Max(obj1.Coefficients.Length, obj2.Coefficients.Length);
            double[] coeff = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                coeff[i] = obj1.Coefficients[i] + obj2.Coefficients[i];

                if (i == Math.Min(obj1.Coefficients.Length, obj2.Coefficients.Length) - 1 && obj1.Coefficients.Length != obj2.Coefficients.Length)
                {
                    if (obj1.Coefficients.Length < obj2.Coefficients.Length)
                    {
                        Array.Copy(obj2.Coefficients, i + 1, coeff, i + 1, obj2.Coefficients.Length - i - 1);
                    }
                    else if (obj1.Coefficients.Length > obj2.Coefficients.Length)
                    {
                        Array.Copy(obj1.Coefficients, i + 1, coeff, i + 1, obj1.Coefficients.Length - i - 1);
                    }
                    break; ;
                }
            }

            return new Polynomial(coeff.Trim());
        }
        public static Polynomial operator +(Polynomial obj, double value)
        {
            if(obj.Coefficients.Length==0) return new Polynomial(value);

            double[] coeff = new double[obj.Coefficients.Length];
            Array.Copy(obj.Coefficients, coeff, obj.Coefficients.Length);
            coeff[0] += value;
            return new Polynomial(coeff);
        }
        public static Polynomial operator +(double value, Polynomial obj) => obj + value;


        public static Polynomial operator -(Polynomial obj1, Polynomial obj2)
        {
            if (obj1.Coefficients.Length == 0)
            {
                double[] coeff=new double[obj2.Coefficients.Length];
                for (int i = 0; i < obj2.Coefficients.Length; i++) coeff[i] = -obj2.Coefficients[i];
                return new Polynomial(coeff.Trim());
            }
            if(obj2.Coefficients.Length==0) return  new Polynomial(obj1.Coefficients);

            if (obj1.Coefficients.Length > obj2.Coefficients.Length)
            {
                double[] coeff = new double[obj2.Coefficients.Length];
                for (int i = 0; i < obj2.Coefficients.Length; i++)
                {
                    coeff[i] = -obj2.Coefficients[i];
                }
                Polynomial newPoly = new Polynomial(coeff);
                return new Polynomial((obj1 + newPoly).Coefficients.Trim());
            }
            else
            {
                double[] coeff = new double[obj2.Coefficients.Length];
                for (int i = 0; i < obj1.Coefficients.Length; i++)
                {
                    coeff[i] = obj1.Coefficients[i] - obj2.Coefficients[i];
                }
                for (int i = obj1.Coefficients.Length; i < obj2.Coefficients.Length; i++) coeff[i] = -obj2.Coefficients[i];
                return new Polynomial(coeff.Trim());
            }

        }
        public static Polynomial operator -(Polynomial obj, double value) => obj + (-value);
        public static Polynomial operator -(double value, Polynomial obj) => obj + (-value);

        public static Polynomial operator *(Polynomial obj1, Polynomial obj2)
        {
            double[] coeff = new double[obj1.Coefficients.Length + obj2.Coefficients.Length];

            for (int i = 0; i < obj1.Coefficients.Length; i++)
            {
                for (int j = 0; j < obj2.Coefficients.Length; j++)
                {
                    coeff[i + j] += obj1.Coefficients[i] * obj2.Coefficients[j];
                }
            }

            return new Polynomial(coeff.Trim());
        }

        public static Polynomial operator *(Polynomial poly, double value)
        {
            double[]coeff=new double[poly.Coefficients.Length];
            for (int i = 0; i < poly.Coefficients.Length; i++)
            {
                coeff[i] = poly.Coefficients[i] * value;
            }

            return new Polynomial(coeff.Trim());
        }

        public static Polynomial operator *(double value, Polynomial poly) => poly * value;
    }

    public static class DoubleExtensions
    {
        public static double[] Trim(this double[] array)
        {
            if(array.Length==0)return array;
            int index=0;
            for (int i = array.Length - 1; i > 0; i--)
            {
                if(array[i]!=0) break;
                index++;
            }
            if (index != 0)
            {
                double []newArr=new double[array.Length-index];
                Array.Copy(array,0,newArr,0,array.Length-index);
                array = newArr;
            }
            return array;
        }
    }
}
