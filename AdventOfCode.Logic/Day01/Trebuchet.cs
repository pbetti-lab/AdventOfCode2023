namespace AdventOfCode.Logic.Day01
{
    public static class Trebuchet
    {
        public static int GetCalibrationValuesSum(string calibrationDocument)
        {
            int result = 0;

			foreach (var line in calibrationDocument.Split(Environment.NewLine))
			{
				var charNumericValuesAsInt = CalibrationDocumentParser.GetCharNumericValuesAsInt(line);
				
				if (charNumericValuesAsInt.Any())
					result += charNumericValuesAsInt.First() * 10 + charNumericValuesAsInt.Last();
			}

            return result;
        }

        public static int GetCalibrationValuesWithLiteralsSum(string calibrationDocument)
        {
			int result = 0;

			foreach (var line in calibrationDocument.Split(Environment.NewLine))
			{
				var numericValuesAsIntFromLeftToRight = CalibrationDocumentParser.GetCharAndLiteralNumericValuesAsIntFromLeftToRight(line);
				var numericValuesAsIntFromRightToLeft = CalibrationDocumentParser.GetCharAndLiteralNumericValuesAsIntFromRightToLeft(line);

				if (numericValuesAsIntFromLeftToRight.Any() && numericValuesAsIntFromRightToLeft.Any())
					result += numericValuesAsIntFromLeftToRight.First() * 10 + numericValuesAsIntFromRightToLeft.Last();
			}

			return result;
		}
	}
}