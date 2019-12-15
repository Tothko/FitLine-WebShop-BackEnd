using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class SupplierRepository : ISupplierRepository
    {
        

        readonly FitLineContext context;

        public SupplierRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Supplier Create(Supplier Supplier)
        {
            context.Suppliers.Add(Supplier);
            context.SaveChanges();
            return context.Suppliers.Find(Supplier.ID);
        }

        public Supplier Delete(int Id)
        {
            context.Suppliers.Remove(FindSupplierWithID(Id));
            context.SaveChanges();
            return null;
        }

        public Supplier FindSupplierWithID(int Id)
        {
            return context.Suppliers.Include(p => p.Addresses).FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<Supplier> ReadSuppliers()
        {
            return context.Suppliers.Include(p => p.Addresses);
        }

        public Supplier Update(Supplier SupplierUpdate)
        {
            context.Attach(SupplierUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.Suppliers.Find(FindSupplierWithID(SupplierUpdate.ID));
        }
    }
    }

