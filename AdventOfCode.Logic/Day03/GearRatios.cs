using System.Diagnostics.SymbolStore;

namespace AdventOfCode.Logic.Day03
{
	public class GearRatios
	{
		public static IEnumerable<int> GetGearPartNumbers(string schematic)
		{
			var result = new List<int>();
			
			var schematicLines = schematic.Split(Environment.NewLine);

			int totalLinesIndex = schematicLines.Length - 1;
			int totalCharsIndex = schematicLines[0].Length - 1;

			for (int i = 0; i <= totalLinesIndex; i++)
			{
				for (int j = 0; j <= totalCharsIndex; j++)
				{
					if (char.IsDigit(schematicLines[i][j]))
					{
						var validCoordinates = GetValidCoordinatesAroundDigit(totalLinesIndex, totalCharsIndex, i, j);

						bool isThereSymbolNearDigit = validCoordinates
							.Any(coords => IsSymbolNotPeriods(schematicLines[coords.Item1][coords.Item2]));

						if (isThereSymbolNearDigit) 
							result.Add(GetPartNumber(schematicLines[i], ref j, totalCharsIndex));
					}
				}
			}

			return result;
		}


		public static IEnumerable<int> GetGearRatios(string schematic)
		{
			var partNumberInfoList = new List<PartNumberInfo>();

			var schematicLines = schematic.Split(Environment.NewLine);

			int totalLinesIndex = schematicLines.Length - 1;
			int totalCharsIndex = schematicLines[0].Length - 1;

			for (int i = 0; i <= totalLinesIndex; i++)
			{
				for (int j = 0; j <= totalCharsIndex; j++)
				{
					if (char.IsDigit(schematicLines[i][j]))
					{
						var validCoordinates = GetValidCoordinatesAroundDigit(totalLinesIndex, totalCharsIndex, i, j);

						var getSymbolsNearDigit = validCoordinates
							.Where(coords => IsSymbolNotPeriods(schematicLines[coords.Item1][coords.Item2]));

						foreach (var coords in getSymbolsNearDigit)
						{
							int partNumber = GetPartNumber(schematicLines[i], ref j, totalCharsIndex);

							partNumberInfoList.Add(
								new PartNumberInfo
								{
									Symbol = schematicLines[coords.Item1][coords.Item2],
									PartNumber = partNumber,
									Row = coords.Item1,
									Col = coords.Item2,
								}
							);
						}
					}
				}
			}

			return partNumberInfoList.Where(info => info.Symbol == '*')
				.GroupBy(info =>
					new { info.Row, info.Col },
					info => info.PartNumber,
					(key, g) => new { Count = g.Count(), PartNumbers = g.ToList() })
				.Where(filteredInfo => filteredInfo.Count == 2)
				.Select(filteredInfo => filteredInfo.PartNumbers[0] * filteredInfo.PartNumbers[1]);
		}

		public record PartNumberInfo()
		{
			public char Symbol { get; init; }

			public int PartNumber { get; init; }

			public int Row { get; init; }

			public int Col { get; init; }
		}

		private static bool IsSymbolNotPeriods(char ch) => 
			   !char.IsLetterOrDigit(ch)
			&& ch != '.';

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
