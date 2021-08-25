using OpenProject.infra;
using OpenProject.infra.webRelated;
using OpenQA.Selenium;

namespace OpenProject.PageObjects
{
	public abstract class BasePage
	{
		protected ActionBot bot;
		protected PageFactory pageFactory;
		protected readonly Locator locator;
		protected string pageName;
		protected IWebElement containingElement => bot.FindElement(locator);

		protected BasePage(Locator locator)
		{
			bot = new ActionBot();
			pageFactory = new PageFactory();
			pageName = GetType().Name;
			this.locator = locator;
		}
	}
}