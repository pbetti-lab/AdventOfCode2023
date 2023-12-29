namespace AdventOfCode.Logic.Day02
{
	public class CubeConundrum
	{
		#region constructors

		public CubeConundrum()
		{
			CubeGames = new List<CubeGame>();	
		}

		#endregion

		#region properties
		
		public List<CubeGame> CubeGames { get; set; }

		#endregion

		#region public methods

		public void AddCubeGame(string cubeGame) 
		{
			CubeGames.Add(CubeConundrumParser.GetCubeGame(cubeGame));
		}

		public IEnumerable<int> GetValidGameIds(string validCubeSetConfigurationText)
		{
			var validCubeSetConfiguration = CubeConundrumParser.GetCubeSet(validCubeSetConfigurationText);

			bool isValidSet(CubeSet set) =>
				   set.RedCubesNumber <= validCubeSetConfiguration.RedCubesNumber
				&& set.GreenCubesNumber <= validCubeSetConfiguration.GreenCubesNumber
				&& set.BlueCubesNumber <= validCubeSetConfiguration.BlueCubesNumber;

			return CubeGames
				.Where(game => game.CubeSets.All(isValidSet))
				.Select(game => game.Id);
		}

		public IEnumerable<CubeSet> GetValidCubeSetConfigurationPerGame()
		{
			return CubeGames
				.Select(game => 
					new CubeSet(
						redCubesNumber: game.CubeSets.Max(cube => cube.RedCubesNumber),
						greenCubesNumber: game.CubeSets.Max(cube => cube.GreenCubesNumber),
						blueCubesNumbers: game.CubeSets.Max(cube => cube.BlueCubesNumber)
					)
				);
		}

		#endregion
	}

}
