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

        public bool Restarted { get; set; }

        public Simulation(User Owner)
        {
            this.Owner = Owner;
            Players = new List<User>();
        }

        public bool ContainsPlayer(string playerId)
        {
            try
            {
                bool c = false;
                foreach(User player in Players)
                {
                    if (player.player.Id == Int32.Parse(playerId))
                    {
                        return true;
                    }
                }
                return c;

            } catch (Exception e)
            {
                return false;
            }

        }
    }
}