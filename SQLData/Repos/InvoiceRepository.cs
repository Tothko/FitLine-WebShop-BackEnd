using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class InvoiceRepository : IInvoiceRepository
    {
        

        readonly FitLineContext context;

        public InvoiceRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Invoice Create(Invoice Invoice)
        {
            context.Invoices.Add(Invoice);
            context.SaveChanges();
            return context.Invoices.Find(Invoice.ID);
        }

        public Invoice Delete(int Id)
        {
            context.Invoices.Remove(FindInvoiceWithID(Id));
            context.SaveChanges();
            return null;
        }

        public Invoice FindInvoiceWithID(int Id)
        {
            return context.Invoices.Include(p => p.Order).FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<Invoice> ReadInvoices()
        {
            return context.Invoices.Include(p => p.Order);
        }

        public Invoice Update(Invoice InvoiceUpdate)
        {
            context.Attach(InvoiceUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.Invoices.Find(FindInvoiceWithID(InvoiceUpdate.ID));
        }
    }
}


