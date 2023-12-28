namespace AdventOfCode.Logic.Day02
{
	public class CubeSet
	{
		public CubeSet(int redCubesNumber, int greenCubesNumber, int blueCubesNumbers)
		{ 
			RedCubesNumber = redCubesNumber;
			GreenCubesNumber = greenCubesNumber;
			BlueCubesNumber = blueCubesNumbers;
		}

        public int RedCubesNumber { get; private set; }
		
		public int GreenCubesNumber { get; private set; }

		public int BlueCubesNumber { get; private set; }
	}

}
