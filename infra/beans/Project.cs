using System;
using System.Collections.Generic;

namespace OpenProject.infra.beans
{
	public class Project
	{
		public string id;
		public string identifier;
		public string name;
		public ProjectDescription description;
		public List<WorkPackage> workPackages;

		public Project()
		{
		}

		public override string ToString()
		{
			return $"Project [Identifier={identifier ?? ""}, Name={name ?? ""}, [{description}]]";
		}
	}
}