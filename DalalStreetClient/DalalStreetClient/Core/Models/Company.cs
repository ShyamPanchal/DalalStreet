using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalalStreetClient.Core.Models
{
    public class Company
    {
        const string quote = "\"";

        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int TotalStocks { get; set; }

        public int StockValues { get; set; }

        public string toJson(int stockOwned)
        {
            return quote + Name + quote +" : {"  +                
                quote + "StockValue" + quote + ":" + StockValues + ", " + 
                quote + "StockOwned" + quote + ":" + stockOwned + ", " +
                quote + "Id" + quote + ":" + Id +
                "}";
        }
    }
}