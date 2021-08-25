using System;
using OpenProject.PageObjects;

namespace OpenProject
{
	public class PageFactory
	{
		public PageFactory()
		{
		}

		internal UpperNavigationPage UpperNavigationPage()
		{
			return new UpperNavigationPage();
		}

		internal LoginDialog LoginDialog()
		{
			return new LoginDialog();
		}

		internal HomePage HomePage()
		{
			return new HomePage();
		}

		internal QuickAddMenuPage QuickAddMenuDialog()
		{
			return new QuickAddMenuPage();
		}

		public NewProjectDialog NewProjectDialog()
		{
			return new NewProjectDialog();
		}

		public ProjectPage ProjectPage()
		{
			return new ProjectPage();
		}
	}
}