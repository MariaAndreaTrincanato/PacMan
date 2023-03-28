using PacMan.Helpers;

namespace PacMan.Services
{
	public static class GameService
	{
		private static bool _isVulnerableGhostsSequence = false;
		private static int _eatenVulnerableGhosts = 0;
		public static (int scoredPoints, bool isLifeLost) HandleStep(string step)
		{
			switch (step)
			{
				case "Dot":
					return ((int)EntityPointsEnum.Dot, false);
				case "Cherry":
					return ((int)FruitPointsEnum.Cherry, false);
				case "Strawberry":
					return ((int)FruitPointsEnum.Strawberry, false);
				case "Orange":
					return ((int)FruitPointsEnum.Orange, false);
				case "Apple":
					return ((int)FruitPointsEnum.Apple, false);
				case "Melon":
					return ((int)FruitPointsEnum.Melon, false);
				case "Galaxian":
					return ((int)FruitPointsEnum.Galaxian, false);
				case "Bell":
					return ((int)FruitPointsEnum.Bell, false);
				case "Key":
					return ((int)FruitPointsEnum.Key, false);
				case "InvincibleGhost":
					_isVulnerableGhostsSequence = false;
					_eatenVulnerableGhosts = 0;
					return (0, true);
				case "VulnerableGhost":
					var points = EvaluateVulnerableGhostScore();
					_isVulnerableGhostsSequence = true;
					_eatenVulnerableGhosts++;
					return (points, false);
				default:
					return (0, false);
			}
		}

		public static int EvaluateVulnerableGhostScore()
		{
			if (!_isVulnerableGhostsSequence)
			{
				return (int)EntityPointsEnum.VulnerableGhost;
			}

			return (int)EntityPointsEnum.VulnerableGhost * _eatenVulnerableGhosts;
		}
	}
}
