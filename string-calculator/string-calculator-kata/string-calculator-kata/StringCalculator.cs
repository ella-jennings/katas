using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace string_calculator_kata
{
    public partial class StringCalculatorTests
    {
        public class StringCalculator
        {
            public string Add(string stringOfNumbers)
            {
                if (string.IsNullOrEmpty(stringOfNumbers))
                    return "0";

                {
                    var result = "";
                    var sum = 0;
                    string[] stringArray =  stringOfNumbers.Split(',','\n') ;

                    foreach (string number in stringArray)
                    {
                        var stringNumber = Convert.ToInt32(number);
                        if (stringNumber < 1)
                        {
                            throw new AssertFailedException(NegativeNumberException(stringArray));
                        }
                        sum += stringNumber;
                    }
                    result = sum.ToString();
                    return result;
                }
            }

            private string NegativeNumberException(string[] stringArray)
            {
                string result = "Negative numbers not allowed: ";

                foreach (string number in stringArray)
                {
                    var stringNumber = Convert.ToInt32(number);
                    if (stringNumber < 1)
                    {
                        result += number + ", ";
                    }
                }
                result = result.Substring(0, result.Length - 2);
                return result;
            }
        }
    }
}