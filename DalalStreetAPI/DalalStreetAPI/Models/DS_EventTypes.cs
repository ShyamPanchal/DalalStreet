using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class DS_EventTypes
    {
        public int Id { get; set; }

        public string TypeString { get; set; }

        public double Likelihood { get; set; }

        public double EffectOnSelf { get; set; }

        public double EffectOnOthers { get; set; }

        public List<DS_NewsEvent> DS_Companies { get; set; }
    }
}
