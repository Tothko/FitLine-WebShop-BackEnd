using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Application_Services
{
    public interface IOrderService
    {
        IEnumerable<Order66> ReadOrders();
        Order66 Create(Order66 Order66);
        Order66 Delete(int Id);
        Order66 Update(Order66 Order66Update);
        Order66 FindOrder66WithID(int Id);
    }
}
