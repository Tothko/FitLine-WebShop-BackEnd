using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ShipmentProduct
    {
        public int OrderItemID { get; set; }
        public Order66Product OrderProduct { get; set; }
        public Shipment Shipment { get; set; }
        public int ShipmentID { get; set; }
    }
}
