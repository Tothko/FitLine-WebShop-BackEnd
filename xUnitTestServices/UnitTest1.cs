using AppCore.Appliaction_Services_Impl;
using AppCore.Domain_Servives;
using Entities;
using SQLData.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace xUnitTestServices
{
    public class TestCategoryService
    {
        [Fact]
        public void FindCategoryProductsByCategoryName()
        {
            int Id = 0;
            IProductRepository ProdRepo = new FakeProductRepository();
            ICategoryRepository CatRepo = new FakeCategoryRepository();
            List<Product> expected = new List<Product>();
            foreach (Product Prod in ProdRepo.ReadProducts())
            {
                if (Prod.CategoryID == 1) expected.Add(Prod);
                if (Prod.CategoryID == 2) expected.Add(Prod);
                if (Prod.CategoryID == 3) expected.Add(Prod);
                if (Prod.CategoryID == 5) expected.Add(Prod);
                if (Prod.CategoryID == 6) expected.Add(Prod);
                if (Prod.CategoryID == 9) expected.Add(Prod);
            }
            
            ICategoryService CS = new CategoryService(CatRepo, ProdRepo);


            List<Product> actual = CS.FindCategoryProductsByCategoryName(CatRepo.ReadCategories().ToList().ElementAt(Id).Name).Products;


            Assert.Equal(expected, actual);
        }
    }
}

