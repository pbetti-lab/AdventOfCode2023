namespace AdventOfCode.Logic.Day01
{
    public static class CalibrationDocumentParser
    {
        #region fields

        private static readonly Dictionary<string, string> _literalToNumericString = new()
        {
            { "one", "1" },
            { "two", "2"},
            { "three", "3"},
            { "four", "4"},
            { "five", "5"},
            { "six", "6"},
            { "seven", "7"},
            { "eight", "8"},
            { "nine", "9"},
        };

		#endregion

		#region public methods

		public static IEnumerable<int> GetCharNumericValuesAsInt(string text)
		{
			return text
				.Where(CharIsNumericValue)
				.Select(ParseCharNumericValueToInt);
		}

		public static IEnumerable<int> GetCharAndLiteralNumericValuesAsIntFromLeftToRight(string text)
		{
			string textToParse = text;

			while (IsThereLiteralToConvertFromLeftToRight(textToParse, out string literal))
				textToParse = textToParse.Replace(literal, _literalToNumericString[literal]);

			return GetCharNumericValuesAsInt(textToParse);
		}

		public static IEnumerable<int> GetCharAndLiteralNumericValuesAsIntFromRightToLeft(string text)
		{
			string textToParse = text;

			while (IsThereLiteralToConvertFromRightToLeft(textToParse, out string literal))
				textToParse = textToParse.Replace(literal, _literalToNumericString[literal]);

			return GetCharNumericValuesAsInt(textToParse);
		}

		#endregion

		#region private methods

		private static bool CharIsNumericValue(char singleChar) =>
			char.IsNumber(singleChar);

		private static int ParseCharNumericValueToInt(char singleChar) =>
            int.Parse(singleChar.ToString());

        private static bool IsThereLiteralToConvertFromLeftToRight(string text, out string literal)
        {
            var literalToNumericStringKey = _literalToNumericString
                .Select(element =>
                    new
                    {
                        startPos = text.IndexOf(element.Key),
                        key = element.Key
                    })
                .Where(item => item.startPos >= 0)
                .OrderBy(item => item.startPos)
                .FirstOrDefault()
                ?.key;

			literal = literalToNumericStringKey ?? string.Empty;

            return !string.IsNullOrWhiteSpace(literal);
        }

        private static bool IsThereLiteralToConvertFromRightToLeft(string text, out string literal)
        {
			var literalToNumericStringKey = _literalToNumericString
                .Select(element =>
                    new
                    {
                        startPos = text.LastIndexOf(element.Key),
                        key = element.Key
                    })
                .Where(item => item.startPos >= 0)
                .OrderByDescending(item => item.startPos)
                .FirstOrDefault()
                ?.key;

			literal = literalToNumericStringKey ?? string.Empty;

			return !string.IsNullOrWhiteSpace(literal);
        }
        
		#endregion
    }
}