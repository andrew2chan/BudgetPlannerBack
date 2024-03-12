using BudgetPlanner.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BudgetPlanner.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.BudgetItems)
                .WithOne(bi => bi.User)
                .HasForeignKey(bi => bi.UserId)
                .IsRequired(false); //setting this relationship as false so that modelstate won't complain
        }
    }
}