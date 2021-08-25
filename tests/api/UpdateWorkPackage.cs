using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenProject.infra.baseTest;
using OpenProject.infra.testAttributes;

namespace OpenProject.tests.api
{
	public class UpdateWorkPackage : BaseTestApi
	{
		[Test, TestType(TestTypeName.Api)]
		public void UpdateWorkPackageTest()
		{
			string workPackageSubject = "MyTask1";
			string newWorkPackageSubject = "CHANGED FROM API TEST";
			TestRunner(() =>
			{
				var newProject = apiHandler.CreateNewProject(new { name = "TestProject1" });
				var newWorkPackage = apiHandler.CreateWorkPackageInProject(newProject.id,
					new { subject = workPackageSubject });
				Assert.AreEqual(workPackageSubject, newWorkPackage.subject);

				newWorkPackage.subject = newWorkPackageSubject;
				newWorkPackage = apiHandler.UpdateWorkPackageById(
					newWorkPackage.id, 
					new
					{
						subject = newWorkPackageSubject,
						lockVersion = newWorkPackage.lockVersion
					});
				Assert.AreEqual(newWorkPackageSubject, newWorkPackage.subject);
			});
		}
	}
}
