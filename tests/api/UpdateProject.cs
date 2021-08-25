using NUnit.Framework;
using OpenProject.infra.baseTest;
using OpenProject.infra.testAttributes;

namespace OpenProject.tests.api
{
	public class UpdateProject : BaseTestApi
	{
		[Test, TestType(TestTypeName.Api)]
		public void UpdateProjectByIdTest()
		{
			TestRunner(() =>
			{
				string newDescription = "chuki";
				var param = new
				{
					description = new
					{
						format = "markdown",
						raw = newDescription,
						html = ""
					}
				};

				var response = apiHandler.UpdateProjectById("3", param);
				Assert.AreEqual(newDescription, response.description.Raw);
			});
		}
	}
}