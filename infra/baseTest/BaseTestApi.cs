namespace OpenProject.infra.baseTest
{
	public class BaseTestApi : BaseTest
	{
		protected ApiHandler apiHandler;

		protected override void Init()
		{
			apiHandler = new ApiHandler();
		}
	}
}