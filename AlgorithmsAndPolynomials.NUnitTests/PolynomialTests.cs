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
        [TestCase(new double[]{1,2,-4,0},new double[]{1,-2,3,4,5},ExpectedResult = "2 =  -0*x^1 -1*x^2 +4*x^3 +5*x^4")]
        [TestCase(new double[] { 1, -2, 3, 4, 5 }, new double[] { 1, 2, -4, 0 }, ExpectedResult = "2 =  -0*x^1 -1*x^2 +4*x^3 +5*x^4")]
        [TestCase(new double[]{ 2.25, 4.15, 3.14, 6.20 },new double[]{ 1.123, 9, 4.51, 34, 12, double.MaxValue, double.MinValue},ExpectedResult = "3,373 =  +13,15*x^1 +7,65*x^2 +40,2*x^3 +12*x^4 +1,79769313486232E+308*x^5 -1,79769313486232E+308*x^6")]
        public string OperatorPlus_2Polinomials_AnotherPolyWichIsSumOfArguments(double[] obj1,double[] obj2)
        {
            Polynomial poly1=new Polynomial(obj1);
            Polynomial poly2=new Polynomial(obj2);

            return (poly1 + poly2).ToString();
        }
    }
}
