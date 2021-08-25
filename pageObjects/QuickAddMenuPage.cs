using OpenProject.infra.webRelated;
using OpenQA.Selenium;

namespace OpenProject.PageObjects
{
	public class QuickAddMenuPage : BasePage
	{
		private readonly Locator _newProjectButtonLocator = Locator.Get(By.CssSelector("a[title='New project']"), "New project button");

		public QuickAddMenuPage()
			: base(Locator.Get(By.Id("quick-add-menu"), "Quick add menu"))
		{
		}

		public NewProjectDialog ClickNewProject()
		{
			bot.Click(() => containingElement, _newProjectButtonLocator);
			return pageFactory.NewProjectDialog();
		}
	}
}