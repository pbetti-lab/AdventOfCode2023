using AdventOfCode.Logic.Day02;

namespace AdventOfCode.Logic.Tests.Day02
{
	internal class CubeGameTests
	{
		[Test]
		public void CubeGame_WhenInstantiated_ContainsTheRightValues()
		{
			int cubeGameId = 5;
			var testCubeGame = new CubeGame(cubeGameId);			
			
			Assert.Multiple(() =>
			{
				Assert.That(testCubeGame.Id, Is.EqualTo(cubeGameId));
				Assert.That(testCubeGame.CubeSets, Is.Empty);
			});
		}
	}
}
