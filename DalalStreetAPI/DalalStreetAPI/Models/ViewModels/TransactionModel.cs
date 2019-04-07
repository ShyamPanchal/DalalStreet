using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models.ViewModels
{
    public class TransactionModel
    {
        public int PlayerId { get; set; }

        public int CompanyId { get; set; }

        public int TotalStocks { get; set; }
    }
}
