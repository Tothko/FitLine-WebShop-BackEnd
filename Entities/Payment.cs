using System;

namespace Entities
{
    public class Payment
    {
        public int ID { get; set; }
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
    }
}
