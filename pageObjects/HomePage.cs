using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenProject.infra;
using OpenProject.infra.webRelated;
using OpenQA.Selenium;

namespace OpenProject.PageObjects
{
	public class HomePage : BasePage
	{
		private UpperNavigationPage _upperNavigationPage;
		
		public HomePage() 
			: base(Locator.Get(By.Id("main"), "home page"))
		{
			_upperNavigationPage = pageFactory.UpperNavigationPage();
		}

		public void Login(string username, string password)
		{
			LoginDialog loginDialog = _upperNavigationPage.ClickSignInArrow();
			loginDialog.Login(username, password);
		}

		public NewProjectDialog GetNewProjectDialog()
		{
			QuickAddMenuPage quickAddMenuDialog = _upperNavigationPage.ClickQuickAddMenu();
			return quickAddMenuDialog.ClickNewProject();
		}
	}
}
