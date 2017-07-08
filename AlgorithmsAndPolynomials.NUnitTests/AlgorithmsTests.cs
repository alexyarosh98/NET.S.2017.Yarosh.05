using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgorithmsAndPolynomials.NUnitTests
{
    [TestFixture]
    public class AlgorithmsTests
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0001")]
        [TestCase(0.625,ExpectedResult = "0111111111101010000000000000000000000000000000000000000000000000")]
        [TestCase(0,ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(1.625,ExpectedResult = "0111111111101010000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity,ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.NegativeInfinity,ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.NaN,ExpectedResult = "011111111111")]
        public string ToBinaryView_PositiveAndNegativeNoneInfitityAnd_ZeroValues_StringWithBinaryViewOfDouble(
            double number)
        {
            return number.ToBinariView();
        }

    }
}
