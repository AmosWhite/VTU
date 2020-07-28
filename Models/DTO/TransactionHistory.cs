using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class TransactionHistory
    {
        public int Id { get; set; }
        public int TransactinId { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; }

        [ForeignKey("UserProfile")]
        public string UserId { get; set; }

        public DateTime TransactionDate { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
