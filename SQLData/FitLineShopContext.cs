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
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatuses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressUser> AddressUsers { get; set; }
        public DbSet<Payment> Payments { get; set; }





    }
}
