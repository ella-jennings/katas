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
        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1\n2",3)]
        [TestCase("1,2\n3", 6)]
        [TestCase("-1"), "Negative numbers not allowed: -1"]
        public void InputShouldReturnExpectedOutput(string expectedInput, int expectedOutput)
        {
            string stringOfNumbers = expectedInput;

            int stringSum = new StringCalculator().Add(stringOfNumbers);

            Assert.That(stringSum, Is.EqualTo(expectedOutput));
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
                    string[] stringArray =  stringOfNumbers.Split(',','\n') ;

                    foreach (string number in stringArray)
                    {
                        var stringNumber = Convert.ToInt32(number);
                        if (stringNumber < 1)
                        {
                            Console.WriteLine("Negative numbers not allowed: -1");
                        }
                        result += stringNumber;
                    }
              
                    return result;
                }
            }
        }
    }
}

