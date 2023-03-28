using PacMan.Entities;
using PacMan.Services;

namespace PacMan
{
	internal class Program
	{
		private static readonly int _pacManStartPoints = 5000;
		private static readonly int _pacManStartLives = 3;

		static void Main(string[] args)
		{
			// 1. Load template content
			string templatePath = Environment.CurrentDirectory + $"\\Templates\\beanTech-seq.txt";
			var (content, errorMessage) = TemplateService.LoadTemplateContent(templatePath);

			if (errorMessage is not null)
			{
				Console.WriteLine(errorMessage);
				return;
			}

			if (string.IsNullOrEmpty(content) || string.IsNullOrWhiteSpace(content))
			{
				Console.WriteLine("There is no data in the provided template");
				return;
			}

			// 2. Init game
			var pacMan = new PacManPawn(_pacManStartLives, _pacManStartPoints);
			GameService.InitializeGameStatus();

			// 3. Handle template content
			string[] steps = content.Split(',');
			foreach(var step in steps)
			{
				var (scoredPoints, isLifeLost) = GameService.HandleStep(step);

				pacMan.AddPoints(scoredPoints);

				if (isLifeLost)
				{
					pacMan.RemoveLife();
					if (pacMan.Lives == 0)
					{
						break;
					}
				}
			}

			Console.WriteLine($"Game over! Total points {pacMan.Points}, total lives {pacMan.Lives}");
		}
	}
}