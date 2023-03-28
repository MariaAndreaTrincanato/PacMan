using PacMan.Services;

namespace PacManTests
{
	public class GameServiceTests
	{
		[Theory]
		[InlineData("Cherry", 100)]
		[InlineData("Strawberry", 300)]
		[InlineData("Orange", 500)]
		[InlineData("Apple", 700)]
		[InlineData("Melon", 1000)]
		[InlineData("Galaxian", 2000)]
		[InlineData("Bell", 3000)]
		[InlineData("Key", 5000)]
		public void Scores_fruit_points_correctly(string step, int expectedPoints)
		{
			// Arrange

			// Act
			var ret = GameService.HandleStep(step);

			// Assert
			Assert.Equal(expectedPoints, ret.scoredPoints);
			Assert.False(ret.isLifeLost);
		}

		[Fact]
		public void Scores_invincible_ghost_points_correctly()
		{
			// Arrange
			var step = "InvincibleGhost";

			// Act
			var ret = GameService.HandleStep(step);

			// Assert
			Assert.Equal(0, ret.scoredPoints);
			Assert.True(ret.isLifeLost);
		}

		[Theory]
		[InlineData(false, 0, 200)]
		[InlineData(false, 2, 200)]
		[InlineData(true, 1, 200)]
		[InlineData(true, 2, 400)]
		[InlineData(true, 3, 800)]
		[InlineData(true, 4, 1600)]
		public void Computes_vulnerable_ghost_multiplier_correctly(bool isVulnerableSequence, int eatenGhosts, int expectedTotalPoints)
		{
			// Arrange

			// Act
			var scoredPoints = GameService.EvaluateVulnerableGhostScore(isVulnerableSequence, eatenGhosts);

			// Assert
			Assert.Equal(expectedTotalPoints, scoredPoints);
		}

		[Theory]
		[InlineData("VulnerableGhost,VulnerableGhost,Dot,Dot,Dot,Dot,Dot,VulnerableGhost", 1450)]
		[InlineData("VulnerableGhost,InvincibleGhost,Dot,Dot,Dot,Dot,Dot,VulnerableGhost", 450)]
		public void Scores_vulnerable_ghost_points_correctly(string steps, int expectedTotalPoints)
		{
			// Arrange
			var totalPoints = 0;
			GameService.InitializeGameStatus();

			// Act
			var stepsList = steps.Split(',');
			foreach(var step in stepsList)
			{
				var (scoredPoints, isLifeLost) = GameService.HandleStep(step);
				totalPoints += scoredPoints;
			}

			// Assert
			Assert.Equal(expectedTotalPoints, totalPoints);
		}
	}
}