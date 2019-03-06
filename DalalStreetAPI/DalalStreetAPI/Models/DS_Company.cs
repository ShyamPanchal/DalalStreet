using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class DS_Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int stockValues { get; set; }

        public int totalStocks { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public DS_CompanyCategory DS_CompanyCategory { get; set; }
    }
}
