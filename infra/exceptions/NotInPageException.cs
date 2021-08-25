using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProject.exceptions
{
	public class NotInPageException : Exception
	{
		public NotInPageException(string pageName)
			: base($"Not in {pageName} page")
		{
		}
	}
}
