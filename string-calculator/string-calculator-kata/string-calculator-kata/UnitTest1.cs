using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace string_calculator_kata
{

    [TestClass]
    public class StringCalculatorTests
    {
        [Test]
        public void EmptyStringShouldReturn0()
        {
            string stringOfNumbers = "";

            int stringSum = new StringCalculator().Add(stringOfNumbers);

            Assert.That(stringSum, Is.EqualTo(0));
        }

        [Test]
        public void StringOf1ShouldReturn1()
        {
            string stringOfNumbers = "1";

            int stringSum = new StringCalculator().Add(stringOfNumbers);

            Assert.That(stringSum, Is.EqualTo(1));
        }

    }

    public class StringCalculator
    {
       public int Add(string stringToAdd)
       {
           if (!string.IsNullOrEmpty(stringToAdd))
               return 1;

           return 0;
       }
    }
}
