using System;
namespace Pinned
{
	public class UserAttribute
	{
		public UserAttribute(string name, string value)
		{
			Name = name;
			Value = value;
		}
		public string Name;
		public string Value;
	}
}
