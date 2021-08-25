using OpenProject.infra.webRelated;
using OpenQA.Selenium;

namespace OpenProject.PageObjects
{
	public class ProjectPage : BasePage
	{
		public ProjectPage() : base(Locator.Get(By.CssSelector("[id='content'] openproject-base:first-child"), "Project page"))
		{
		}
	}
}
