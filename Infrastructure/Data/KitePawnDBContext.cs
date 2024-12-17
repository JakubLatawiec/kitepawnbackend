using Domain.Entities;
using Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class KitePawnDBContext : DbContext
    {
        //Constructor with additional options
        public KitePawnDBContext(DbContextOptions options) : base(options) { }

        //Tables
        public DbSet<Domain.Entities.Action>? Actions { get; set; }
        public DbSet<Domain.Entities.Branch>? Branches { get; set; }
        public DbSet<Domain.Entities.Category>? Categories { get; set; }
        public DbSet<Domain.Entities.Contract>? Contracts { get; set; }
        public DbSet<Domain.Entities.Customer>? Customers { get; set; }
        public DbSet<Domain.Entities.Employee>? Employees { get; set; }
        public DbSet<Domain.Entities.EmployeeInBranch>? EmployeesInBranches { get; set; }
        public DbSet<Domain.Entities.Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new KitePawnDBSeeder(modelBuilder).Seed();

            //Actions
            modelBuilder.Entity<Domain.Entities.Action>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<Domain.Entities.Action>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Actions)
                .HasForeignKey(e => e.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            //Branches
            modelBuilder.Entity<Domain.Entities.Branch>()
                .HasKey(e => e.ID);

            //Categories
            modelBuilder.Entity<Domain.Entities.Category>()
                .HasKey(e => e.ID);

            //Contracts
            modelBuilder.Entity<Domain.Entities.Contract>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<Domain.Entities.Contract>()
                .HasOne(c => c.Customer)
                .WithMany(cs => cs.Contracts)
                .HasForeignKey(cs => cs.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Domain.Entities.Contract>()
                .HasOne(c => c.Employee)
                .WithMany(e => e.Contracts)
                .HasForeignKey(e => e.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            //Customers
            modelBuilder.Entity<Domain.Entities.Customer>()
                .HasKey(e => e.ID);

            //Employees
            modelBuilder.Entity<Domain.Entities.Employee>()
                .HasKey(e => e.ID);

            //EmployeesInBranches
            modelBuilder.Entity<Domain.Entities.EmployeeInBranch>()
                .HasKey(e => new { e.BranchID, e.EmployeeID });

            modelBuilder.Entity<Domain.Entities.EmployeeInBranch>()
                .HasOne(eb => eb.Employee)
                .WithMany(e => e.EmployeesInBranches)
                .HasForeignKey(e => e.EmployeeID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Domain.Entities.EmployeeInBranch>()
                .HasOne(eb => eb.Branch)
                .WithMany(b => b.EmployeesInBranches)
                .HasForeignKey(b => b.BranchID)
                .OnDelete(DeleteBehavior.Cascade);

            //Products
            modelBuilder.Entity<Domain.Entities.Product>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<Domain.Entities.Product>()
                .HasOne(p => p.Contract)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.ContractID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Domain.Entities.Product>()
                .HasOne(p => p.Branch)
                .WithMany(b => b.Products)
                .HasForeignKey(b => b.BranchID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Domain.Entities.Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
