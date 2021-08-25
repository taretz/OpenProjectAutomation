using System;
using NUnit.Framework;

namespace OpenProject.infra.testAttributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class TestTypeAttribute : PropertyAttribute
	{
		public TestTypeAttribute(TestTypeName type)
			: base(type)
		{
		}
	}
}
