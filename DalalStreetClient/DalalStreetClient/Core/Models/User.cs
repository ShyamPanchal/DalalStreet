using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DalalStreetClient.Core.Models
{
    public class User
    {
        public enum Category { Admin, Player };

        public static Category ConvertCategory(string category)
        {
            switch (category.Trim())
            {
                case "Admin":
                    return Category.Admin;
                case "Player":
                    return Category.Player;
                default:
                    return Category.Player;
            }
        }

        public string Name { get; set; }
        public string IP { get; set; }
        public Category category { get; set; }

        public Player player { get; set; }

        public User(string Name, string IP, Category category)
        {
            this.Name = Name;
            this.IP = IP;
            this.category = category;
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Score { get; set; }
        public Double Balance { get; set; }
    }

    public class Inventory
    {
        public int playerId { get; set; }
        public int companyId { get; set; }
        public int ownedStocks { get; set; }
    }
}