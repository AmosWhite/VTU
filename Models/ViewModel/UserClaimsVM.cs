using Amos.VTUCORE3._1.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.ViewModel
{
    public class UserClaimsVM
    {
        //ctor is used to initialized claims prop with a new list to avoid null-refference exception
        public UserClaimsVM()
        {
            Cliams = new List<UserClaim>();
        }

        public string UserId { get; set; }
        public List<UserClaim> Cliams { get; set; }
    }
}
