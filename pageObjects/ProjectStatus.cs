using OpenProject.infra.webRelated;
using OpenQA.Selenium;

namespace OpenProject.pageObjects
{
	public class ProjectStatus
	{
		private ProjectStatus(string value)
		{
			Value = value;
			locator = Locator.Get(By.XPath($"//span[text()='{value}']/.."), $"Project status - {value}");
		}

		public string Value { get; private set; }
		public Locator locator { get; private set; }

		public static ProjectStatus OnTrack { get { return new ProjectStatus("On track"); } }
		public static ProjectStatus atRisk { get { return new ProjectStatus("At risk"); } }
		public static ProjectStatus offTrack { get { return new ProjectStatus("Off track"); } }
	}
}
