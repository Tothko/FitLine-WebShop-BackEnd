using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class ProductImageRepository : IProductImageRepository
    {
        

        readonly FitLineContext context;

        public ProductImageRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public ProductImage Create(ProductImage ProductImage)
        {
            context.ProductImages.Add(ProductImage);
            context.SaveChanges();
            return context.ProductImages.Find(ProductImage.ID);
        }

        public ProductImage Delete(int Id)
        {
            context.ProductImages.Remove(FindProductImageWithID(Id));
            context.SaveChanges();
            return null;
        }

        public ProductImage FindProductImageWithID(int Id)
        {
            return context.ProductImages.FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<ProductImage> ReadProductImages()
        {
            return context.ProductImages;
        }

        public ProductImage Update(ProductImage ProductImageUpdate)
        {
            context.Attach(ProductImageUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.ProductImages.Find(FindProductImageWithID(ProductImageUpdate.ID));
        }
    }
    }

