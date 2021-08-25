using NUnit.Framework;
using OpenProject.infra.baseTest;
using OpenProject.infra.testAttributes;

namespace OpenProject.tests.api
{
	public class CreateProject : BaseTestApi
	{
		[Test, TestType(TestTypeName.Api)]
		public void CreateProjectTest()
		{
			TestRunner(() =>
			{
				var param = new
				{
					name = "aretz"
				};
				var response = apiHandler.CreateNewProject(param);

				Assert.AreEqual(param.name, response.name);
				Assert.AreEqual(param.name, response.identifier);
			});
		}
	}
}