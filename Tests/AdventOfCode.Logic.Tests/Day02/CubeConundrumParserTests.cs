using AdventOfCode.Logic.Day02;

namespace AdventOfCode.Logic.Tests.Day02
{
	internal class CubeConundrumParserTests
	{
		[TestCase("3 blue, 4 red", new int[] { 4, 0, 3})]
		[TestCase("1 red, 2 green, 6 blue", new int[] { 1, 2, 6})]
		[TestCase("3 green, 4 blue, 6 red", new int[] { 6, 3, 4 })]
		[TestCase("2 green", new int[] { 0, 2, 0 })]
		[TestCase("", new int[] { 0, 0, 0 })]
		public void GetCubeSet_WithValidCubeSetString_ShouldReturnValidCubeSetObject(string cubeSetString, int[] expectedResults)
		{
			var cubeSet = CubeConundrumParser.GetCubeSet(cubeSetString);
			
			Assert.Multiple(() =>
			{
				Assert.That(cubeSet.RedCubesNumber, Is.EqualTo(expectedResults[0]));
				Assert.That(cubeSet.GreenCubesNumber, Is.EqualTo(expectedResults[1]));
				Assert.That(cubeSet.BlueCubesNumber, Is.EqualTo(expectedResults[2]));
			});
		}

		[TestCase("Game 1: 1 blue, 2 green", new int[] { 1, 0, 2, 1 })]
		[TestCase("Game 2: 3 red", new int[] { 2, 3, 0, 0 })]
		[TestCase("Game 3:", new int[] { 3, 0, 0, 0 })]
		public void GetCubeGame_WithValidCubeSetString_ShouldReturnValidCubeGameObject(string cubeSetString, int[] expectedResults)
		{
			var cubeGame = CubeConundrumParser.GetCubeGame(cubeSetString);

			Assert.Multiple(() =>
			{
				Assert.That(cubeGame.Id, Is.EqualTo(expectedResults[0]));
				Assert.That(cubeGame.CubeSets[0].RedCubesNumber, Is.EqualTo(expectedResults[1]));
				Assert.That(cubeGame.CubeSets[0].GreenCubesNumber, Is.EqualTo(expectedResults[2]));
				Assert.That(cubeGame.CubeSets[0].BlueCubesNumber, Is.EqualTo(expectedResults[3]));
			});
		}
	}
}
