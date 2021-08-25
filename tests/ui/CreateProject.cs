using System.Threading;
using NUnit.Framework;
using OpenProject.infra.baseTest;
using OpenProject.infra.testAttributes;
using OpenProject.pageObjects;
using OpenProject.PageObjects;

namespace OpenProject.tests.ui
{
	public class CreateProject : BaseTestUi
	{
		[Test, TestType(TestTypeName.Web)]
		public void CreateProjectTest()
		{
			TestRunner(() =>
			{
				string userName = "";
				string password = "";
				homePage.Login(userName, password);
				NewProjectDialog newProjectDialog = homePage.GetNewProjectDialog();
				ProjectPage projectPage = newProjectDialog.TypeProjectName("testtttttt")
					.TypeProjectDescription("open project demo")
					.SelectProjectStatus(ProjectStatus.OnTrack)
					.Create();
				
				Thread.Sleep(1000);
			});
		}
	}
}
