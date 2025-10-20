using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Digital_Domain_Layer.Extensions
{
	public static class DescriptionHelper
	{
		public static string GetDescription(this Enum e)
		{
			var attribute =
							e.GetType()
							.GetTypeInfo().GetMember(e.ToString())
							.FirstOrDefault(member => member.MemberType == MemberTypes.Field)
							.GetCustomAttributes(typeof(DescriptionAttribute), false)
							.SingleOrDefault() as DescriptionAttribute;
			return attribute?.Description ?? e.ToString();
		}
	}
}
