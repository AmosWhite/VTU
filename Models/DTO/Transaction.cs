using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string TransactionDate { get; set; }
        public double Amount { get; set; }
        public double AmountCharged { get; set; }
        public double initialBalance { get; set; }
        public double FinalBalance { get; set; }
        public string Receiver { get; set; }
        public string Status { get; set; }

        public User User { get; set; }
    }
}
