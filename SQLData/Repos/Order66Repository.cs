using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class Order66Repository : IOrderRepository
    {
        

        readonly FitLineContext context;

        public Order66Repository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Order66 Create(Order66 Order66)
        {
            context.Orders.Add(Order66);
            context.SaveChanges();
            return context.Orders.Find(Order66.ID);
        }

        public Order66 Delete(int Id)
        {
            context.Orders.Remove(FindOrder66WithID(Id));
            context.SaveChanges();
            return null;
        }

        public Order66 FindOrder66WithID(int Id)
        {
            return context.Orders.Include(p => p.Invoice).Include(p => p.Shipments).Include(p => p.User).FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<Order66> ReadOrders()
        {
            return context.Orders.Include(p => p.Invoice).Include(p => p.Shipments).Include(p => p.User);
        }

        public Order66 Update(Order66 Order66Update)
        {
            context.Attach(Order66Update).State = EntityState.Modified;
            context.SaveChanges();
            return context.Orders.Find(FindOrder66WithID(Order66Update.ID));
        }
    }
    
}
