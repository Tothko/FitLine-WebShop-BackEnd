using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Application_Services
{
    public interface IAddressService
    {
        IEnumerable<Address> ReadAddresses();
        Address Create(Address Address);
        Address Delete(int Id);
        Address Update(Address AddressUpdate);
        Address FindAddressWithID(int Id);
    }
}
