using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndPolynomials
{
    public static class Algorithms
    {
        private const string MAXMANTICA = "1111111111111111111111111111111111111111111111111111";
        /// <summary>
        /// Representation a double number in a binary view
        /// </summary>
        /// <param name="number">users number</param>
        /// <returns>string representation of number</returns>
        public static string ToBinariView(this double number)
        {
            if (number != number || double.IsInfinity(number) || number == double.MaxValue || number == double.MinValue||number==double.Epsilon)
            {
                return CheckArgumentValue(number);
            }

            string mantica = FindMantica(Math.Abs(number), out string wholePart);
            string exponent = Convert.ToString(1023 + wholePart.Length-1, 2);
            while (exponent.Length < 11) exponent += (number != 0?"0":"1") ;

            return String.Format("{0}{1}{2}", (number >= 0) ? 0 : 1, exponent, mantica);
        }


        private static string CheckArgumentValue(double number)
        {
            if (number == double.Epsilon) return "0001";
            if (number != number) return "011111111111";

            return String.Format("{0}11111111110{1}", number > 0 ? 0 : 1, MAXMANTICA);
        }

        private static string FindMantica(double number, out string wholePart)
        {
            StringBuilder res = new StringBuilder();

            wholePart = BinaryViewOfWholePart(Math.Truncate(number));
            string fractional = BinaryViewOfFraction(number % 1);

            if (!wholePart.StartsWith("0")) res.Append(wholePart.Substring(1));
            res.Append(fractional);

            while (res.Length < 52)
            {
                res.Append("0");
            }

            return res.ToString();
        }
        private static string BinaryViewOfWholePart(double number)
        {
            long wholePart = (long)number;
            if (wholePart == 0) return "0";
            string result = string.Empty;

            for (int i = 0; i < sizeof(long) * 8; i++)
                result = ((wholePart & ((long)1 << i)) != 0 ? '1' : '0') + result;

            return result.TrimStart(new[] { '0' });
        }
        private static string BinaryViewOfFraction(double fractionalPart)
        {
            StringBuilder answer = new StringBuilder();

            while (fractionalPart > 0)
            {
                fractionalPart *= 2;
                answer.Append((int)fractionalPart);
                fractionalPart -= (int)fractionalPart;
            }

            return answer.ToString();
        }
    }
}
