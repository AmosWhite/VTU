using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.ViewModel
{
    public class ProductVm
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
