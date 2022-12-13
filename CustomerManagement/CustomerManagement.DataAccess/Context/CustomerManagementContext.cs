using CustomerManagement.Common.Commons;
using CustomerManagement.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DataAccess.Context
{
    public class CustomerManagementContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }

       

        public CustomerManagementContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(StringConstant.connectionString);
            }


            base.OnConfiguring(optionsBuilder);

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(x=>x.customerId);
                entity.Property(x => x.customerId).HasColumnName("CustomerId").HasColumnType("integer").UseIdentityColumn();
                entity.Property(x => x.customerCode).HasColumnName("CustomerCode").HasColumnType("character varying").HasMaxLength(10);
                entity.Property(x => x.customerTitle).HasColumnName("CustomerTitle").HasColumnType("character varying").HasMaxLength(50);
                entity.Property(x => x.city).HasColumnName("City").HasColumnType("character variyng").HasMaxLength(50);
                entity.Property(x => x.district).HasColumnName("District").HasColumnType("character varying").HasMaxLength(50);
                entity.Property(x => x.salesAmount).HasColumnName("SalesAmount").HasColumnType("integer");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(x => x.userId);   
                entity.Property(x => x.userId).HasColumnName("UserId").HasColumnType("integer").UseIdentityColumn();
                entity.Property(x => x.userName).HasColumnName("UserName").HasColumnType("character varying").HasMaxLength(50);
                entity.Property(x => x.userPassword).HasColumnName("UserPassword").HasColumnType("character varying").HasMaxLength(4);

            });



            base.OnModelCreating(modelBuilder);
        }
    }
}
