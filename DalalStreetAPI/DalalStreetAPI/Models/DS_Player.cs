using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class DS_Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public long Score { get; set; }

        public double Balance { get; set; }

        public List<DS_PlayerInventory> DS_PlayerInventory { get; set; }
    }
}
