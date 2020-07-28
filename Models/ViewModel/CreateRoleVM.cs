using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.ViewModel.AccountVM
{
    public class CreateRoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
