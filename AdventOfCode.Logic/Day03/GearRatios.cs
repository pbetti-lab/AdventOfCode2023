namespace AdventOfCode.Logic.Day03
{
	public class GearRatios
	{
		public static IEnumerable<int> GetGearPartNumbers(string schematic)
		{
			var result = new List<int>();
			
			var schematicLines = schematic.Split(Environment.NewLine);

			bool isSymbolNotPeriods(char ch) => !char.IsLetterOrDigit(ch)
				&& ch != '.';

			int totalLinesIndex = schematicLines.Length - 1;
			int totalCharsIndex = schematicLines[0].Length - 1;

			for (int i = 0; i <= totalLinesIndex; i++)
				for (int j = 0; j <= totalCharsIndex; j++)
					if (char.IsDigit(schematicLines[i][j]))
					{
						var validCoordinates = GetValidCoordinatesAroundDigit(totalLinesIndex, totalCharsIndex, i, j);

						bool isThereSymbolNearDigit = validCoordinates
							.Any(coords => isSymbolNotPeriods(schematicLines[coords.Item1][coords.Item2]));

						if (isThereSymbolNearDigit) 
							result.Add(GetPartNumber(schematicLines[i], ref j, totalCharsIndex));
					}

			return result;
		}

		private static int GetPartNumber(string row, ref int colIndex, int totalColsIndex)
		{ 
			string partNumberString = row[colIndex].ToString();

			int leftReaderPos = 1;

			while (colIndex - leftReaderPos >= 0 && char.IsDigit(row[colIndex - leftReaderPos]))
			{
				partNumberString = row[colIndex - leftReaderPos].ToString() + partNumberString;
				leftReaderPos++;
			}

			int rightReaderPos = 1;
			while (colIndex + rightReaderPos <= totalColsIndex && char.IsDigit(row[colIndex + rightReaderPos]))
			{
				partNumberString += row[colIndex + rightReaderPos].ToString();
				rightReaderPos++;
			}

			colIndex += rightReaderPos;

			return int.Parse(partNumberString);
		}

		private static List<Tuple<int, int>> GetValidCoordinatesAroundDigit(int totalLinesIndex, int totalCharsIndex, int i, int j)
		{
			var resultList = new List<Tuple<int, int>>();

			// upper row
			if (i - 1 >= 0)
			{
				if (j - 1 >= 0)
					resultList.Add(new Tuple<int, int>(i - 1, j - 1));

				resultList.Add(new Tuple<int, int>(i - 1, j));

				if (j + 1 <= totalCharsIndex)
					resultList.Add(new Tuple<int, int>(i - 1, j + 1));
			}

			// middle row
			if (j - 1 >= 0)
				resultList.Add(new Tuple<int, int>(i, j - 1));

			if (j + 1 <= totalCharsIndex)
				resultList.Add(new Tuple<int, int>(i, j + 1));


			// lower row
			if (i + 1 <= totalLinesIndex)
			{
				if (j - 1 >= 0)
					resultList.Add(new Tuple<int, int>(i + 1, j - 1));

				resultList.Add(new Tuple<int, int>(i + 1, j));

				if (j + 1 <= totalCharsIndex)
					resultList.Add(new Tuple<int, int>(i + 1, j + 1));
			}

			return resultList;
		}
	}
}
