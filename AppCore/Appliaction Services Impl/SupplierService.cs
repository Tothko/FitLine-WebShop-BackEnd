using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class SupplierService : ISupplierService
    {

        private ISupplierRepository SupplierRepo;
        public SupplierService(ISupplierRepository SupplierRepository)
        {
            SupplierRepo = SupplierRepository;
        }
        public Supplier Create(Supplier Supplier)
        {
            return SupplierRepo.Create(Supplier);
        }

        public Supplier Delete(int Id)
        {
            return SupplierRepo.Delete(Id);
        }

        public Supplier FindSupplierWithID(int Id)
        {
            return SupplierRepo.FindSupplierWithID(Id);
        }

        public IEnumerable<Supplier> ReadSuppliers()
        {
            return SupplierRepo.ReadSuppliers();
        }

        public Supplier Update(Supplier SupplierUpdate)
        {
            return SupplierRepo.Update(SupplierUpdate);
        }
    }
}
