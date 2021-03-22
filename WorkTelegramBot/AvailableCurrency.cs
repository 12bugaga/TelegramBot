using System;

namespace WorkTelegramBot
{
    class AvailableCurrency
    {
        string[] Currency =
        {
            "USD",
            "EUR",
            "RUB",
            "CHF",
            "GBP",
            "PLZ",
            "SEK",
            "XAU",
            "CAD"
        };

        public bool CompareCurrency(string inputText)
        {
            bool result = false;
            foreach (string localCurrency in Currency)
                if (localCurrency == inputText)
                    result = true;
            return result;
        }
    }
}
