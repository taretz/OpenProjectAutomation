using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;

namespace OpenProject.infra.webRelated
{
	public class WebElementHelper
	{
		private IWebDriver _webDriver;
		private Logger _logger;

		public WebElementHelper()
		{
			_webDriver = WebDriverProvider.GetInstance();
			_logger = Logger.GetInstance();
		}

		public void TakeScreenshotAndLog(string imageName, IReadOnlyCollection<IWebElement> elements)
		{
			int i = 1;
			foreach (var element in elements)
			{
				TakeScreenshotAndLog($"{imageName}i", element);
			}
		}

		public void TakeScreenshotAndLog(string imageName, IWebElement element)
		{
			string originalElementBackground = GetElementBackground(element);
			ChangeElementBackground(element, "lightgreen");
			ScrollElementToView(element);
			TakeScreenshot(imageName);
			ChangeElementBackground(element, originalElementBackground);
		}

		private string GetElementBackground(IWebElement element)
		{
			IJavaScriptExecutor jse = (IJavaScriptExecutor) _webDriver;
			return jse.ExecuteScript("arguments[0].style.backgroundColor", element) as string;
		}

		private void ChangeElementBackground(IWebElement element, string backGround)
		{
			IJavaScriptExecutor jse = (IJavaScriptExecutor) _webDriver;
			jse.ExecuteScript($"arguments[0].style.backgroundColor='{backGround}'", element);
			Thread.Sleep(500);
		}

		private void ScrollElementToView(IWebElement element)
		{
			IJavaScriptExecutor jse = (IJavaScriptExecutor) _webDriver;
			jse.ExecuteScript("arguments[0].scrollIntoView()", element);
		}

		private void TakeScreenshot(string imageName)
		{
			Screenshot image = ((ITakesScreenshot) _webDriver).GetScreenshot();
			_logger.Log(image, imageName);
		}
	}
}