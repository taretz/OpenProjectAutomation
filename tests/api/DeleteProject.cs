using System;
using System.Threading;
using NUnit.Framework;
using OpenProject.infra.baseTest;
using OpenProject.infra.testAttributes;

namespace OpenProject.tests.api
{
	public class DeleteProject : BaseTestApi
	{
		[Test, TestType(TestTypeName.Api)]
		public void DeleteProjectTest()
		{
			TestRunner(() =>
			{
				string uniqueName = Guid.NewGuid().ToString();
				var param = new
				{
					name = uniqueName
				};
				var newProject = apiHandler.CreateNewProject(param);
				var projectId = newProject.id;
				Assert.AreEqual(param.name, newProject.name);

				Thread.Sleep(2000);
				var response = apiHandler.DeleteProjectById(projectId);
				Assert.AreEqual(204, (int) response.StatusCode);

				Thread.Sleep(2000);
				response = apiHandler.GetProjectById(projectId);
				Assert.AreEqual(404, (int) response.StatusCode);
			});
		}
	}
}