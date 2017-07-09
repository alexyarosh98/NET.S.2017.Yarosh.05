using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgorithmsAndPolynomials.NUnitTests
{
    [TestFixture]
    class PolynomialTests
    {
        [TestCase(new double[]{1,2,-4,0},new double[]{1,-2,3,4,5},ExpectedResult = "+ 5*x^4 + 4*x^3 - 1*x^2 - 0*x^1 = 2")]
        [TestCase(new double[] { 1, -2, 3, 4, 5 }, new double[] { 1, 2, -4, 0 }, ExpectedResult = "+ 5*x^4 + 4*x^3 - 1*x^2 - 0*x^1 = 2")]
        [TestCase(new double[] { }, new double[] { 1, 2, 3 }, ExpectedResult = "+ 3*x^2 + 2*x^1 = 1")]
        [TestCase(new double[]{1,2,3},new double[]{},ExpectedResult = "+ 3*x^2 + 2*x^1 = 1")]
        [TestCase(new double[]{ 2.25, 4.15, 3.14, 6.20 },new double[]{ 1.123, 9, 4.51, 34, 12, double.MaxValue, double.MinValue},ExpectedResult = "- 1,79769313486232E+308*x^6 + 1,79769313486232E+308*x^5 + 12*x^4 + 40,2*x^3 + 7,65*x^2 + 13,15*x^1 = 3,373")]
        public string OperatorPlus_2Polinomials_AnotherPolyWichIsSumOfArguments(double[] obj1,double[] obj2)
        {
            Polynomial poly1=new Polynomial(obj1);
            Polynomial poly2=new Polynomial(obj2);

            return (poly1 + poly2).ToString();
        }
        [TestCase(new double[]{1,23,4},100,ExpectedResult = "+ 4*x^2 + 23*x^1 = 101")]
        [TestCase(new double[]{},5,ExpectedResult = "0*x=5")]
        
        public string OperatorPlus_PolynomialPlusDouble_NewPolynomial(double[] obj1, double value)
        {
            Polynomial poly=new Polynomial(obj1);

            return (poly+value).ToString();
        }
        [TestCase(100, new double[] { 1, 23, 4 }, ExpectedResult = "+ 4*x^2 + 23*x^1 = 101")]
        [TestCase( 5, new double[] { }, ExpectedResult = "0*x=5")]
        public string OperatorPlus_DoublePlusPolynomial_NewPolynomial(double value, double[] obj1)
        {
            Polynomial poly = new Polynomial(obj1);

            return (value + poly).ToString();
        }

        [TestCase(new double[]{1,3,3,4,5},new double[]{1,2,7,4},ExpectedResult = "+ 5*x^4 - 0*x^3 - 4*x^2 + 1*x^1 = 0")]
        [TestCase(new double[] { 1, 2, 7, 4 }, new double[] { 1, 3, 3, 4, 5 }, ExpectedResult = "- 5*x^4 - 0*x^3 + 4*x^2 - 1*x^1 = 0")]
        [TestCase(new double[]{},new double[]{1,2,3},ExpectedResult = "- 3*x^2 - 2*x^1 = -1")]
        [TestCase(new double[]{1,2,3},new double[]{},ExpectedResult = "+ 3*x^2 + 2*x^1 = 1")]
        public string OperatorMinus_PolynomialMinusPolynomial_NewPolynomial(double[] obj1, double[] obj2)
        {
            Polynomial poly1=new Polynomial(obj1);
            Polynomial poly2=new Polynomial(obj2);

            return (poly1 - poly2).ToString();
        }
    }
}
