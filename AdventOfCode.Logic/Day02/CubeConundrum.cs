using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Logic.Day02
{
	public class CubeConundrum
	{
		public CubeConundrum(string validCubeSetConfiguration)
		{
			ValidCubeSetConfiguration = CubeConundrumParser.GetCubeSet(validCubeSetConfiguration);

			CubeGames = new List<CubeGame>();	
		}

		public CubeSet ValidCubeSetConfiguration { get; private set; }
        
		public List<CubeGame> CubeGames { get; set; }
		
		public void AddCubeGame(string cubeGame) 
		{
			CubeGames.Add(CubeConundrumParser.GetCubeGame(cubeGame));
		}

		public IEnumerable<int> GetValidGameIds()
		{
			Func<CubeSet, bool> isValidSet = set => 
				   set.RedCubesNumber <= ValidCubeSetConfiguration.RedCubesNumber
				&& set.GreenCubesNumber <= ValidCubeSetConfiguration.GreenCubesNumber
				&& set.BlueCubesNumber <= ValidCubeSetConfiguration.BlueCubesNumber;

			return CubeGames
				.Where(game => game.CubeSets.All(isValidSet))
				.Select(game => game.Id);
		}
	}

}
