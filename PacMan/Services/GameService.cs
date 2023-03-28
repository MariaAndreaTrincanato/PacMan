using PacMan.Helpers;

namespace PacMan.Services
{
	public static class GameService
	{
		private static bool _isVulnerableGhostsSequence = false;
		private static int _eatenVulnerableGhosts = 0;

		public static void InitializeGameStatus()
		{
			_isVulnerableGhostsSequence = false;
			_eatenVulnerableGhosts = 0;
		}

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
					_eatenVulnerableGhosts++;
					var points = EvaluateVulnerableGhostScore(_isVulnerableGhostsSequence, _eatenVulnerableGhosts);
					_isVulnerableGhostsSequence = true;
					return (points, false);
				default:
					return (0, false);
			}
		}

		public static int EvaluateVulnerableGhostScore(bool isVulnerableGhostsSequence, int eatenVulnerableGhosts)
		{
			if (!isVulnerableGhostsSequence)
			{
				return (int)EntityPointsEnum.VulnerableGhost;
			}

			var ret = 0;
			for (int i = 0; i < eatenVulnerableGhosts; i++)
			{
				if (i == 0)
				{
					ret = (int)EntityPointsEnum.VulnerableGhost;
					continue;
				}

				ret *= 2;
			}
			return ret;
		}
	}
}
