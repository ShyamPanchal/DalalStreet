using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalalStreetClient.Core.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int OnCompanyId { get; set; }

        public int EventTypeId { get; set; }

        public string toJson()
        {
            return "{" + OnCompanyId + " " + EventTypeId + "}";
        }

    }
}