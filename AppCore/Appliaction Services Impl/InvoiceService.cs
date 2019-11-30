using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceRepository InvoiceRepo;
        public InvoiceService(IInvoiceRepository InvoiceRepository)
        {
            InvoiceRepo = InvoiceRepository;
        }
        public Invoice Create(Invoice Invoice)
        {
            return InvoiceRepo.Create(Invoice);
        }

        public Invoice Delete(int Id)
        {
            return InvoiceRepo.Delete(Id);
        }

        public Invoice FindInvoiceWithID(int Id)
        {
            return InvoiceRepo.FindInvoiceWithID(Id);
        }

        public IEnumerable<Invoice> ReadInvoices()
        {
            return InvoiceRepo.ReadInvoices();
        }

        public Invoice Update(Invoice InvoiceUpdate)
        {
            return InvoiceRepo.Update(InvoiceUpdate);
        }
    }
}
