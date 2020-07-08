using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
