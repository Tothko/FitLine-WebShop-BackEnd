using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface IAddressRepository
    {
        IEnumerable<Address> ReadAddresses();
        Address Create(Address Address);
        Address Delete(int Id);
        Address Update(Address AddressUpdate);
        Address FindAddressWithID(int Id);
    }
}
