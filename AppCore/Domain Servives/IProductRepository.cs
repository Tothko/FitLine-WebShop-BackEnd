using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface IProductRepository
    {
        IEnumerable<Product> ReadProducts();
        Product Create(Product Product);
        Product Delete(int Id);
        Product Update(Product ProductUpdate);
        Product FindProductWithID(int Id);
        IEnumerable<Product> ReadSimpleProducts(); 
    }
}
