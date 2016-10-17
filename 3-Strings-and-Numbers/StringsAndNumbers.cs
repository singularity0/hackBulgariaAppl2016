using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace StringsAndNumbers
{
    class StringsAndNums
    {
        public static Dictionary<char, int> LetterCounter(string inputString)
        {
            Dictionary<char, int> letterCounter = new Dictionary<char, int>();

            foreach (var letter in inputString)
            {
                if (letterCounter.ContainsKey(letter))
                {
                    letterCounter[letter] += 1;
                }
                else
                {
                    letterCounter[letter] = 1;
                }
            }

            return letterCounter;
        }

        public static IOrderedEnumerable<KeyValuePair<char, int>> DictSorter(Dictionary<char, int> letterCounter)
        {
            var items = from pair in letterCounter
                        orderby pair.Value descending
                        select pair;
            return items;
        }

        public static Dictionary<char, int> GetOnlyTheMostFrequentTen(IOrderedEnumerable<KeyValuePair<char, int>> items)
        {
            int counter = 9;
            Dictionary<char, int> encodingMapper = new Dictionary<char, int>();

            foreach (KeyValuePair<char, int> pair in items)
            {
                if (counter < 0)
                {
                    break;
                }
                encodingMapper[pair.Key] = counter;
                //Console.WriteLine(encodingMapper[pair.Key]);
                counter--;
            }
            return encodingMapper;
        }

        public static void CheckMostFrequentElementsOnConsole(Dictionary<char, int> encodingMapper)
        {
            foreach (KeyValuePair<char, int> pair in encodingMapper)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }

        public static string GetEncodedStringFromInput( string inputString, Dictionary<char, int> encodingMapper)
        {
            string encodedString = inputString;

            foreach (KeyValuePair<char, int> pair in encodingMapper)
            {
                encodedString = encodedString.Replace(pair.Key.ToString(), pair.Value.ToString());
            }

            return encodedString;
        }

        public static BigInteger CalculateSumOfNumbers(string encodedString)
        {
            BigInteger sum = 0;
            var number = "";
            var encodedStringForParsing = encodedString;

            while (encodedStringForParsing.Length > 0)
            {

                if (char.IsNumber(encodedStringForParsing[0]))
                {
                    number += encodedStringForParsing[0];

                    if (encodedStringForParsing.Length-1 == 0)
                    {
                        sum += BigInteger.Parse(number);
                        break;
                    }
                }
                else
                {
                    BigInteger result;
                    if (BigInteger.TryParse(number, out result) == true)
                    {
                        sum += BigInteger.Parse(number);
                        number = "";
                    }
                }

                encodedStringForParsing = encodedStringForParsing.Substring(1);
            }

            return sum;
        }

        static void Main()
        {
            string inputString = Console.ReadLine(); 
            Dictionary<char, int> letterCounter = LetterCounter(inputString);
            var items = DictSorter(letterCounter);
            var encodingMapper = GetOnlyTheMostFrequentTen(items);
            //CheckMostFrequentElementsOnConsole(encodingMapper);
            var encodedString = GetEncodedStringFromInput(inputString, encodingMapper);
            //Console.WriteLine(encodedString);
            var result = CalculateSumOfNumbers(encodedString);
            Console.WriteLine(result);
        }    
    }
}
/*using System.Collections.Generic;
using System.Numerics;
using StringsAndNumbers;
using NUnit.Framework;


namespace StringsAndNumbers.Tests
{
    [TestFixture]
    public class StringsAndNumsTests
    {
        [TestCase("bbcccddddeeeeeffffffggggggghhhhhhhhiiiiiiiiijjjjjjjjjja", 10)]
        [TestCase("abc", 3)]
        [TestCase("a", 1)]
        [TestCase("aaaaaa", 1)]
        [TestCase("", 0)]
        [TestCase("w#\a:\\?uxv?xvxx@axx?\\u\\^:a~wx?x-:u\v\a:???^xv?x??cwwx_?uhvc:w<v,:ucwzuaw::uaucwaa^ra:;?:\\?xbw[^^:w::ca\\wcvl\\:%", 27)]
        public void LetterCounter_PredefinedInout_SHouldReturnNumberOfDifferentLetters(string input, int result)
        {
            var strNumsInstance = StringsAndNums.LetterCounter(input);
            Assert.AreEqual(strNumsInstance.Count, result);
        }
    }
}*/
