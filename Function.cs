using FixedDepositTracker.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FixedDepositTracker
{
    public static class Function
    {
        [FunctionName("RunFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            BankScraper bankScraper = new BankScraper();
            List<string> banks = bankScraper.Scrape();

            return new OkObjectResult(banks);
        }
    }
}
