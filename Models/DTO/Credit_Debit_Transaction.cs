using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Credit_Debit_Transaction
    {
        public int Id { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }
        [Required]
        public string StaffUserId { get; set; }

        [ForeignKey("userProfile")]
        public string CurstomerUserId { get; set; }

        public decimal Amount { get; set; }

        /// <summary>
        /// Should be Unique
        /// </summary>
        public string Narration { get; set; }
        public DateTime TransactionDate { get; set; }

        [ForeignKey("TransactionStatus")]
        public int TransactionStatusId { get; set; }

        public TransactionType TransactionType { get; set; }
        public UserProfile userProfile { get; set; }
        public TransactionStatus TransactionStatus { get; set; }

    }
}
