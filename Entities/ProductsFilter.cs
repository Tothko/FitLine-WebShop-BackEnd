using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductsFilter
    {
        public ProductsFilter()
        {
            MaxPrice = double.MaxValue;
            MinPrice = double.MinValue;
            CategoryId = 0;
        }
        public int CategoryId { get; set; }

        public double MaxPrice { get; set; }

        public double MinPrice { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public List<int> Suppliers { get; set; }

        public string SearchTextName { get; set; }

        public bool Accepts(Product product)
        {
            if (!String.IsNullOrEmpty(SearchTextName) && !product.Name.Contains(SearchTextName))
            {
                return false;
            }

            if (product.Price < MinPrice || product.Price > MaxPrice)
            {
                return false;
            }

            if (Suppliers != null && Suppliers.Count > 0 && !Suppliers.Contains(product.Supplier.ID))
            {
                return false;
            }

            return true;
        }
    }
}
