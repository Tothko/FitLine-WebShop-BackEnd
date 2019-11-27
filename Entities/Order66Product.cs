using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order66Product
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public Order66 Order { get; set; }

        public List<Order66Status> Statuses { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string Details { get; set; }
    }
}
