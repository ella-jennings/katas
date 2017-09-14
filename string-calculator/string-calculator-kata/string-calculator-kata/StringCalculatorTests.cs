using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace string_calculator_kata
{ 
 
    [TestClass]
    public partial class StringCalculatorTests
    {
     
        [TestCase("", "0")]
        [TestCase("0", "0")]
        [TestCase("1", "1")]
        [TestCase("1,2", "3")]
        [TestCase("1,2,3", "6")]
        [TestCase("1000,2,3", "5")]
        [TestCase("500,700,3", "203")]
        [TestCase("1\n2","3")]
        [TestCase("1,2\n3", "6")]
        [TestCase(";\n1,2;3", "6")]
        [TestCase(".\n1,2.3", "6")]
        [TestCase("-\n1-2-3", "6")]
      
        public void InputShouldReturnExpectedOutput(string expectedInput, string expectedOutput)
        {
            var stringSum = new StringCalculator();
            Assert.That(stringSum.Add(expectedInput), Is.EqualTo(expectedOutput));
        }

        [TestCase("-1", "Negative numbers not allowed: -1")]
        [TestCase("1,-2", "Negative numbers not allowed: -2")]
        [TestCase("-1,-2\n-3", "Negative numbers not allowed: -1, -2, -3")]
        public void NegativeNumbersShouldThrowException(string expectedInput, string expectedOutput)
        {
            var stringSum = new StringCalculator();
            var exception = Assert.Throws<AssertFailedException>(() => stringSum.Add(expectedInput));
            Assert.AreEqual(expectedOutput, exception.Message);
        }
    }
}

