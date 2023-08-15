using HtmlAgilityPack;

namespace FixedDepositTracker.Business
{
    internal class GoogleSearchResultScraper
    {
        internal string Scrape(string keyword)
        {
            string googleUrl = "https://www.google.com/search?q=" + keyword;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(googleUrl);

            // The Public Sector Banks' names are within the first table with class "wikitable"
            var publicSectorBankRows = doc.DocumentNode.SelectNodes("(//div[@lang='en'])//div//div//div//div//div//a");

            if (publicSectorBankRows.Count > 0)
            {
                var publicSectorBankRow = publicSectorBankRows[0];
                if (publicSectorBankRow != null)
                {
                    var paisaBazaarBankFDRateUrl = publicSectorBankRow.GetAttributeValue("href", string.Empty).Trim();
                    return paisaBazaarBankFDRateUrl;
                }
            }
            return null;
        }
    }
}
