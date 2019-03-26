using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class DS_PlayerInventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OwnedStocks { get; set; }

        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public DS_Player DS_Player { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public DS_Company DS_Company { get; set; }
    }
}
