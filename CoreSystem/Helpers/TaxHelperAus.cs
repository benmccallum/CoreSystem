using System;

namespace CoreSystem.Helpers
{
    public class TaxHelperAus
    {
        private const decimal GST_TAX_PERCENT = (decimal)1 / (decimal)11;

        public static decimal GetPriceWithoutGST(decimal taxInclusivePrice)
        {
            return Math.Round(taxInclusivePrice / (1 + GST_TAX_PERCENT), 2, MidpointRounding.AwayFromZero);
        }

        public static decimal GetGSTAmountByPrice(decimal taxInclusivePrice)
        {
            return Math.Round(taxInclusivePrice * GST_TAX_PERCENT, 2, MidpointRounding.AwayFromZero);
        }
    }
}
