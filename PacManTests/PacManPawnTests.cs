using PacMan.Entities;

namespace PacManTests
{
	public class PacManPawnTests
	{
		[Theory]
		[InlineData(3, 2)]
		[InlineData(1, 0)]
		public void Loses_life_correctly(int currentLifes, int expectedLifes)
		{
			// Arrange
			var pawn = new PacManPawn(currentLifes, 0);

			// Act
			pawn.RemoveLife();

			// Assert
			Assert.Equal(expectedLifes, pawn.Lives);
		}

		[Theory]
		[InlineData(0, 10000, 3, 4)]
		[InlineData(9700, 300, 1, 2)]
		[InlineData(12000, 300, 1, 1)]
		public void Adds_life_at_target_points_correctly(int currentPoints, int pointsToAdd, int currentLifes, int expectedLifes)
		{
			// Arrange
			var pawn = new PacManPawn(currentLifes, currentPoints);

			// Act
			pawn.AddPoints(pointsToAdd);

			// Assert
			Assert.Equal(expectedLifes, pawn.Lives);
		}
	}
}
