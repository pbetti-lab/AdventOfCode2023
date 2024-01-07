using AdventOfCode.Logic.Day01;

namespace AdventOfCode.Console.Day01
{
    internal static class TrebuchetPuzzle
	{
		#region public methods

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

		#endregion

		#region private methods

		private static void InternalPart1()
		{
			if (!IsValidCalibrationDocumentFilePath(out string calibrationDocumentFilePath))
				return;

			var calibrationDocumentContent = File.ReadAllText(calibrationDocumentFilePath);
			var result = Trebuchet.GetCalibrationValuesSum(calibrationDocumentContent);

			ShowExitMessage($"Trebuchet value result is: {result}");
		}

		private static void InternalPart2()
		{
			if (!IsValidCalibrationDocumentFilePath(out string calibrationDocumentFilePath))
				return;
			
			var calibrationDocumentContent = File.ReadAllText(calibrationDocumentFilePath);
			var result = Trebuchet.GetCalibrationValuesWithLiteralsSum(calibrationDocumentContent);

			ShowExitMessage($"Trebuchet value result is: {result}");
		}

		private static bool IsValidCalibrationDocumentFilePath(out string filePath)
		{
			System.Console.WriteLine("Enter the path for the Calibration Document File");
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

		#endregion
	}
}
