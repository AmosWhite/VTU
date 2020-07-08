using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string RollName { get; set; }

    }
}
