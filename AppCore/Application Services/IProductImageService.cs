using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Application_Services
{
    public interface IProductImageService
    {

        IEnumerable<ProductImage> ReadProductImages();
        ProductImage Create(ProductImage ProductImage);
        ProductImage Delete(int Id);
        ProductImage Update(ProductImage ProductImageUpdate);
        ProductImage FindProductImageWithID(int Id);

    }
}
