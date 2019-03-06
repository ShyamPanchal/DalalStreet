using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class DS_CompanyCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<DS_Company> DS_Companies { get; set; }
    }
}
