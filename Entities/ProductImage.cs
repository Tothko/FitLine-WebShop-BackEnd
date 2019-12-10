using System;

namespace Entities
{
    public class ProductImage
    {
        public int ID { get; set; }
        public int ProductDetailID { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public string url { get; set; }
    }
}
