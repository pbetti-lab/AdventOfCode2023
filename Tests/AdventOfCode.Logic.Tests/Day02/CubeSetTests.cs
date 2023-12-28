using AdventOfCode.Logic.Day02;

namespace AdventOfCode.Logic.Tests.Day02
{
	internal class CubeSetTests
	{
		public void CubeSet_WhenInstantiate_ContainsTheRightValues()
		{
			int redCubesNumber = 1;
			int greenCubesNumber = 2;
			int blueCubesNumber = 3;

			var testCubeSet = new CubeSet(redCubesNumber, greenCubesNumber, blueCubesNumber);
			
			Assert.Multiple(() =>
			{
				Assert.That(testCubeSet.RedCubesNumber, Is.EqualTo(redCubesNumber));
				Assert.That(testCubeSet.GreenCubesNumber, Is.EqualTo(greenCubesNumber));
				Assert.That(testCubeSet.BlueCubesNumber, Is.EqualTo(blueCubesNumber));
			});
		}
	}
}
