using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class UserProfile : IdentityUser
    {
        public UserProfile()
        {
            this.TransactionHistories = new HashSet<TransactionHistory>();
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        public string PhotoPath { get; set; }
        public decimal Wallet { get; set; }

        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }

    }
}
