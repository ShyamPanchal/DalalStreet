using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DalalStreetAPI.Models
{
    public class Transaction
    {
    }

    public static class AppData
    {
        public static Queue<Transaction> Transactions = new Queue<Transaction>();

        public static bool isGameStart = false;

        public static void AddTransaction(Transaction transaction)
        {
            Transactions.Enqueue(transaction);
        }

        public static void ProcessTransaction()
        {
            
        }
    }
}
