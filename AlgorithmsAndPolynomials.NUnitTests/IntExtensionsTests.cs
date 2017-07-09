using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgorithmsAndPolynomials.NUnitTests
{
    [TestFixture]
    class IntExtensionsTests
    {
        #region  Simple Euclid algorithm tests

        [TestCase(6, 0, ExpectedResult = 6)]
        [TestCase(0, 6, ExpectedResult = 6)]
        [TestCase(512,256,ExpectedResult = 256)]
        [TestCase(0,0,ExpectedResult = 0)]
        [TestCase(19,7,ExpectedResult = 1)]
        [TestCase(int.MaxValue,int.MaxValue,ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue,int.MinValue+1,ExpectedResult = int.MaxValue)]
        [TestCase(10,15,ExpectedResult = 5)]
        public int GreatestCommonDivisor_AnyValuesExcpetIntMinValue_GreatestCommonDivisor(int number1, int number2)
        {
            return AlgorithmsAndPolynomials.IntExtension.GreatestCommonDevisor(number1, number2);
        }

        [TestCase(6,5,4,ExpectedResult = 1)]
        [TestCase(4,6,5,ExpectedResult = 1)]
        [TestCase(6,4,5,ExpectedResult = 1)]
        [TestCase(512,8,4,ExpectedResult = 4)]
        [TestCase(3,0,4212,ExpectedResult = 3)]
        [TestCase(int.MaxValue,int.MinValue+1,int.MaxValue,ExpectedResult = int.MaxValue)]
        public int GreatestCommonDivisor_AnyValuesExceptIntMinValue_GreatestCommonDivisor(int number1, int number2,
            int number3)
        {
            return AlgorithmsAndPolynomials.IntExtension.GreatestCommonDevisor(number1, number2, number3);
        }

        [TestCase(3,4,5,6,7,ExpectedResult = 1)]
        [TestCase(int.MaxValue,0,0,0,0,ExpectedResult = int.MaxValue)]
        [TestCase(18,36,72,90,ExpectedResult = 18)]
        [TestCase(ExpectedResult = 0)]
        [TestCase(0,0,0,0,0,0,ExpectedResult = 0)]
        public int GreatestCommonDivisor_NotNullArrayOfNumbers_GretestCommonDivisor(params int[] numbers)
        {
            return AlgorithmsAndPolynomials.IntExtension.GreatestCommonDevisor(numbers);
        }
        [TestCase(int.MinValue,0)]
        [TestCase(1242342,int.MinValue)]
        [TestCase(int.MaxValue,int.MinValue)]
        public void GreatestCommonDivisor_IntMinValue_ArgumentException(int number1, int number2)
        {
            var ex = Assert.Catch<Exception>(() => IntExtension.GreatestCommonDevisor(number1, number2));

            StringAssert.Contains("Numbers can't be min value of integer",ex.Message);
        }
        [TestCase(int.MinValue, 0,int.MinValue)]
        [TestCase(1242342, int.MinValue,423423423)]
        [TestCase(int.MaxValue, int.MinValue,423)]
        public void GreatestCommonDivisor_IntMinValue_ArgumentException(int number1, int number2,int number3)
        {
            var ex = Assert.Catch<Exception>(() => IntExtension.GreatestCommonDevisor(number1, number2,number3));

            StringAssert.Contains("Numbers can't be min value of integer", ex.Message);
        }
        [TestCase(int.MinValue, 0,432,4124,435,0)]
        [TestCase(1242342, int.MinValue,2,0,3,0,0,0)]
        [TestCase(int.MaxValue, int.MinValue,int.MaxValue,int.MaxValue,int.MaxValue)]
        public void GreatestCommonDivisor_IntMinValue_ArgumentException(params  int[] numbers)
        {
            var ex = Assert.Catch<Exception>(() => IntExtension.GreatestCommonDevisor(numbers));

            StringAssert.Contains("Numbers can't be min value of integer", ex.Message);
        }
        #endregion

        #region  Binary Euclid algorithm tests
        [TestCase(6, 0, ExpectedResult = 6)]
        [TestCase(0, 6, ExpectedResult = 6)]
        [TestCase(512, 256, ExpectedResult = 256)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(19, 7, ExpectedResult = 1)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(int.MaxValue, int.MinValue + 1, ExpectedResult = int.MaxValue)]
        [TestCase(10, 15, ExpectedResult = 5)]
        public int BinaryAlgorithmGreatestCommonDivisor_AnyValuesExceptIntMinValue_GreatestCommonDivisor(int number1,
            int number2)
        {
            return AlgorithmsAndPolynomials.IntExtension.BinaryAlgotithmGreatestCommonDevisor(number1, number2);
        }
        [TestCase(6, 5, 4, ExpectedResult = 1)]
        [TestCase(4, 6, 5, ExpectedResult = 1)]
        [TestCase(6, 4, 5, ExpectedResult = 1)]
        [TestCase(512, 8, 4, ExpectedResult = 4)]
        [TestCase(3, 0, 4212, ExpectedResult = 3)]
        [TestCase(int.MaxValue, int.MinValue + 1, int.MaxValue, ExpectedResult = int.MaxValue)]
        public int BinaryAlgorithmGreatestCommonDivisor_AnyValuesExceptIntMinValue_GreatestCommonDivisor(int number1, int number2,
            int number3)
        {
            return AlgorithmsAndPolynomials.IntExtension.BinaryAlgotithmGreatestCommonDevisor(number1, number2, number3);
        }

        [TestCase(3, 4, 5, 6, 7, ExpectedResult = 1)]
        [TestCase(int.MaxValue, 0, 0, 0, 0, ExpectedResult = int.MaxValue)]
        [TestCase(18, 36, 72, 90, ExpectedResult = 18)]
        [TestCase(ExpectedResult = 0)]
        [TestCase(0, 0, 0, 0, 0, 0, ExpectedResult = 0)]
        public int BinaryAlgorithmGreatestCommonDivisor_NotNullArrayOfNumbers_GretestCommonDivisor(params int[] numbers)
        {
            return AlgorithmsAndPolynomials.IntExtension.BinaryAlgotithmGreatestCommonDevisor(numbers);
        }
        [TestCase(int.MinValue, 0)]
        [TestCase(1242342, int.MinValue)]
        [TestCase(int.MaxValue, int.MinValue)]
        public void BinaryAlgorithmGreatestCommonDivisor_IntMinValue_ArgumentException(int number1, int number2)
        {
            var ex = Assert.Catch<Exception>(() => IntExtension.BinaryAlgotithmGreatestCommonDevisor(number1, number2));

            StringAssert.Contains("Numbers can't be min value of integer", ex.Message);
        }
        [TestCase(int.MinValue, 0, int.MinValue)]
        [TestCase(1242342, int.MinValue, 423423423)]
        [TestCase(int.MaxValue, int.MinValue, 423)]
        public void BinaryAlgorithmGreatestCommonDivisor_IntMinValue_ArgumentException(int number1, int number2, int number3)
        {
            var ex = Assert.Catch<Exception>(() => IntExtension.BinaryAlgotithmGreatestCommonDevisor(number1, number2, number3));

            StringAssert.Contains("Numbers can't be min value of integer", ex.Message);
        }
        [TestCase(int.MinValue, 0, 432, 4124, 435, 0)]
        [TestCase(1242342, int.MinValue, 2, 0, 3, 0, 0, 0)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue, int.MaxValue, int.MaxValue)]
        public void BinaryAlgorithmGreatestCommonDivisor_IntMinValue_ArgumentException(params int[] numbers)
        {
            var ex = Assert.Catch<Exception>(() => IntExtension.BinaryAlgotithmGreatestCommonDevisor(numbers));

            StringAssert.Contains("Numbers can't be min value of integer", ex.Message);
        }
        #endregion
    }
}
