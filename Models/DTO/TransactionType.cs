using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class TransactionType
    {
        public TransactionType()
        {
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}
