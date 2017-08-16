using System;
using System.Collections.Generic;
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

        [Test]
        public void StringOf2ShouldReturnSum()
        {
            string stringOfNumbers = "1,2";

            int stringSum = new StringCalculator().Add(stringOfNumbers);

            Assert.That(stringSum, Is.EqualTo(3));
        }

        public class StringCalculator
        {
            public int Add(string stringOfNumbers)
            {
   

                if (string.IsNullOrEmpty(stringOfNumbers))
                    return 0;
                else
                {
                    var result = 0;
                    string[] stringArray =  stringOfNumbers.Split(',');

                    foreach (string number in stringArray)
                    {
                        var stringNumber = Convert.ToInt32(number);
                        result += stringNumber;
                    }
              
                    return result;
                }
            }
        }
    }
}

