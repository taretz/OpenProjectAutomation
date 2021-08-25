using NUnit.Framework;
using OpenProject.infra.baseTest;
using OpenProject.infra.testAttributes;

namespace OpenProject.tests.api
{
	public class GetWorkPackage : BaseTestApi
	{
		private string workPackageSubject = "MyTask1";
		private string workPackageId;

		[Test, TestType(TestTypeName.Api)]
		public void GetWorkPackageByIdTest()
		{
			TestRunner(() =>
			{
				var workPackage = apiHandler.GetWorkPackageById(workPackageId);
				Assert.AreEqual(workPackageSubject, workPackage.subject);
			});
		}

		protected override void Setup()
		{
			var newProject = apiHandler.CreateNewProject(new {name = "TestProject1"});
			var workPackage = apiHandler.CreateWorkPackageInProject(
				newProject.id,
				new {subject = workPackageSubject});
			Assert.AreEqual(workPackageSubject, workPackage.subject);

			workPackageId = workPackage.id;
		}
	}
}