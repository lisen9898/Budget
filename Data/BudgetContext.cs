using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Budget.Models;

namespace Budget.Data;

public class BudgetContext(DbContextOptions<BudgetContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();
    }
}