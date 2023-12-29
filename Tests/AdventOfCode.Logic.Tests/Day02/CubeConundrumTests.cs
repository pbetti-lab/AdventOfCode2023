using AdventOfCode.Logic.Day02;

namespace AdventOfCode.Logic.Tests.Day02
{
	internal class CubeConundrumTests
	{
		[Test]
		public void CubeConundrum_WhenInstantiated_ShouldContainEmptyCubeGames()
		{
			var cubeConundrum = new CubeConundrum();

			Assert.That(cubeConundrum.CubeGames, Is.Empty);
		}

		[Test]
		public void AddCubeGame_WithValidCubeGameString_ShouldReturnValidGameSets()
		{
			var cubeConundrum = new CubeConundrum();
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
			var cubeConundrum = new CubeConundrum();
			cubeConundrum.AddCubeGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
			cubeConundrum.AddCubeGame("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");
			cubeConundrum.AddCubeGame("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");
			cubeConundrum.AddCubeGame("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");
			cubeConundrum.AddCubeGame("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

			string validConfiguration = "12 red, 13 green, 14 blue";
			int gameIdsSum = cubeConundrum.GetValidGameIds(validConfiguration).Sum();

			Assert.That(gameIdsSum, Is.EqualTo(8));
		}

		[Test]
		public void GetValidCubeSetConfigurationPerGame_WithValidGames_ShouldReturnAListOfValidGameSetConfiguration()
		{
			var cubeConundrum = new CubeConundrum();
			cubeConundrum.AddCubeGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
			cubeConundrum.AddCubeGame("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");
			cubeConundrum.AddCubeGame("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red");
			cubeConundrum.AddCubeGame("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red");
			cubeConundrum.AddCubeGame("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");

			var validCubeSetConfigurationPerGame = cubeConundrum
				.GetValidCubeSetConfigurationPerGame()
				.ToList();
			
			Assert.Multiple(() =>
			{
				Assert.That(validCubeSetConfigurationPerGame[0].RedCubesNumber, Is.EqualTo(4));
				Assert.That(validCubeSetConfigurationPerGame[0].GreenCubesNumber, Is.EqualTo(2));
				Assert.That(validCubeSetConfigurationPerGame[0].BlueCubesNumber, Is.EqualTo(6));

				Assert.That(validCubeSetConfigurationPerGame[1].RedCubesNumber, Is.EqualTo(1));
				Assert.That(validCubeSetConfigurationPerGame[1].GreenCubesNumber, Is.EqualTo(3));
				Assert.That(validCubeSetConfigurationPerGame[1].BlueCubesNumber, Is.EqualTo(4));
				
				Assert.That(validCubeSetConfigurationPerGame[2].RedCubesNumber, Is.EqualTo(20));
				Assert.That(validCubeSetConfigurationPerGame[2].GreenCubesNumber, Is.EqualTo(13));
				Assert.That(validCubeSetConfigurationPerGame[2].BlueCubesNumber, Is.EqualTo(6));

				Assert.That(validCubeSetConfigurationPerGame[3].RedCubesNumber, Is.EqualTo(14));
				Assert.That(validCubeSetConfigurationPerGame[3].GreenCubesNumber, Is.EqualTo(3));
				Assert.That(validCubeSetConfigurationPerGame[3].BlueCubesNumber, Is.EqualTo(15));

				Assert.That(validCubeSetConfigurationPerGame[4].RedCubesNumber, Is.EqualTo(6));
				Assert.That(validCubeSetConfigurationPerGame[4].GreenCubesNumber, Is.EqualTo(3));
				Assert.That(validCubeSetConfigurationPerGame[4].BlueCubesNumber, Is.EqualTo(2));
			});
		}
	}
}
