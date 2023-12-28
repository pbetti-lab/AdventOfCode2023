using AdventOfCode.Logic.Day02;

namespace AdventOfCode.Tests.Day02
{
	internal class CubeConundrumTests
	{
		[TestCase("12 red, 13 green, 14 blue", new int[] { 12, 13, 14 })]
		[TestCase("12 red, 14 blue, 13 green", new int[] { 12, 13, 14 })]
		[TestCase("13 green, 14 blue, 12 red", new int[] { 12, 13, 14 })]
		[TestCase("14 blue", new int[] { 0, 0, 14 })]
		[TestCase("14 red", new int[] { 14, 0, 0 })]
		[TestCase("", new int[] { 0, 0, 0 })]
		public void CubeConundrum_WhenInstantiated_ShouldContainTheValidConfiguration(string validConfiguration, int[] expectedResult)
		{
			var cubeConundrum = new CubeConundrum(validConfiguration);
			
			Assert.Multiple(() =>
			{
				Assert.That(cubeConundrum.ValidCubeSetConfiguration.RedCubesNumber, Is.EqualTo(expectedResult[0]));
				Assert.That(cubeConundrum.ValidCubeSetConfiguration.GreenCubesNumber, Is.EqualTo(expectedResult[1]));
				Assert.That(cubeConundrum.ValidCubeSetConfiguration.BlueCubesNumber, Is.EqualTo(expectedResult[2]));
			});
		}

		[Test]
		public void CubeConundrum_WhenInstantiated_ShouldContainEmptyCubeGames()
		{
			string validConfiguration = "12 red, 13 green, 14 blue";

			var cubeConundrum = new CubeConundrum(validConfiguration);

			Assert.That(cubeConundrum.CubeGames, Is.Empty);
		}

		[Test]
		public void AddCubeGame_WithValidCubeGameString_ShouldReturnValidGameSets()
		{
			string validConfiguration = "12 red, 13 green, 14 blue";

			var cubeConundrum = new CubeConundrum(validConfiguration);
			cubeConundrum.AddCubeGame("Game 5: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");

			Assert.Multiple(() =>
			{
				Assert.That(cubeConundrum.CubeGames, Has.Count.EqualTo(1));
				
				Assert.That(cubeConundrum.CubeGames[0].Id, Is.EqualTo(5));
				Assert.That(cubeConundrum.CubeGames[0].CubeSets, Has.Count.EqualTo(3));
				
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[0].RedCubesNumber, Is.EqualTo(4));
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[0].GreenCubesNumber, Is.EqualTo(0));
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[0].BlueCubesNumber, Is.EqualTo(3));
			
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[1].RedCubesNumber, Is.EqualTo(1));
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[1].GreenCubesNumber, Is.EqualTo(2));
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[1].BlueCubesNumber, Is.EqualTo(6));

				Assert.That(cubeConundrum.CubeGames[0].CubeSets[2].RedCubesNumber, Is.EqualTo(0));
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[2].GreenCubesNumber, Is.EqualTo(2));
				Assert.That(cubeConundrum.CubeGames[0].CubeSets[2].BlueCubesNumber, Is.EqualTo(0));
			});
		}

		[Test]
		public void GetValidGamesNumber_WithValidGameConfiguration_ShouldReturnValidGameIdsSum()
		{
			string validConfiguration = "12 red, 13 green, 14 blue";

			var cubeConundrum = new CubeConundrum(validConfiguration);
			cubeConundrum.AddCubeGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
			cubeConundrum.AddCubeGame("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");
			cubeConundrum.AddCubeGame("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");
			cubeConundrum.AddCubeGame("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");
			cubeConundrum.AddCubeGame("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

			int gameIdsSum = cubeConundrum.GetValidGameIds().Sum();

			Assert.That(gameIdsSum, Is.EqualTo(8));
		}
	}
}
