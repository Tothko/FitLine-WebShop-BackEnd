using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLData
{
    public class FitLineContext : DbContext
    {
        public FitLineContext(DbContextOptions<FitLineContext> opt) : base(opt)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order66> Orders { get; set; }
        public DbSet<Order66ItemStatus> Order66ItemStatuses { get; set; }
        public DbSet<Order66Product> Order66Products { get; set; }
        public DbSet<Order66Status> Order66Statuses { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentProduct> ShipmentProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressUser> AddressUsers { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
/**********************User relations ***************************/

            modelBuilder.Entity<User>()
             .HasMany(u => u.Addresses);

            modelBuilder.Entity<User>()
             .HasMany(u => u.Orders)
             .withOne(o => o.User)
             .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Order66>()
             .HasOne(o => o.User)
             .WithMany(u => u.Orders);
            .OnDelete(DeleteBehavior.SetNull);


            /*****************************************************************/



            /**********************Relation between Order and Products and adding statutes to both of them ***************************/
            modelBuilder.Entity<Order66>()
             .HasOne(o => o.User)
             .WithMany(u => u.Orders)
             .OnDelete(DeleteBehavior.SetNull);
            
             
            modelBuilder.Entity<Order66>()
                .HasMany(o => o.Statuses);

            modelBuilder.Entity<Order66Product>()
                .HasMany(op => op.Statuses);

            modelBuilder.Entity<Order66Product>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .OnDelete(DeleteBehavior.SetNull);
/***********************************************************************************************************************/

/**********************Relation between product and categories ***************************/
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.SetNull);
/****************************************************************************************/

/**********************Relation between product his images ***************************/
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ProductImage>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .OnDelete(DeleteBehavior.SetNull);


            /************************************************************************************/


            /**********************Invoice relations*********************************************/

            modelBuilder.Entity<Invoice>()
             .HasMany(i => i.Statuses);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Order)
                .WithOne(o => o.Invoice)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Order66>()
                .HasOne(o => o.Invoice)
                .WithOne(i => i.Order)
                .OnDelete(DeleteBehavior.SetNull);

/**************************************************************************************/



/**********************Shipment relations to order*********************************************/


            modelBuilder.Entity<Shipment>()
             .HasOne(s => s.Order)
             .WithMany(o =>o.Shipments)
             .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order66>()
             .HasMany(o => o.Shipments)
             .WithOne(s => s.Order)
             .OnDelete(DeleteBehavior.SetNull);



            /**************************************************************************************/

            /**********************Supplier relations********************************************/

            modelBuilder.Entity<Supplier>()
            .HasMany(s => s.Addresses);

            modelBuilder.Entity<SupplierProduct>()
           .HasKey(Ii => new { Ii.ProductID, Ii.SupplierID });

            /**************************************************************************************/

        }
    }



}

