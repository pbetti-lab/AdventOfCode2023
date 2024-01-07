using AdventOfCode.Logic.Day01;
using AdventOfCode.Logic.Day02;

namespace AdventOfCode.Console.Day02
{
    internal static class CubeConundrumPuzzle
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


		#region private methods

		private static void InternalPart1()
		{
			if (!IsValidInputDocumentFilePath(out string inputDocumentFilePath))
				return;

			if (!IsValidValidCubeSetConfiguration(out string validCubeSetConfiguration))
				return;

			var cubeConundrum = new CubeConundrum();
			
			var inputDocumentContent = File.ReadAllText(inputDocumentFilePath);
			foreach (string line in inputDocumentContent.Split(Environment.NewLine))
				cubeConundrum.AddCubeGame(line);
			
			var result = cubeConundrum.GetValidGameIds(validCubeSetConfiguration)
				.Sum();

			ShowExitMessage($"Cube Conundrum value result is: {result}");
		}

		private static void InternalPart2()
		{
			if (!IsValidInputDocumentFilePath(out string inputDocumentFilePath))
				return;

			var cubeConundrum = new CubeConundrum();

			var inputDocumentContent = File.ReadAllText(inputDocumentFilePath);
			foreach (string line in inputDocumentContent.Split(Environment.NewLine))
				cubeConundrum.AddCubeGame(line);

			var result = cubeConundrum
				.GetValidCubeSetConfigurationPerGame()
				.Select(cubeSet => cubeSet.RedCubesNumber * cubeSet.GreenCubesNumber * cubeSet.BlueCubesNumber)
				.Sum();

			ShowExitMessage($"Cube Conundrum value result is: {result}");
		}

		private static bool IsValidInputDocumentFilePath(out string filePath)
		{
			System.Console.WriteLine("Enter the path for the input document File");
			filePath = System.Console.ReadLine() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(filePath))
				ShowExitMessage("Invalid file path. Program will terminate.");

			return !string.IsNullOrWhiteSpace(filePath);
		}

		private static bool IsValidValidCubeSetConfiguration(out string validcubeSetConfiguration)
		{
			System.Console.WriteLine("Enter the valid cube set configuration");
			validcubeSetConfiguration = System.Console.ReadLine() ?? string.Empty;

			if (string.IsNullOrWhiteSpace(validcubeSetConfiguration))
				ShowExitMessage("Invalid cube set configuration. Program will terminate.");

			return !string.IsNullOrWhiteSpace(validcubeSetConfiguration);
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
