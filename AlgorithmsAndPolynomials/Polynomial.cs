using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndPolynomials
{
    public class Polynomial
        //
        // Some methods, refactoring and operator "*" are coming soon 
        //
    {
        public double[] Coefficients { get; }
        public Polynomial(params double[] coef)
        {
            Coefficients = new double[coef.Length];
            Array.Copy(coef, Coefficients, coef.Length);
        }
        override public string ToString()
        {
            StringBuilder res = new StringBuilder();

            for (int i = 1; i < Coefficients.Length; i++)
            {
                res.Append(String.Format("{3} {0}{1}*x^{2}", Coefficients[i] > 0 ? "+" : "-", Math.Abs(Coefficients[i]), (i), i == 1 ? Coefficients[0] + " = " : ""));
            }
            return res.ToString();

        }
        public static Polynomial operator +(Polynomial obj1, Polynomial obj2)
        {
            if (obj1 == null || obj2 == null) throw new ArgumentException();

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

            return new Polynomial(coeff);
        }
        public static Polynomial operator +(Polynomial obj, double value)
        {
            double[] coeff = new double[obj.Coefficients.Length];
            Array.Copy(obj.Coefficients, coeff, obj.Coefficients.Length);
            coeff[0] += value;
            return new Polynomial(coeff);
        }
        public static Polynomial operator +(double value, Polynomial obj) => obj + value;


        public static Polynomial operator -(Polynomial obj1, Polynomial obj2)
        {

            if (obj1.Coefficients.Length > obj2.Coefficients.Length)
            {
                double[] coeff = new double[obj2.Coefficients.Length];
                for (int i = 0; i < obj2.Coefficients.Length; i++)
                {
                    coeff[i] = -obj2.Coefficients[i];
                }
                Polynomial newPoly = new Polynomial(coeff);
                return new Polynomial((obj1 + newPoly).Coefficients);
            }
            else
            {
                double[] coeff = new double[obj2.Coefficients.Length];
                for (int i = 0; i < obj1.Coefficients.Length; i++)
                {
                    coeff[i] = obj1.Coefficients[i] - obj2.Coefficients[i];
                }
                for (int i = obj1.Coefficients.Length; i < obj2.Coefficients.Length; i++) coeff[i] = -obj2.Coefficients[i];
                return new Polynomial(coeff);
            }

        }
        public static Polynomial operator -(Polynomial obj, double value) => obj + (-value);
        public static Polynomial operator -(double value, Polynomial obj) => obj + (-value); 
    }
}
