using AdventOfCode.Logic.Day01;

namespace AdventOfCode.Logic.Tests.Day01
{
	public class CalibrationDocumentParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

		[TestCase("1abc2", new int[] { 1, 2 })]
		[TestCase("pqr3stu8vwx", new int[] { 3, 8 })]
		[TestCase("a1b2c3d4e5f", new int[] { 1, 2, 3, 4, 5 })]
		[TestCase("treb7uchet", new int[] { 7 })]
		[TestCase("", new int[] { })]
		public void GetCharNumericValuesAsInt_WhenTextIsGiven_ShouldReturnNumericValuesAsIntList(string text, int[] expectedResult)
		{
			var result = CalibrationDocumentParser.GetCharNumericValuesAsInt(text);

			Assert.That(result.ToArray, Is.EquivalentTo(expectedResult));
		}

        [TestCase("two1nine", new int[] { 2, 1, 9 })]
        [TestCase("eightwothree", new int[] { 8, 3 })]
        [TestCase("xtwone3four", new int[] { 2, 3, 4 })]
        [TestCase("sevenineight", new int[] { 7, 8})]
        [TestCase("one7twone", new int[] { 1, 7, 1 })]
		[TestCase("sevenine", new int[] { 7 })]
		public void GetCharAndLiteralNumericValuesAsIntFromLeftToRight_WhenTextIsGiven_ShouldReturnNumericValuesAsIntList(string text, int[] expectedResult)
        {
            var result = CalibrationDocumentParser.GetCharAndLiteralNumericValuesAsIntFromLeftToRight(text);

			Assert.That(result.ToArray, Is.EquivalentTo(expectedResult));
		}

		[TestCase("two1nine", new int[] { 2, 1, 9 })]
		[TestCase("eightwothree", new int[] { 2, 3 })]
		[TestCase("xtwone3four", new int[] { 1, 3, 4 })]
		[TestCase("sevenineight", new int[] { 7, 8 })]
		[TestCase("one7twone", new int[] { 1, 7, 1 })]
		[TestCase("sevenine", new int[] { 9 })]
		public void GetCharAndLiteralNumericValuesAsIntFromRightToLeft_WhenTextIsGiven_ShouldReturnNumericValuesAsIntList(string text, int[] expectedResult)
		{
			var result = CalibrationDocumentParser.GetCharAndLiteralNumericValuesAsIntFromRightToLeft(text);

			Assert.That(result.ToArray, Is.EquivalentTo(expectedResult));
		}
	}
}