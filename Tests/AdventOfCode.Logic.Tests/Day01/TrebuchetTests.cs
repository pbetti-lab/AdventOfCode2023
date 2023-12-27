using AdventOfCode.Logic.Day01;

namespace AdventOfCode.Logic.Tests.Day01
{
    public class TrebuchetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCalibrationValuesSum_WithValidInput_ShouldReturnCorrectValuesSum()
        {
            string inputText = "1abc2"
                + Environment.NewLine + "pqr3stu8vwx"
                + Environment.NewLine + "a1b2c3d4e5f"
                + Environment.NewLine + "treb7uchet";

            Assert.That(Trebuchet.GetCalibrationValuesSum(inputText), Is.EqualTo(142));
        }

        [Test]
        public void GetCalibrationValuesWithLiteralsSum_WithValidInput_ShouldReturnCorrectValuesWithLiteralsSum()
        {
            string inputText = "two1nine"
                + Environment.NewLine + "eightwothree"
                + Environment.NewLine + "abcone2threexyz"
                + Environment.NewLine + "twone"
                + Environment.NewLine + "xtwone3four"
                + Environment.NewLine + "4nineeightseven2"
                + Environment.NewLine + "zoneight234"
                + Environment.NewLine + "sevenine"
                + Environment.NewLine + "7pqrstsixteen"
                + Environment.NewLine + "one7twone";

            Assert.That(Trebuchet.GetCalibrationValuesWithLiteralsSum(inputText), Is.EqualTo(392));
        }
    }
}