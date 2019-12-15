using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public int CategoryId { get; set; }

        public SupplierDTO Supplier { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

    };
}
