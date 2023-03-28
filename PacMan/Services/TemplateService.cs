namespace PacMan.Services
{
	public static class TemplateService
	{
		public static (string? content, string? errorMessage) LoadTemplateContent(string path) 
		{
			string ret;
			try
			{
				ret = File.ReadAllText(path);
			}
			catch(Exception ex) 
			{
				return ex switch
				{
					FileNotFoundException => (null, "Could not find the file"),
					ArgumentException => (null, "The specified path is not valid"),
					_ => (null, "An error occurred while reading the file"),
				};
			}

			return (ret, null);
		}
	}
}
