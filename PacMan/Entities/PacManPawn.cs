namespace PacMan.Entities
{
	public class PacManPawn
	{
		public PacManPawn(int lives, int points)
		{
			Lives = lives;
			Points = points;
		}

		public int Lives { get; set; }
		public int Points { get; set; }

		public void RemoveLife()
		{
			Lives--;
		}

		public void AddPoints(int points)
		{
			if (Points < 10000 && Points + points >= 10000)
			{
				Lives++;
			}
			Points += points;
		}
	}
}
