using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class ProductImageService : IProductImageService
    {

        private IProductImageRepository ProductImageRepo;
        public ProductImageService(IProductImageRepository ProductImageRepository)
        {
            ProductImageRepo = ProductImageRepository;
        }
        public ProductImage Create(ProductImage ProductImage)
        {
            return ProductImageRepo.Create(ProductImage);
        }

        public ProductImage Delete(int Id)
        {
            return ProductImageRepo.Delete(Id);
        }

        public ProductImage FindProductImageWithID(int Id)
        {
            return ProductImageRepo.FindProductImageWithID(Id);

        }

        public IEnumerable<ProductImage> ReadProductImages()
        {
            return ProductImageRepo.ReadProductImages();
        }

        public ProductImage Update(ProductImage ProductImageUpdate)
        {
            return ProductImageRepo.Update(ProductImageUpdate);
        }
    }
}
