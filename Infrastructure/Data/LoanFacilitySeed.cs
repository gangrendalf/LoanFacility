using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
  public class LoanFacilitySeed
  {
    public static async Task SeedAsync(LoanFacilityContext context, ILoggerFactory loggerFactory)
    {
      try
      {
        if (!context.Rates.Any())
        {
          var ratesData = File.ReadAllText("../Infrastructure/Data/SeedData/Rates.json");
          var rates = JsonSerializer.Deserialize<List<Rate>>(ratesData);

          foreach (var item in rates)
          {
            context.Rates.Add(item);
          }

          await context.SaveChangesAsync();
        }

        if (!context.Loans.Any())
        {
          var loansData = File.ReadAllText("../Infrastructure/Data/SeedData/Loans.json");
          var loans = JsonSerializer.Deserialize<List<Loan>>(loansData);

          foreach (var item in loans)
          {
            context.Loans.Add(item);
          }

          await context.SaveChangesAsync();
        }

        if (!context.LoanOffers.Any())
        {
          var loanOffersData = File.ReadAllText("../Infrastructure/Data/SeedData/LoanOffers.json");
          var offers = JsonSerializer.Deserialize<List<LoanOffer>>(loanOffersData);

          foreach (var item in offers)
          {
            context.LoanOffers.Add(item);
          }

          await context.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {
        var logger = loggerFactory.CreateLogger<LoanFacilityContext>();
        logger.LogError(ex.Message);
      }
    }
  }
}