using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> ReadInvoices();
        Invoice Create(Invoice Invoice);
        Invoice Delete(int Id);
        Invoice Update(Invoice InvoiceUpdate);
        Invoice FindInvoiceWithID(int Id);
    }
}
