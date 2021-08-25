using OpenProject.configurations;
using OpenProject.infra.webRelated;
using OpenProject.PageObjects;
using OpenQA.Selenium;

namespace OpenProject.infra.baseTest
{
	public class BaseTestUi : BaseTest
	{
		private ActionBot _bot;
		private PageFactory _pageFactory;
		private IWebDriver _webDriver;
		protected HomePage homePage;

		protected override void Setup()
		{
			base.Setup();
			OpenBrowser();
		}

		protected override void Init()
		{
			_bot = new ActionBot();
			_pageFactory = new PageFactory();
			_webDriver = WebDriverProvider.GetInstance();
		}

		private void OpenBrowser()
		{
			Config config = new Config();
			_webDriver.Navigate().GoToUrl(config.startPage);
			homePage = _pageFactory.HomePage();
		}

		protected override void TearDown()
		{
			base.TearDown();
			_webDriver.Quit();
		}
	}
}