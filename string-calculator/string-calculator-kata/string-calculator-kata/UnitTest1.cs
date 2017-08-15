using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace string_calculator_kata
{

    [TestClass]
    public class UnitTest1
    {
        [Test]
        public void EmptyStringShouldReturn0()
        {
            string stringOfNumbers = "";

            int stringSum = new StringCalculator().Add(stringOfNumbers);

            Assert.That(stringSum, Is.EqualTo(0));
        }

     
    }

    public class StringCalculator
    {
       public int Add(string stringToAdd)
       {
           return 0;
       }
    }
}
