using OpenQA.Selenium;

namespace OpenProject.infra.webRelated
{
	public class Locator
	{
		public string description;
		public By by;

		public static Locator Get(By by, string description)
		{
			return new Locator(by, description);
		}

		private Locator(By by, string description)
		{
			this.by = by;
			this.description = description;
		}
	}
}
