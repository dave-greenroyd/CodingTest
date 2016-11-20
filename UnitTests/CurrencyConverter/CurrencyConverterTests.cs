using NUnit.Framework;

using SkeletonCode.CurrencyConverter;

namespace UnitTests.CurrencyConverter
{
	[TestFixture]
	public class CurrencyConverterTests
	{
		[Test]
		public void ItShouldConvertFromPoundsToDollarsCorrectly()
		{
			decimal amountInPounds = 1m;
			decimal expectedAmountInDollars =  1.25m;

			Converter converter = new Converter();
			decimal result = converter.Convert("GBP", "USD", amountInPounds);

			Assert.AreEqual(expectedAmountInDollars, result);
		}

		[Test]
		public void ItShouldConvertFromDollarsToPoundsCorrectly()
		{
			decimal amountInDollars = 1m;
			decimal expectedAmountInPounds = 0.8m;

			Converter converter = new Converter();
			decimal result = converter.Convert("USD", "GBP", amountInDollars);

			Assert.AreEqual(expectedAmountInPounds, result);
		}
		
		[Test]
		[ExpectedException()]
		public void AnExceptionShouldBeThrownIfAnUnknownCurrencyTypeIsPassedIn()
		{
			Converter converter = new Converter();
			converter.Convert("USD", "DDD", 100);
		}
	}
}
