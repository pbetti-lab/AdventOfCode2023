namespace AdventOfCode.Logic.Day02
{
	public class CubeGame
	{
		public CubeGame(int id)
		{ 
			Id = id;
			CubeSets = new List<CubeSet>();
		}

		public int Id { get; private set; }
		
		public List<CubeSet> CubeSets { get; set; }
    }

}
