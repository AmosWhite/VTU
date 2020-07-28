using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Purchase_Transaction
    {
        public int id { get; set; }

        public int ProductTypeId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Reciever { get; set; }

        [ForeignKey("UserProfile")]
        public string SenderUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        [ForeignKey("TransactionStatus")]
        public int TransactionStatusId { get; set; }

        public TransactionStatus TransactionStatus { get; set; }
        public Product Product { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}
