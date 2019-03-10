using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalalStreetClient.Core.Models
{
    public class Simulation
    {
        public User Owner { get; set; }
        public List<User> Players { get; set; }
        public Settings Setting { get; set; }

        public bool Running { get; set; }

        public Simulation(User Owner)
        {
            this.Owner = Owner;
            Players = new List<User>();
        }
    }
}