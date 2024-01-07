using AdventOfCode.Logic.Day03;

namespace AdventOfCode.Console.Day3
{
	internal static class GearRatiosPuzzle
	{
		public static void Part1()
		{
			try
			{
				InternalPart1();
			}
			catch (Exception ex)
			{
				ShowExitMessage($"Warning: error occour during the proccess. Message: {ex.Message}");
			}
		}

		public static void Part2()
		{
			try
			{
				InternalPart2();
			}
			catch (Exception ex)
			{
				ShowExitMessage($"Warning: error occour during the proccess. Message: {ex.Message}");
			}
		}


		private static void InternalPart1()
		{
			if (!IsValidInputDocumentFilePath(out string inputDocumentFilePath))
				return;

			var inputDocumentContent = File.ReadAllText(inputDocumentFilePath);

			var result = GearRatios.GetGearPartNumbers(inputDocumentContent)
				.Sum();

			ShowExitMessage($"Gear ratios value result is: {result}");
		}

		private static void InternalPart2()
		{
			if (!IsValidInputDocumentFilePath(out string inputDocumentFilePath))
				return;

			var inputDocumentContent = File.ReadAllText(inputDocumentFilePath);

			var result = GearRatios.GetGearRatios(inputDocumentContent)
				.Sum();

			ShowExitMessage($"Gear ratios value result is: {result}");
		}

		private static bool IsValidInputDocumentFilePath(out string filePath)
		{
			System.Console.WriteLine("Enter the path for the input document File");
			filePath = System.Console.ReadLine() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(filePath))
				ShowExitMessage("Invalid file path. Program will terminate.");

			return !string.IsNullOrWhiteSpace(filePath);
		}

		private static void ShowExitMessage(string message)
		{
			System.Console.WriteLine();
			System.Console.WriteLine(message);
			System.Console.WriteLine("Press any key to exit the window.");
			System.Console.ReadLine();
		}
	}
}
