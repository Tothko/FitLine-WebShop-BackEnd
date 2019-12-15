using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
namespace SQLData.Repos
{
    public class FakeProductRepository : IProductRepository
    {

        
        private readonly List<Product> FakeProducts = new List<Product>()
            {
            new Product {ID = 1, Name = "TestProduct1", CategoryID = 1},
            new Product {ID = 2, Name = "TestProduct2", CategoryID = 1},
            new Product {ID = 3, Name = "TestProduct3", CategoryID = 1},
            new Product {ID = 4, Name = "TestProduct4", CategoryID = 2},
            new Product {ID = 5, Name = "TestProduct5", CategoryID = 2},
            new Product {ID = 6, Name = "TestProduct6", CategoryID = 3},
            new Product {ID = 7, Name = "TestProduct7", CategoryID = 3},
            new Product {ID = 8, Name = "TestProduct8", CategoryID = 4},
            new Product {ID = 9, Name = "TestProduct9", CategoryID = 4},
            new Product {ID = 10, Name = "TestProduct10", CategoryID = 5},
            new Product {ID = 11, Name = "TestProduct11", CategoryID = 5},
            new Product {ID = 12, Name = "TestProduct12", CategoryID = 6},
            new Product {ID = 13, Name = "TestProduct13", CategoryID = 6},
            new Product {ID = 14, Name = "TestProduct14", CategoryID = 7},
            new Product {ID = 15, Name = "TestProduct15", CategoryID = 7},
            new Product {ID = 16, Name = "TestProduct16", CategoryID = 8},
            new Product {ID = 17, Name = "TestProduct17", CategoryID = 8},
            new Product {ID = 18, Name = "TestProduct18", CategoryID = 9},
            new Product {ID = 19, Name = "TestProduct19", CategoryID = 9},
            new Product {ID = 20, Name = "TestProduct20", CategoryID = 9}
        };

        public Product Create(Product Product)
        {
            return null;
        }

        public Product Delete(int Id)
        {
            return null;
        }

        public Product FindProductWithID(int Id)
        {
            return null;

        }

        public IEnumerable<Product> ReadProducts()
        {
            return FakeProducts;
        }

        public object ReadSimpleProducts()
        {
            return FakeProducts;
        }

        public Product Update(Product ProductUpdate)
        {
            return null;
        }

        IEnumerable<Product> IProductRepository.ReadSimpleProducts()
        {
            throw new NotImplementedException();
        }
    }
    }*/

