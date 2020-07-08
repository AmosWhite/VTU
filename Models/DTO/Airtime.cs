using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class Airtime
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }

        public Service Service { get; set; }

    }
}
