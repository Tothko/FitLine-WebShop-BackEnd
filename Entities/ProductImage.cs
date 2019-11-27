using System;

namespace Entities
{
    public class ProductImage
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public string url { get; set; }
    }
}
