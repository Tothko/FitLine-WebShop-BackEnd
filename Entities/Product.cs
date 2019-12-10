using System;
using System.Collections.Generic;

namespace Entities
{
    public class Product
    {
        public int ID { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierID { get; set; }
        public List<ProductDetail> Details { get; set; }
        public string Name { get; set; }

        
    }
}
