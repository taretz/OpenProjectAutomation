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
	public class CreateWorkPackage : BaseTestApi
	{
		[Test, TestType(TestTypeName.Api)]
		public void CreateWorkPackageTest()
		{
			string workPackageSubject = "MyTask1";
			TestRunner(() =>
			{
				var newProject = apiHandler.CreateNewProject(new { name = "TestProject1" });
				var workPackage = apiHandler.CreateWorkPackageInProject(newProject.id,
					new { subject = workPackageSubject });
				Assert.AreEqual(workPackageSubject, workPackage.subject);
			});
		}
	}
}
