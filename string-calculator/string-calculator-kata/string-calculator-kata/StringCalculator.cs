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
                var firstChar = stringOfNumbers.First();
                var numbers = SplitStringIntoInts_WithDelimiterIfPresent(stringOfNumbers, firstChar);
                
                if (numbers.Any(x => IsNegative(x)))
                {
                    var negativeNumbers = numbers.Where(x => IsNegative(x));
                    throw new AssertFailedException(CreateNegativeNumberExceptionMessage(negativeNumbers));
                }

                foreach (var number in numbers)
                {
                    sum += number;
                }


                var result = sum.ToString();
                return result;

            }

            private string CreateNegativeNumberExceptionMessage(IEnumerable<int> negativeNumbers)
            {
                string result = "Negative numbers not allowed: ";
                result += string.Join(", ", negativeNumbers);
                return result;
            }

            private static bool IsNegative(int number)
            {
                return number < 0;
            }

            private static bool IsNumber(char firstChar)
            {
                return (firstChar > 47 && firstChar < 58 );
            }

            private static bool StringStartsWithDelimiter(string inputString, char firstChar)
            {
                return (!IsNumber(firstChar) && inputString[1] == '\n');
            }

            private IEnumerable<int> SplitStringIntoInts_WithDelimiterIfPresent(string inputString, char firstChar)
            {

                IEnumerable<int> numbers;
                if (StringStartsWithDelimiter(inputString, firstChar))
                {
                    inputString = TrimDelimiter(inputString, firstChar);
                    numbers = inputString.Split(firstChar, ',', '\n').Select(x => Convert.ToInt32(x));
                }
                else numbers = inputString.Split(',', '\n').Select(x => Convert.ToInt32(x));

                return numbers;
            }

            private static string TrimDelimiter(string inputString, char delimiter)
            {
                return inputString.TrimStart(delimiter, '\n'); 
            }
        }
    }
}