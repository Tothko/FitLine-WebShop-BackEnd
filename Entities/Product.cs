using System;
using System.Collections.Generic;

namespace Entities
{
    public class Product
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> Images { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Flavour { get; set; }

        public string Weight { get; set; }

    }
}
