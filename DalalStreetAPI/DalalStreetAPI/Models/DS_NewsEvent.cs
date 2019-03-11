using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class DS_NewsEvent
    {
        public int Id { get; set; }        

        public int EventTypeId { get; set; }
        [ForeignKey("EventTypeId")]
        public DS_EventTypes DS_EventType { get; set; }

        public int OnCompanyId { get; set; }
        [ForeignKey("OnCompanyId")]
        public DS_Company DS_Company { get; set; }
    }
}
