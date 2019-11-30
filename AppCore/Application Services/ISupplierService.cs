using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Application_Services
{
    public interface ISupplierService

    {
        IEnumerable<Supplier> ReadSuppliers();
        Supplier Create(Supplier Supplier);
        Supplier Delete(int Id);
        Supplier Update(Supplier SupplierUpdate);
        Supplier FindSupplierWithID(int Id);
    }
}
