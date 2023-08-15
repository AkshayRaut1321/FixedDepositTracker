using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FixedDepositTracker.Business
{
    internal class FixedDepositManager
    {
        internal Dictionary<string, string> Notify()
        {
            var bankScraper = new BankScraper();
            List<string> banks = bankScraper.Scrape();
            var bankPaisaBazaarFDRateUrl = new Dictionary<string, string>();

            foreach (var bank in banks)
            {
                var googleSearchResultScraper = new GoogleSearchResultScraper();
                bankPaisaBazaarFDRateUrl[bank] = googleSearchResultScraper.Scrape("site%3Apaisabazaar.com+" + bank.Replace(" ", "+") + "+FD+rates");

                Thread.Sleep(10000);
            }
            return bankPaisaBazaarFDRateUrl;
        }
    }
}