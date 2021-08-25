using OpenProject.configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenProject.infra.webRelated
{
	public class WebDriverProvider
	{
		public static IWebDriver webDriver;

		public static IWebDriver GetInstance()
		{
			if (webDriver == null)
			{
				Config config = new Config();
				webDriver = new ChromeDriver(config.chromeOptions);
			}
			return webDriver;
		}
	}
}
