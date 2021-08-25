using NUnit.Framework;
using OpenProject.infra.testAttributes;
using OpenQA.Selenium.Chrome;

namespace OpenProject.configurations
{
	public class Config
	{
		public readonly string startPage = @"http://localhost:8080/";
		public ChromeOptions chromeOptions;
		public TestTypeName testType;
		internal readonly string apiKey = "";
		internal readonly string apiUrl;

		public Config()
		{
			apiUrl = $"{startPage}api/v3";
			InitTestType();
			GenerateChromeOptions();
		}

		private void InitTestType()
		{
			testType = TestContext.CurrentContext.Test.Properties.Get("TestType").ToString() ==
			           TestTypeName.Web.ToString()
				? TestTypeName.Web
				: TestTypeName.Api;
		}

		private void GenerateChromeOptions()
		{
			chromeOptions = new ChromeOptions();
			if (testType == TestTypeName.Web)
			{
				chromeOptions.AddArguments("start-maximized", "disable-popup-blocking");
			}
			else
			{
				chromeOptions.AddArgument("headless");
			}
		}
	}
}