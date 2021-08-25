using OpenProject.infra.webRelated;
using OpenQA.Selenium;

namespace OpenProject.PageObjects
{
	public class UpperNavigationPage : BasePage
	{
		private readonly Locator _signInArrowLocator = Locator.Get(By.CssSelector("a[title='Sign in']"), "Sign in arrow");
		private readonly Locator _quickAddMenuLocator = Locator.Get(By.CssSelector("a[title='Open quick add menu']"), "Quick add menu button");

		public UpperNavigationPage()
			: base(Locator.Get(By.CssSelector("[class='op-app-header']"), "Upper navigation pane"))
		{
		}

		public LoginDialog ClickSignInArrow()
		{
			bot.Click(() => containingElement, _signInArrowLocator);
			return pageFactory.LoginDialog();
		}

		public QuickAddMenuPage ClickQuickAddMenu()
		{
			bot.Click(() => containingElement, _quickAddMenuLocator);
			return pageFactory.QuickAddMenuDialog();
		}
	}
}