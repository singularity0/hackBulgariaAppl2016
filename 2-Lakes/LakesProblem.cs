using System;

namespace Lakes
{
    public class LakesEngineCalculator
    {
        public static float CalculateLakeVolume(string arr)
        {
            float volume = 0;
            int levelUnderWater = 0;
            int levelAboveWater = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 'd')
                {
                    if (levelAboveWater > 0)
                    {
                        levelAboveWater -= 1;
                        continue;
                    }

                    volume += (levelUnderWater + 0.5f);
                    levelUnderWater += 1;
                }
                else if (arr[i] == 'h')
                {
                    if (levelAboveWater > 0)
                    {
                        continue;
                    }

                    volume += levelUnderWater;
                }
                else if (arr[i] == 'u')
                {
                    if (levelUnderWater == 0 && levelAboveWater >= 0)
                    {
                        levelAboveWater += 1;
                        continue;
                    }

                    volume += levelUnderWater - 0.5f;
                    levelUnderWater -= 1;
                }
            }

            return volume;
        }

        public static string NormalizaToLowerLetters(string input)
        {
            string inputValidated = input.ToLower();

            return inputValidated;
        }

        public static void ValidateInputDirections(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!"duh".Contains(input[i].ToString()))
                {
                    throw new ArgumentOutOfRangeException("Invalid commands. only 'd' , 'u' , 'h' are allowed");
                }
            }
        }

        public static float VolumeMupltiplier(float result)
        {
            float factor = 1000;
            return result * factor;
        }
    }

    class Lakes
    {
        static void Main()
        {
            //var commandsInput = "dddhhhuuhhuuuhdddduu";
            //var commandsInput = "ddhhddhuhhuuu";
            //var commandsInput = "ddhhUu";
            string commandsInput = Console.ReadLine();
            string validatedToLower = LakesEngineCalculator.NormalizaToLowerLetters(commandsInput);
            LakesEngineCalculator.ValidateInputDirections(validatedToLower);

            float result = LakesEngineCalculator.CalculateLakeVolume(validatedToLower);
            float resultInLittersPerSqaure = LakesEngineCalculator.VolumeMupltiplier(result);
            Console.WriteLine(resultInLittersPerSqaure);
        }
    }
}
/*using NUnit.Framework;
using System;

namespace Lakes.Tests
{
    [TestFixture]
    public class LakesEngineCalculatorTests
    {
        [TestCase("DUH", "duh")]
        [TestCase("D", "d")]
        [TestCase("hud", "hud")]
        [TestCase("0", "0")]
        [TestCase("HuDuHHdd", "huduhhdd")]
        public void NormalizaToLowerLetters_WhenValidInputPassed_ShouldreturnInputToLower(string inn, string lowered)
        {
            var result = LakesEngineCalculator.NormalizaToLowerLetters(inn);

            Assert.AreEqual(result, lowered);
        }

        [TestCase("duh")]
        [TestCase("d")]
        [TestCase("hhhhhhhhhh")]
        [TestCase("hudhduddhdudhddhdduhdudhduuudhddduu")]
        public void ValidateInputDirections_WhenValidInputPassed_ShouldNotThrow(string inn)
        {
            Assert.DoesNotThrow(()=> LakesEngineCalculator.ValidateInputDirections(inn));
        }

        [TestCase("a")]
        [TestCase("hudsudd")]
        [TestCase("hudb")]
        [TestCase("oioqw")]
        public void ValidateInputDirections_WhenInvalidInputPassed_ShouldThrow(string inn)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => LakesEngineCalculator.ValidateInputDirections(inn));
        }

        [TestCase("ddhhuu", 8)]
        [TestCase("ddhhddhuhhuuu", 30)]
        [TestCase("dddhhhuuhhuuuhdddduu", 24)]
        public void CalculateLakeVolume_WhenInputPassed_ShouldReturnProperResult(string inn, float result)
        {
            var lakeEngine = LakesEngineCalculator.CalculateLakeVolume(inn);

            Assert.AreEqual(lakeEngine, result);
        }

        [TestCase(5)]
        [TestCase(0)]
        [TestCase(1.1f)]
        public void VolumeMupltiplier_WhenValidInputPassed_ShouldProperlyMultiply(float input)
        {
            var factor = 1000;
            var result = input * factor;

            Assert.AreEqual(result, LakesEngineCalculator.VolumeMupltiplier(input));
        }

    }
}*/

