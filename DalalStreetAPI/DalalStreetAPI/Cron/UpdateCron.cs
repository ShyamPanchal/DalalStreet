using DalalStreetAPI.Models;
using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Cron
{
    public class UpdateCron : IJob
    {
        private readonly IServiceProvider _serviceProvider;        
        Random random;

        public UpdateCron(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            random = new Random();
        }

        public void Execute()
        {
            Console.WriteLine("Update function called!");

            if (AppData.isGameStart)
            {

                var scopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();
                var scope = scopeFactory.CreateScope();
                DS_Context _context = scope.ServiceProvider.GetRequiredService<DS_Context>();

                // Create normalized likelihood of each event
                var events = _context.DS_EventTypes.AsEnumerable();

                if (events.Count() == 0)
                {
                    Console.WriteLine("No Events available");
                    return;
                }

                double totalLikelihood = 0;

                foreach (var e in events)
                {
                    if (e.Likelihood > 0)
                        totalLikelihood += e.Likelihood;
                }

                // Create a random number
                double rng = random.NextDouble() * (totalLikelihood);

                // Select an event
                double cumulative = 0;

                var selectedEvent = new DS_EventTypes();

                foreach (var e in events)
                {
                    if (e.Likelihood < 0)
                    {
                        continue;
                    }
                    else
                    {
                        var prob = e.Likelihood + cumulative;
                        if (rng <= prob && rng > cumulative)
                        {
                            selectedEvent = e;
                            break;
                        }
                        else
                        {
                            cumulative += e.Likelihood;
                        }
                    }
                }

                // Select a company
                var companies = _context.DS_Company.AsEnumerable();

                if (companies.Count() == 0)
                {
                    Console.WriteLine("No Companies available");
                    return;
                }

                int totalCompanies = companies.Count();

                var companyRNG = random.Next(0, totalCompanies);

                var selectedCompany = companies.ToList()[companyRNG];

                // Create a news Event around it

                DS_NewsEvent newsEvent = new DS_NewsEvent();
                newsEvent.OnCompanyId = selectedCompany.Id;
                newsEvent.EventTypeId = selectedEvent.Id;

                // Make changes to companies
                var companiesInSameCategory = _context.DS_Company.Where(x => x.CategoryId == selectedCompany.CategoryId).AsEnumerable();

                selectedCompany.stockValues = (int)((selectedEvent.EffectOnSelf * selectedCompany.stockValues) + selectedCompany.stockValues);

                if(selectedCompany.stockValues < 1)
                {
                    selectedCompany.stockValues = 1;
                }

                foreach (var c in companiesInSameCategory)
                {
                    int temp = c.stockValues;
                    c.stockValues = (int)((selectedEvent.EffectOnOthers * c.stockValues) + c.stockValues);
                    if(c.stockValues < 1)
                    {
                        c.stockValues = 1;
                    }
                }

                // Commit
                try
                {
                    foreach (var c in companies)
                    {
                        _context.DS_Company.Update(c);
                    }

                    _context.DS_NewsEvent.Add(newsEvent);

                    TransactionLogs log = new TransactionLogs();
                    log.Transaction = "[Event] " + selectedEvent.TypeString + " : on : " + selectedCompany.Id;

                    _context.TransactionLogs.Add(log);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return;
                }
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Game Not Started !");
            }
        }
    }
}
