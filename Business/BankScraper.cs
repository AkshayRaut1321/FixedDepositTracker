using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FixedDepositTracker.Business
{
    internal class BankScraper
    {
        internal List<string> Scrape()
        {
            string url = "https://en.wikipedia.org/wiki/List_of_banks_in_India";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            List<string> publicSectorBankNames = new List<string>();
            List<string> privateSectorBankNames = new List<string>();
            List<string> smallFinanceBankNames = new List<string>();

            // The Public Sector Banks' names are within the first table with class "wikitable"
            var publicSectorBankRows = doc.DocumentNode.SelectNodes("(//table)[1]//tr");

            for (int i = 1; i < publicSectorBankRows.Count; i++)
            {
                var publicSectorBankRow = publicSectorBankRows[i];
                var cells = publicSectorBankRow.SelectNodes("td");
                if (cells != null && cells.Count >= 2)
                {
                    var bankNameNode = cells[0].SelectSingleNode("a");
                    if (bankNameNode != null)
                    {
                        var bankName = bankNameNode.InnerText.Trim();
                        publicSectorBankNames.Add(bankName);
                    }
                    else if (!string.IsNullOrWhiteSpace(cells[0].InnerText))
                    {
                        publicSectorBankNames.Add(cells[0].InnerText);
                    }
                }
            }

            // The Public Sector Banks' names are within the first table with class "wikitable"
            var privateSectorBankRows = doc.DocumentNode.SelectNodes("(//table)[2]//tr");

            for (int i = 1; i < privateSectorBankRows.Count; i++)
            {
                var privateSectorBankRow = privateSectorBankRows[i];
                var cells = privateSectorBankRow.SelectNodes("td");
                if (cells != null && cells.Count >= 2)
                {
                    var bankNameNode = cells[0].SelectSingleNode("a");
                    if (bankNameNode != null)
                    {
                        var bankName = bankNameNode.InnerText.Trim();
                        privateSectorBankNames.Add(bankName);
                    }
                    else if (!string.IsNullOrWhiteSpace(cells[0].InnerText))
                    {
                        privateSectorBankNames.Add(cells[0].InnerText);
                    }
                }
            }

            // The Public Sector Banks' names are within the first table with class "wikitable"
            var smallFinanceBankRows = doc.DocumentNode.SelectNodes("(//table)[4]//tr");

            for (int i = 1; i < smallFinanceBankRows.Count; i++)
            {
                var smallFinanceBankRow = smallFinanceBankRows[i];
                var cells = smallFinanceBankRow.SelectNodes("td");
                if (cells != null && cells.Count >= 2)
                {
                    var bankNameNode = cells[0].SelectSingleNode("a");
                    if (bankNameNode != null)
                    {
                        var bankName = bankNameNode.InnerText.Trim();
                        smallFinanceBankNames.Add(bankName);
                    }
                    else if (!string.IsNullOrWhiteSpace(cells[0].InnerText))
                    {
                        smallFinanceBankNames.Add(cells[0].InnerText.ReplaceLineEndings(""));
                    }
                }
            }

            return publicSectorBankNames.Concat(privateSectorBankNames).Concat(smallFinanceBankNames).ToList();
        }
    }
}
