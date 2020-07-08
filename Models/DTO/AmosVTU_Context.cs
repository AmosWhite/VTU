using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class AmosVTU_Context : DbContext
    {
        public AmosVTU_Context(DbContextOptions<AmosVTU_Context> options)
           : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Airtime> Airtimes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
