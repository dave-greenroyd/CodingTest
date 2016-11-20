using NUnit.Framework;

using SkeletonCode.ReversingString;

namespace UnitTests.ReversingString
{
	[TestFixture]
	public class StringUtiltiesTests
	{
		[TestCase("", "")]
		[TestCase("skeleton", "noteleks")]
		[TestCase(null, "")]
		public void ReverseStringShouldReturnTheStringInTheReverseOrder(string input, string expectedResult)
		{
			StringUtilities stringUtilities = new StringUtilities();
			string result = stringUtilities.Reverse(input);

			Assert.AreEqual(expectedResult, result);
		}
	}
}
