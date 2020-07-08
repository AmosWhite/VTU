using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountCharged { get; set; }
        public decimal initialBalance { get; set; }
        public decimal FinalBalance { get; set; }
        public decimal Receiver { get; set; }
        [Required]
        public string Status { get; set; }

        public User User { get; set; }
    }
}
