using FixedDepositTracker.Business;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace FixedDepositTracker
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([TimerTrigger("0 0 9 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var fixedDepositManager = new FixedDepositManager();
            var bankFDRateUrls = fixedDepositManager.Notify();
        }
    }
}