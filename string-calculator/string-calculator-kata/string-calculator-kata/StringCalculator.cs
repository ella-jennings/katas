using System;
using System.Collections.Generic;
using System.Linq;
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


                var sum = 0;
                var numbers = stringOfNumbers.Split(',', '\n').Select(x => Convert.ToInt32(x));

                if (numbers.Any(x => IsNegative(x)))
                {
                    var negativeNumbers2 = numbers.Where(x => IsNegative(x));
                    throw new AssertFailedException(CreateNegativeNumberExceptionMessage(negativeNumbers2));
                }

                foreach (var number in numbers)
                {
                    sum += number;
                }


                var result = sum.ToString();
                return result;

            }

            private static bool IsNegative(int number)
            {
                return number < 0;
            }

            private string CreateNegativeNumberExceptionMessage(IEnumerable<int> negativeNumbers)
            {
                string result = "Negative numbers not allowed: ";
                result += string.Join(", ", negativeNumbers);
                return result;
            }
        }
    }
}