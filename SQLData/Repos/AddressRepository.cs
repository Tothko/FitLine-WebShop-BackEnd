using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class AddressRepository : IAddressRepository
    {
        

        readonly FitLineContext context;

        public AddressRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Address Create(Address Address)
        {
            context.Addresses.Add(Address);
            context.SaveChanges();
            return context.Addresses.Find(Address.ID);
        }

        public Address Delete(int Id)
        {
            context.Addresses.Remove(FindAddressWithID(Id));
            context.SaveChanges();
            return null;
        }

        public Address FindAddressWithID(int Id)
        {
            if (context.Addresses.FirstOrDefault(p => p.ID == Id).Supplier != null)
            {
                return context.Addresses.Include(a => a.Supplier).FirstOrDefault(p => p.ID == Id);
            }
            else if (context.Addresses.FirstOrDefault(p => p.ID == Id).User != null)
            {
                return context.Addresses.Include(a => a.User).FirstOrDefault(p => p.ID == Id);
            }
            else
            {
                return context.Addresses.FirstOrDefault(p => p.ID == Id);
            }
            
        }

        public IEnumerable<Address> ReadAddresses()
        {
            
            return context.Addresses.Include(p => p.Supplier).Include(p => p.User);
        }

        public Address Update(Address AddressUpdate)
        {
            context.Attach(AddressUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.Addresses.Find(FindAddressWithID(AddressUpdate.ID));
        }
    }
    }

