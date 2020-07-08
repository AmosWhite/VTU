using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string PhotoPath { get; set; }

        public Role Role { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
