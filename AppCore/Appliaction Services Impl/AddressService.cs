using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class AddressService : IAddressService
    {
        private IAddressRepository AddressRepo;
        public AddressService(IAddressRepository AddressRepository)
        {
            AddressRepo = AddressRepository;
        }
        public Address Create(Address Address)
        {
            return AddressRepo.Create(Address);
        }

        public Address Delete(int Id)
        {
            return AddressRepo.Delete(Id);
        }

        public Address FindAddressWithID(int Id)
        {
            return AddressRepo.FindAddressWithID(Id);
        }

        public IEnumerable<Address> ReadAddresses()
        {
            return AddressRepo.ReadAddresses();
        }

        public Address Update(Address AddressUpdate)
        {
            return AddressRepo.Update(AddressUpdate);
        }
    }
}
