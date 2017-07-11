using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndPolynomials
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Representation a double number in a binary view
        /// </summary>
        /// <param name="number">users number</param>
        /// <returns>string representation of number</returns>
        public static string ToBinaryView(this double number)
        {
            Dil newNumber = new Dil(number);
            return BinaryViewOfWholePart(newNumber.longNumber);
        }

        private static string BinaryViewOfWholePart(long number)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < sizeof(long) * 8; i++)
                result.Append(((number & ((long) 1 << 63 - i)) != 0 ? '1' : '0'));

            return result.ToString();
        }


        [StructLayout(LayoutKind.Explicit)]
        private struct Dil
        {
            [FieldOffset(0)] public long longNumber;

            [FieldOffset(0)] private double doubleNumber;

            public Dil(double number)
            {
                longNumber = 0;
                doubleNumber = number;
            }

        }
    }
}
