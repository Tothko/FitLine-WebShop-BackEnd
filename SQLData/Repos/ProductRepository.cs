﻿using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class ProductRepository : IProductRepository
    {
        

        readonly FitLineContext context;

        public ProductRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Product Create(Product Product)
        {
            context.Products.Add(Product);
            context.SaveChanges();
            return context.Products.Find(Product.ID);
        }

        public Product Delete(int Id)
        {
            var product = FindProductWithID(Id);
            if(product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
                return product;
            }
            return null;
        }

        public Product FindProductWithID(int Id)
        {
            return context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Images)
                .FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<Product> ReadProducts()
        {
            return context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Images);
        }

        public IEnumerable<Product> ReadSimpleProducts()
        {
            return context.Products
                .AsNoTracking()
                .ToList();
        }

        public Product Update(Product ProductUpdate)
        {
            context.Attach(ProductUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return ProductUpdate;
        }
    }
    }

