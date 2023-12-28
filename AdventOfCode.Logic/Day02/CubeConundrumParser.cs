namespace AdventOfCode.Logic.Day02
{
	public static class CubeConundrumParser
	{
		#region public methods

		public static CubeSet GetCubeSet(string cubeSetString)
		{
			int redCubesNumber = GetCubeColorNumber(cubeSetString, "red");
			int greenCubesNumber = GetCubeColorNumber(cubeSetString, "green");
			int blueCubesNumber = GetCubeColorNumber(cubeSetString, "blue");

			return new CubeSet(redCubesNumber, greenCubesNumber, blueCubesNumber);
		}

		public static CubeGame GetCubeGame(string cubeGameString)
		{
			int gameId = GetCubeGameId(cubeGameString);
			var cubeSets = GetCubeSets(cubeGameString);

			var cubeGame = new CubeGame(gameId);
			cubeGame.CubeSets.AddRange(cubeSets);

			return cubeGame;
		}

		#endregion

		#region private methods

		private static int GetCubeColorNumber(string cubeSet, string cubeColorToFind)
		{
			var singleCube = cubeSet.Split(',')
				.FirstOrDefault(cube => cube.Contains(cubeColorToFind));

			if (string.IsNullOrWhiteSpace(singleCube))
				return 0;

			string cubeNumberString = singleCube
				.Replace(cubeColorToFind, string.Empty)
				.Trim();

			return int.TryParse(cubeNumberString, out int cubeNumber)
				? cubeNumber
				: 0;
		}

		private static List<CubeSet> GetCubeSets(string cubeGameString)
		{
			var result = new List<CubeSet>();

			string cubeSets = cubeGameString.Split(':')[1].Trim();

			foreach (var cubeSetString in cubeSets.Split(';'))
				result.Add(GetCubeSet(cubeSetString));

			return result;
		}

		private static int GetCubeGameId(string cubeGameString)
		{
			string gameString = cubeGameString
				.Split(':')[0]
				.Trim();

			int gameId = int.Parse(gameString.Replace("Game", string.Empty));

			return gameId;
		}

		#endregion
	}
}
