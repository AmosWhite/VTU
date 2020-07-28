using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.ViewModel
{
    public class ManageUserWallet
    {
        public string CustomerUserName{ get; set; }
        public string  CustomerFirstname { get; set; }
        public string CustomerId { get; set; }
        public decimal WalletBalance { get; set; }
    }
}
