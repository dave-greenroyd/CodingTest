using System;

namespace SkeletonCode.ReversingString
{
	public class StringUtilities
	{
		public string Reverse(string input)
		{
		    if (string.IsNullOrEmpty(input))
		    {
		        return string.Empty;
		    }
		    var inputAsArray = input.ToCharArray();
		    Array.Reverse(inputAsArray);
		    return new string(inputAsArray);
		}
	}
}
