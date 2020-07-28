using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Refund_Transaction
    {
        public int Id { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }

        /// <summary>
        /// Should Be unique
        /// </summary>
        [ForeignKey("Purchase_Transaction")]
        public int PurchaseTransactionId { get; set; }
        [ForeignKey("TransactionStatus")]
        public int TransactionStatusId { get; set; }
        [ForeignKey("UserProfile")]
        public string StaffUserId { get; set; }

        public DateTime TransactionDate { get; set; }

        public TransactionType TransactionType { get; set; }
        public Purchase_Transaction Purchase_Transaction { get; set; }
        public TransactionStatus TransactionStatus { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
