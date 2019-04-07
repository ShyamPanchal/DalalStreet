using DalalStreetAPI.Models;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Cron
{
    public class UpdateCron : IJob
    {
        private readonly IServiceProvider _serviceProvider;

        public UpdateCron(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute()
        {
            Console.WriteLine("Update function called!");

            // Create normalized likelihood of each event

            // Create a random number

            // Select an event

            // Select a company

            // Create a news Event around it

            // Make changes to companies

            // Commit
            
        }
    }
}
