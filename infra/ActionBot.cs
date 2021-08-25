using System;
using System.Collections.Generic;
using OpenProject.infra.webRelated;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace OpenProject.infra
{
	public class ActionBot
	{
		public const int defaultTimeoutInSeconds = 30;
		private IWebDriver _webDriver;
		private Logger _logger;
		private WebElementHelper _webElementHelper;

		public ActionBot()
		{
			_webDriver = WebDriverProvider.GetInstance();
			_logger = Logger.GetInstance();
			_webElementHelper = new WebElementHelper();
		}

		public void Click(Func<IWebElement> contextElementFunc, Locator innerElementLocator,
			int timeout = defaultTimeoutInSeconds)
		{
			Click(() => FindElement(contextElementFunc, innerElementLocator),
				description: innerElementLocator.description);
			_logger.Log($"Clicked on '{innerElementLocator.description}'");
		}

		public void Click(Func<IWebElement> element, int timeout = defaultTimeoutInSeconds, string description = "")
		{
			IWebElement el = Wait.ForElementToBeClickable(element, timeout);
			_webElementHelper.TakeScreenshotAndLog(description, el);
			el.Click();
		}

		public IReadOnlyCollection<IWebElement> FindElements(Locator locator, int timeout = defaultTimeoutInSeconds)
		{
			WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));
			IReadOnlyCollection<IWebElement> elements =
				wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator.by));
			_webElementHelper.TakeScreenshotAndLog(locator.description, elements);
			_logger.Log($"Found elements '{locator.description}'");
			return elements;
		}

		public IWebElement FindElement(Locator locator, int timeout = defaultTimeoutInSeconds)
		{
			WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));
			IWebElement el = wait.Until(ExpectedConditions.ElementIsVisible(locator.by));
			_webElementHelper.TakeScreenshotAndLog(locator.description, el);
			_logger.Log($"Found element '{locator.description}'");
			return el;
		}

		public IWebElement FindElement(Func<IWebElement> contextElementFunc, Locator innerElementLocator,
			int timeout = defaultTimeoutInSeconds)
		{
			IWebElement contextElement = contextElementFunc.Invoke();
			return FindElement(contextElement, innerElementLocator, timeout);
		}

		private IWebElement FindElement(IWebElement contextElement, Locator innerElementLocator,
			int timeout = defaultTimeoutInSeconds)
		{
			IWebElement nestedElement;
			try
			{
				_webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
				nestedElement = contextElement.FindElement(innerElementLocator.by);
			}
			catch (NoSuchElementException)
			{
				_logger.Log($"Couldn't find element with locator '{innerElementLocator.by}'");
				throw;
			}
			finally
			{
				_webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
			}

			return nestedElement;
		}

		public void TypeToElement(Func<IWebElement> element, string text)
		{
			IWebElement el = element.Invoke();
			el.SendKeys(text);
			string elementName = el.GetAttribute("data-qa-field-name");
			_webElementHelper.TakeScreenshotAndLog($"{elementName} input", el);
			_logger.Log($"Typed {text} to '{elementName}' input");
		}
	}
}