using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalalStreetClient.Core.Models
{
    public class EventType
    {
        public int Id { get; set; }
        public string TypeString { get; set; }
        public Decimal Likelihood { get; set; }
        public Decimal EffectOnSelf { get; set; }
        public Decimal EffectOnOthers { get; set; }

    }
}