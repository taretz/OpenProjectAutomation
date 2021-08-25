using NUnit.Framework;
using OpenProject.infra.baseTest;
using OpenProject.infra.testAttributes;

namespace OpenProject.tests.api
{
	public class GetProject : BaseTestApi
	{
		[Test, TestType(TestTypeName.Api)]
		public void GetProjectByIdTest()
		{
			TestRunner(() =>
			{
				var response = apiHandler.GetProjectById("3");

				Assert.AreEqual(200, response.StatusCode);
			});
		}
	}
}