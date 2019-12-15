using System;
using System.Collections.Generic;

namespace Entities
{
    public class Product
    {
        public int ID { get; set; }
        public Category Category { get; set; }
     //   public int CategoryID { get; set; }
        public Supplier Supplier { get; set; }
      //  public int SupplierID { get; set; }
        public List<ProductImage> Images { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }

        public string Document { get; set; }

        public double Rating { get; set; }

    }
}
