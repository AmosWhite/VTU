using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.DTO
{
    public class AmosVTU_Context : IdentityDbContext<UserProfile>
    {
        public AmosVTU_Context(DbContextOptions<AmosVTU_Context> options)
           : base(options)
        {

        }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }
        public DbSet<Airtime> Airtimes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Credit_Debit_Transaction> credit_Debit_Transactions { get; set; }
        public DbSet<Purchase_Transaction> purchase_Transactions { get; set; }
        public DbSet<Refund_Transaction> Refund_Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Adding decimal precition 
            foreach (var property in builder.Model.GetEntityTypes()
                                     .SelectMany(t => t.GetProperties())
                                     .Where(p => p.ClrType == typeof(decimal)))
            {
                // EF Core 3
                property.SetColumnType("decimal(16, 2)");

                // EF Core 1 & 2
                //property.Relational().ColumnType = "decimal(16, 2)";

                //if you have nullable types as decimal?, use:
                //Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?))
            }

            //set on delete refferencail constraint to no action
            foreach (var foreignKey in builder.Model.GetEntityTypes()
                                      .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Set Unique columns
            builder.Entity<TransactionHistory>()
                .HasIndex(p => new { p.TransactinId, p.TransactionTypeId }).IsUnique();

            builder.Entity<Refund_Transaction>()
               .HasIndex(p => p.PurchaseTransactionId).IsUnique();

        }
    }

}
