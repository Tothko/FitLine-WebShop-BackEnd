using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> ReadSuppliers();
        Supplier Create(Supplier Supplier);
        Supplier Delete(int Supplier);
        Supplier Update(Supplier SupplierUpdate);
        Supplier FindSupplierWithID(int Id);
    }
}
