using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order66
    {
        public int ID { get; set; }
        public int userID { get; set; }

        public User User { get; set; }
        public List<Order66Status> Statuses { get; set; }
        public List<Order66Product> OrderProducts { get; set; }
        public Invoice Invoice { get; set; }

        public List<Shipment> Shipments { get; set; }
        public DateTime DateOfPlacement { get; set; }
        public string Details { get; set; }

    }
}
