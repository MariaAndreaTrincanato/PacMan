using PacMan.Services;

namespace PacManTests
{
	public class TemplateServiceTests
	{
		private static readonly string _correctTemplate = $"{Environment.CurrentDirectory}\\Templates\\beanTech-seq.txt";

		[Theory]
		[InlineData(null, "The specified path is not valid")]
		[InlineData("aaa", "Could not find the file")]
		public void Handles_template_errors(string path, string? error)
		{
			// Arrange

			// Act
			var ret = TemplateService.LoadTemplateContent(path);

			// Assert
			Assert.Equal(error, ret.errorMessage);
		}

		[Fact]
		public void Loads_template_correctly()
		{
			// Arrange

			// Act
			var ret = TemplateService.LoadTemplateContent(_correctTemplate);

			// Assert
			Assert.Null(ret.errorMessage);
			Assert.False(string.IsNullOrEmpty(ret.content));
			Assert.False(string.IsNullOrWhiteSpace(ret.content));
		}
	}
}
