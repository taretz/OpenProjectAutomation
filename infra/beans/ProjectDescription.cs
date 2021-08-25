namespace OpenProject.infra.beans
{
	public class ProjectDescription
	{
		public string Format { get; set; }
		public string Raw { get; set; }
		public string Html { get; set; }
		public ProjectDescription()
		{
		}

		public override string ToString()
		{
			return $"format={Format??""}, raw={Raw??""}, html={Html??""}";
		}
	}
}
