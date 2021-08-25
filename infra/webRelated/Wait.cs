using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OpenProject.infra.webRelated
{
	public class Wait
	{
		private static IWebDriver webDriver = WebDriverProvider.GetInstance();

		public static IWebElement ForElementToBeClickable(Func<IWebElement> element, int timeout)
		{
			WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
			IWebElement el = wait.Until(ExpectedConditions.ElementToBeClickable(element.Invoke()));
			return el;
		}
	}
}