using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Shipment
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public Order66 Order { get; set; }
        public string trackingNumber { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
    }
}
