using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Application_Services
{
    public interface IProductService
    {

        IEnumerable<Product> ReadProducts();

        IEnumerable<Product> ReadFiltered(ProductsFilter filter);
        Product Create(Product Product);
        Product Delete(int Id);
        Product Update(Product ProductUpdate);
        Product FindProductWithID(int Id);

    }
}
