using AdventOfCode.Logic.Day03;

namespace AdventOfCode.Logic.Tests.Day03
{
	internal class GearRatiosTests
	{
		[Test]
		public void GetGearPartNumbers_WithValidSchematic_ReturnValidPartNumbers()
		{
			string gearRatiosSchematic = "467..114.."
				+ Environment.NewLine + "...*......"
				+ Environment.NewLine + "..35..633."
				+ Environment.NewLine + "......#..."
				+ Environment.NewLine + "617*......"
				+ Environment.NewLine + ".....+.58."
				+ Environment.NewLine + "..592....."
				+ Environment.NewLine + "......755."
				+ Environment.NewLine + "...$.*...."
				+ Environment.NewLine + ".664.598..";

			var gearRatios = new GearRatios();
			var result = GearRatios.GetGearPartNumbers(gearRatiosSchematic);

			var expectedResult = new[] { 467, 35, 633, 617, 592, 755, 664, 598 };

			Assert.That(result, Is.EquivalentTo(expectedResult));
		}
	}
}
