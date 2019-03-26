using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class DS_EventTypes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TypeString { get; set; }

        public double Likelihood { get; set; }

        public double EffectOnSelf { get; set; }

        public double EffectOnOthers { get; set; }

        public List<DS_NewsEvent> DS_Companies { get; set; }
    }
}
