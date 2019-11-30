using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class ProductService : IProductService
    {

        private IProductRepository ProductRepo;
        public ProductService(IProductRepository ProductRepository)
        {
            ProductRepo = ProductRepository;
        }
        public Product Create(Product Product)
        {
            return ProductRepo.Create(Product);
        }

        public Product Delete(int Id)
        {
            return ProductRepo.Delete(Id);
        }

        public Product FindProductWithID(int Id)
        {
            return ProductRepo.FindProductWithID(Id);

        }

        public IEnumerable<Product> ReadProducts()
        {
            return ProductRepo.ReadProducts();
        }

        public Product Update(Product ProductUpdate)
        {
            return ProductRepo.Update(ProductUpdate);
        }
    }
}
