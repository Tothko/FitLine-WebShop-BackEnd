using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SupplierProduct
    {
        public int SupplierID { get; set; }
        public Supplier Supplier  { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
    }
}
