using System;
using System.Collections.Generic;
using System.Linq;

namespace SkeletonCode.CurrencyConverter
{
    public class ConversionRate
    {
        public string TargetCurrency { get; set; }
        public double CurrentConversionRate { get; set; }
    }
    public class CurrencyConversion
    {
        public string BaseCurrency { get; set; }
        public List<ConversionRate> ConversionRates { get; set; }
    }

    public class Converter
    {
        // Currency conversion rates are likely to be changable so this would need to be refactored to 
        // obtain the rate from a feed of data storage. Note: the unit tests would also need updating.
        // I have kept the class definitions and data declaration inside this cs file to make it easier 
        // to review. I would not do this for production code.
        public static readonly List<CurrencyConversion>
            SupportedConversions = new List<CurrencyConversion>
	                                    {
	                                        new CurrencyConversion
	                                            {
	                                                BaseCurrency = "USD",
                                                    ConversionRates = new List<ConversionRate>
                                                                            {
                                                                                new ConversionRate
                                                                                    {
                                                                                        CurrentConversionRate = 0.8,
                                                                                        TargetCurrency = "GBP"
                                                                                    }
                                                                            }
	                                            },
                                            new CurrencyConversion
	                                            {
	                                                BaseCurrency = "GBP",
                                                    ConversionRates = new List<ConversionRate>
                                                                            {
                                                                                new ConversionRate
                                                                                    {
                                                                                        CurrentConversionRate = 1.25,
                                                                                        TargetCurrency = "USD"
                                                                                    }
                                                                            }	                                                                                       
                                                }
	                                    };


        public decimal Convert(string inputCurrency, string outputCurrency, decimal amount)
        {
            var currencyConversions = LookupConversionsForBaseCurrency(inputCurrency);
            var conversionRate = LookupConversionConversionRate(currencyConversions, outputCurrency);
                
            amount = amount * (decimal)conversionRate;
               
            return amount;
        }

        private List<ConversionRate> LookupConversionsForBaseCurrency(string code)
        {
            var conversions = SupportedConversions.Where(x => x.BaseCurrency == code).Select(x => x.ConversionRates).FirstOrDefault();
            
            if (conversions == null || !conversions.Any())
            {
                throw new Exception(string.Format("No conversions exist for base currency {0}", code));
            }

            return conversions.ToList();
        }

        private double LookupConversionConversionRate(List<ConversionRate> conversions, string conversionCode)
        {
            if (conversions.All(x => x.TargetCurrency != conversionCode))
            {
                throw new Exception(string.Format("Conversion rate does not exist for target currency {0}", conversionCode));
            }

            var conversionRate =
                conversions.Where(x => x.TargetCurrency == conversionCode)
                    .Select(x => x.CurrentConversionRate)
                    .FirstOrDefault();

            return conversionRate;
        }
    }
}
