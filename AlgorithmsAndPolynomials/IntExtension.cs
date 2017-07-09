using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndPolynomials
{
    public class IntExtension
    {
        #region Not binary alrorithms

        /// <summary>
        /// Simple Euclid alrorithms to find the greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <returns>greatest common divisor</returns>
        public static int GreatestCommonDevisor(int number1, int number2)
        {
            CheckValuesContainsMinValue(number1, number2);
            if (number1==0)return number2;
            if (number2==0) return number1;
            
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);
            while (number1 != number2)
            {
                if (number1 > number2) number1 -= number2;
                else number2 -= number1;
            }
 
            return number1;
        }
        /// <summary>
        /// Simple Euclid alrorithms to find the greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <param name="stopwatch">time</param>
        /// <returns>greastest common divisor and time needed to execute the method</returns>
        public static int GreatestCommonDevisor(int number1, int number2, out Stopwatch stopwatch)
        {
            stopwatch=Stopwatch.StartNew();
            int res=GreatestCommonDevisor(number1, number2);
            stopwatch.Stop();

            return res;
        }
        /// <summary>
        /// Simple Euclid alrorithms to find the greatest common divisor
        /// </summary>
        /// <param name="numbers">An array of numbers</param>
        /// <exception cref="ArgumentException">numberst must be not null</exception>
        /// <returns>greatest common divisor</returns>
        public static int GreatestCommonDevisor(params int[] numbers)
        {
            CheckValuesContainsMinValue(numbers);
            if (numbers==null) throw new ArgumentException($"{nameof(numbers)} is null");
            if (numbers.Length == 0) return 0;

            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = GreatestCommonDevisor(result, numbers[i]);
            }

            return result;
        }
        /// <summary>
        /// Simple Euclid alrorithms to find the greatest common divisor
        /// </summary>
        /// <param name="stopwatch">time needed to execute the method</param>
        /// <param name="numbers">array of numbers</param>
        /// <returns>greatest common divisor and time</returns>
        public static int GreatestCommonDevisor(out Stopwatch stopwatch, params int[] numbers)
        {
            stopwatch=Stopwatch.StartNew();
            int res = GreatestCommonDevisor(numbers);
            stopwatch.Stop();

            return res;
        }
        /// <summary>
        /// Simple Euclid alrorithms to find the greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <param name="number3">thied number</param>
        /// <returns>greatest common divisor</returns>
        public static int GreatestCommonDevisor(int number1, int number2, int number3)=>GreatestCommonDevisor(GreatestCommonDevisor(number1,number2),number3);
        /// <summary>
        /// Simple Euclid alrorithms to find the greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <param name="number3">third number</param>
        /// <param name="stopwatch">time needed to execute the method</param>
        /// <returns>greatest common divisor and time</returns>
        public static int GreatestCommonDevisor(int number1, int number2, int number3, out Stopwatch stopwatch)
        {
            stopwatch=Stopwatch.StartNew();
            int res = GreatestCommonDevisor(GreatestCommonDevisor(number1, number2), number3);
            stopwatch.Stop();

            return res;
        }
        #endregion
        #region BinaryAlgorithms
        /// <summary>
        /// Binary Euclid algorithm to find greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <returns>gretest common divisor</returns>
        public static int BinaryAlgotithmGreatestCommonDevisor(int number1, int number2)
        {
            CheckValuesContainsMinValue(number1, number2);
            if (number1 == 0) return number2;
            if (number2 == 0) return number1;

            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            int shift;
            int temp;
            for (shift = 0; ((number1 | number2) & 1) == 0; ++shift)
            {
                number1 >>= 1;
                number2 >>= 1;
            }
            while ((number1 & 1) == 0)
                number1 >>= 1;
 
            while (number2 != 0)
            {
                while ((number2 & 1) == 0)
                    number2 >>= 1;

                if (number1 > number2) { temp = number2; number2 = number1; number1 = temp; }
                number2 -= number1;

            } 

            return number1 << shift;
        }
        /// <summary>
        /// Binary Euclid algorithm to find greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <param name="stopwatch">time neede to execute the method</param>
        /// <returns>greatest common divisor and time</returns>
        public static int BinaryAlgotithmGreatestCommonDevisor(int number1, int number2, out Stopwatch stopwatch)
        {
            stopwatch=Stopwatch.StartNew();
            int res = BinaryAlgotithmGreatestCommonDevisor(number1, number2);
            stopwatch.Stop();

            return res;
        }/// <summary>
         /// Binary Euclid algorithm to find greatest common divisor
         /// </summary>
         /// <param name="numbers">array of numbers</param>
         /// <exception cref="ArgumentException">array must be not null</exception>
         /// <returns>greatest common divisor</returns>
        public static int BinaryAlgotithmGreatestCommonDevisor(params int[] numbers)
        {
            CheckValuesContainsMinValue(numbers);
            if (numbers==null) throw new ArgumentException($"{nameof(numbers)} is null");
            if (numbers.Length == 0) return 0;

            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = BinaryAlgotithmGreatestCommonDevisor(result, numbers[i]);
            }

            return result;
        }
        /// <summary>
        /// Binary Euclid algorithm to find greatest common divisor
        /// </summary>
        /// <param name="stopwatch">time needed to execute the method</param>
        /// <param name="numbers">array of numbers</param>
        /// <exception cref="ArgumentException">array must be not null</exception>
        /// <returns>greatest common divisor and time</returns>
        public static int BinaryAlgotithmGreatestCommonDevisor(out Stopwatch stopwatch, params int[] numbers)
        {
            stopwatch=Stopwatch.StartNew();
            int res = BinaryAlgotithmGreatestCommonDevisor(numbers);
            stopwatch.Stop();

            return res;
        }
        /// <summary>
        /// Binary Euclid algorithm to find greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <param name="number3">third number</param>
        /// <returns>greatest common divisor</returns>
        public static int BinaryAlgotithmGreatestCommonDevisor(int number1, int number2, int number3) => BinaryAlgotithmGreatestCommonDevisor(BinaryAlgotithmGreatestCommonDevisor(number1, number2), number3);
        /// <summary>
        /// Binary Euclid algorithm to find greatest common divisor
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <param name="number3">third number</param>
        /// <param name="stopwatch">time needed to execute the method</param>
        /// <returns>greatest common divisor and time</returns>
        public static int BinaryAlgotithmGreatestCommonDevisor(int number1, int number2, int number3,
            out Stopwatch stopwatch)
        {
            stopwatch=Stopwatch.StartNew();
            int res= BinaryAlgotithmGreatestCommonDevisor(BinaryAlgotithmGreatestCommonDevisor(number1, number2), number3);
            stopwatch.Stop();

            return res;
        }

        #endregion

        private static void CheckValuesContainsMinValue(int number1, int number2)
        {
            if (number1 == int.MinValue || number2 == int.MinValue)
                throw new ArgumentException("Numbers can't be min value of integer");
        }
        private static void CheckValuesContainsMinValue(params int[] numbers)
        {
            if(numbers.Contains(int.MinValue)) throw  new ArgumentException("Numbers can't be min value of integer");
        }

    }

}
