using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Logic.Day02
{
	public class CubeConundrum
	{
		public CubeConundrum()
		{
			CubeGames = new List<CubeGame>();	
		}
        
		public List<CubeGame> CubeGames { get; set; }
		
		public void AddCubeGame(string cubeGame) 
		{
			CubeGames.Add(CubeConundrumParser.GetCubeGame(cubeGame));
		}

		public IEnumerable<int> GetValidGameIds(string validCubeSetConfigurationText)
		{
			var validCubeSetConfiguration = CubeConundrumParser.GetCubeSet(validCubeSetConfigurationText);

			Func<CubeSet, bool> isValidSet = set => 
				   set.RedCubesNumber <= validCubeSetConfiguration.RedCubesNumber
				&& set.GreenCubesNumber <= validCubeSetConfiguration.GreenCubesNumber
				&& set.BlueCubesNumber <= validCubeSetConfiguration.BlueCubesNumber;

			return CubeGames
				.Where(game => game.CubeSets.All(isValidSet))
				.Select(game => game.Id);
		}
	}

}
