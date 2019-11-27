using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Invoice

    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public Order66 Order { get; set; }
        public Invoice Invoice { get; set; }
        public List<InvoiceStatus> Statuses { get; set; }
        
        public DateTime date { get; set; }
        public string details { get; set; }
    }
}
