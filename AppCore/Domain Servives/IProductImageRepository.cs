using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface IProductImageRepository
    {
        IEnumerable<ProductImage> ReadProductImages();
        ProductImage Create(ProductImage ProductImage);
        ProductImage Delete(int Id);
        ProductImage Update(ProductImage ProductImageUpdate);
        ProductImage FindProductImageWithID(int Id);
    }
}
