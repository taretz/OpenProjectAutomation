using OpenProject.infra.webRelated;
using OpenQA.Selenium;

namespace OpenProject.PageObjects
{
	public class LoginDialog : BasePage
	{
		private IWebElement UserNameTextBox =>
			bot.FindElement(Locator.Get(By.Id("username-pulldown"), "User name text box"));

		private IWebElement PasswordTextBox =>
			bot.FindElement(Locator.Get(By.Id("password-pulldown"), "Password text box"));

		private Locator _signInButtonLocator = Locator.Get(By.Id("login-pulldown"), "Sign in button");

		public LoginDialog()
			: base(Locator.Get(By.Id("nav-login-content"), "Login Dialog"))
		{
		}

		public void Login(string userName, string password)
		{
			TypeToTextBox(UserNameTextBox, userName);
			TypeToTextBox(PasswordTextBox, password);
			bot.Click(() => containingElement, _signInButtonLocator);
		}

		private void TypeToTextBox(IWebElement textBox, string text)
		{
			textBox.Clear();
			bot.TypeToElement(() => textBox, text);
		}
	}
}