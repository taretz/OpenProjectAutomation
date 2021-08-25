using System;
using NUnit.Framework;

namespace OpenProject.infra.baseTest
{
	public abstract class BaseTest
	{
		protected Logger logger = Logger.GetInstance();
		[SetUp]
		protected virtual void Setup()
		{
			logger.Log($"================ SETUP ================");
			Init();
		}

		protected abstract void Init();

		protected void TestRunner(Action test)
		{
			logger.Log($"================ TEST ================");
			try
			{
				test.Invoke();
			}
			catch (Exception e)
			{
				logger.Log($"Test threw an exception: {e.Message}");
				Assert.Fail(e.StackTrace);
			}
		}

		[TearDown]
		protected virtual void TearDown()
		{
			logger.Log($"================ TEAR DOWN ================");
		}
	}
}