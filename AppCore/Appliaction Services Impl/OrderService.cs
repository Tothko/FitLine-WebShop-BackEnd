using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class OrderService : IOrderService
    {
        private IOrderRepository OrderRepo;
        public OrderService(IOrderRepository OrderRepository)
        {
            OrderRepo = OrderRepository;
        }
        public Order66 Create(Order66 Order66)
        {
            return OrderRepo.Create(Order66);
        }

        public Order66 Delete(int Id)
        {
            return OrderRepo.Delete(Id);
        }

        public Order66 FindOrder66WithID(int Id)
        {
            return OrderRepo.FindOrder66WithID(Id);
        }

        public IEnumerable<Order66> ReadOrders()
        {
            return OrderRepo.ReadOrders();
        }

        public Order66 Update(Order66 Order66Update)
        {
            return OrderRepo.Update(Order66Update);
        }
    }
}
