using AppCore.Appliaction_Services_Impl;
using AppCore.Domain_Servives;
using Entities;
using Moq;
using SQLData.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestCore.ApplicationServices
{
    public class CategoryServiceTest
    {
        private ICategoryService GetService(Mock<ICategoryRepository> catRepo = null)
        {
            var categoryRepo = catRepo != null ? catRepo : new Mock<ICategoryRepository>();

            var service = new CategoryService(categoryRepo.Object,new Mock<IProductRepository>().Object);

            return service;
        }

        //-------------------Creating------------------//
        [Fact]
        public void CreateNullCategoryThrowsException()
        {
            var service = GetService();

            Exception ex = Assert.Throws<ArgumentException>(() => service.Create(null));
            Assert.Equal("Cannot create null category", ex.Message);
        }

        [Fact]
        public void CreateCategoryWithMissingNameThrowsException()
        {
            var service = GetService();

            var category = new Category() { };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(category));
            Assert.Equal("Cannot create category without a name", ex.Message);

        }

        [Fact]
        public void CreateCategoryWithBlankNameThrowsException()
        {
            var service = GetService();

            var category = new Category() { Name = "" };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(category));

            Assert.Equal("Cannot create category with blank name", ex.Message);

        }

        [Fact]
        public void CreateCategoryWithParentCategoryTheCategoryShouldExistThrowsException()
        {
            var parentCategory = new Category()
            {
                ID = 1,
                Name = "SomeCat"
            };

            var service = GetService();

            var childCategory = new Category()
            {
                Name = "Food",
                ParentCategory = parentCategory
            };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(childCategory));

            Assert.Equal("Category contains invalid parent category", ex.Message);

        }

        [Fact]
        public void CreateCategorytWithParentCategoryShouldOnlyCallReadCategoryByIdOnce()
        {
            var parentCategory = new Category()
            {
                ID = 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(parentCategory);

            var service = GetService(catRepo);

            var childCategory = new Category()
            {
                Name = "Whale",
                ParentCategory = parentCategory
            };

            service.Create(childCategory);
            catRepo.Verify(x => x.FindCategoryWithID(parentCategory.ID), Times.Once);
        }

        [Fact]
        public void CreateCategoryCreatesCategoryWithNewId()
        {
            var cat = new Category()
            {
                Name = "Whale"
            };

            const int NEW_ID = 20;

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(cr => cr.Create(It.IsAny<Category>()))
                .Returns(new Category { Name = cat.Name, ID = NEW_ID });

            var service = GetService(catRepo);

            var newCat = service.Create(cat);
            Assert.Equal(newCat.ID, NEW_ID);
        }

        [Fact]
        public void CreateCategoryCreateShouldBeCalledOnce()
        {
            var catRepo = new Mock<ICategoryRepository>();
            var service = GetService(catRepo);

            var category = new Category()
            {
                Name = "Whale"
            };

            service.Create(category);
            catRepo.Verify(x => x.Create(category), Times.Once);
        }

        /* [Fact]

         public void CreateLoopedCategoryThrowsException()
         {
             var categoryTier1 = new Category
             {
                 Id = 1,
                 Name = "Tier1",
                 Children = new List<Category>()
             };

             var categoryTier2 = new Category
             {
                 Id = 2,
                 Name = "Tier2",
                 Children = new List<Category>()
             };

             var categoryTier3 = new Category
             {
                 Id = 3,
                 Name = "Tier3",
                 Children = new List<Category>()
             };

             categoryTier3.ParentCategory = categoryTier2;
             categoryTier2.ParentCategory = categoryTier1;
             categoryTier1.Children.Add(categoryTier2);
             categoryTier2.Children.Add(categoryTier3);

             var newCategory = new Category()
             {
                 Id = 4,
                 Name = "NewBoy",
                 ParentCategory = categoryTier3,
                 Children = new List<Category> { categoryTier2 }
             };

             var repo = new Mock<ICategoryRepository>();


         }*/

        //----------------------Updating---------------------//

        [Fact]
        public void UpdateNullCategoryThrowsException()
        {
            var service = GetService();

            Exception ex = Assert.Throws<ArgumentException>(() => service.Update(null));
            Assert.Equal("Cannot update null category", ex.Message);
        }

        [Fact]
        public void UpdateCategoryWithMissingNameThrowsException()
        {
            var service = GetService();

            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(new Category()));
            Assert.Equal("Cannot update category without a name", ex.Message);

        }

        [Fact]
        public void UpdateCategoryWithBlankNameThrowsException()
        {
            var service = GetService();

            var cat = new Category() { Name = "" };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(cat));

            Assert.Equal("Cannot update category with blank name", ex.Message);
        }

        [Fact]
        public void UpdateCategoryWithParentCategoryTheCategoryShouldExistThrowsException()
        {
            var service = GetService();

            var cat = new Category() { Name = "Name",ParentCategory = new Category { ID = 1} };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(cat));

            Assert.Equal("Category contains invalid parent category", ex.Message);
        }

        [Fact]
        public void UpdateCategorytWithParentCategoryShouldOnlyCallReadCategoryByIdOnce()
        {
            var parentCategory = new Category()
            {
                ID = 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(parentCategory);

            var service = GetService(catRepo);

            var childCategory = new Category()
            {
                ID = 2,
                Name = "Whale",
                ParentCategory = parentCategory
            };

            service.Update(childCategory);
            catRepo.Verify(x => x.FindCategoryWithID(parentCategory.ID), Times.Once);
        }


        [Fact]
        public void UpdateCategoryUpdateShouldBeCalledOnce()
        {
            var catRepo = new Mock<ICategoryRepository>();
            var service = GetService(catRepo);

            var category = new Category()
            {
                ID = 1,
                Name = "Whale"
            };

            service.Update(category);
            catRepo.Verify(x => x.Update(category), Times.Once);
        }

        //----------------------Deleting---------------------//

        [Fact]

        public void DeleteCategoryDeletesCategory()
        {
            var cat = new Category()
            {
                ID = 1,
                Name = "Whale"
            };

            var catList = new List<Category> { cat };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(cr => cr.Delete(It.IsAny<int>()))
                .Callback(() => catList.Remove(cat))
                .Returns(cat);

            var service = GetService(catRepo);

            var newCat = service.Delete(cat.ID);
            Assert.Empty(catList);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void DeleteCategoryThrowsOnInvalidId(int id)
        {
            var service = GetService();

            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Delete(id));

            Assert.Equal("Category Id has to be bigger than 0", ex.Message);
        }

        [Fact]
        public void DeleteCategoryReturnsNullIfThereIsNoRecord()
        {
            var service = GetService();

            Assert.Null(service.Delete(1));
        }

        [Fact]
        public void DeleteCategoryReturnsCorrectCategoryIfIsDeleted()
        {
            var category = new Category()
            {
                ID = 1,
                Name = "Whale"
            };

            var categoryRepo = new Mock<ICategoryRepository>();
            categoryRepo.Setup(cr => cr.Delete(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(categoryRepo);

            var deletedCategory = service.Delete(category.ID);

            Assert.Equal(category, deletedCategory);
        }

        [Fact]
        public void DeleteCategoryDeleteShouldBeCalledOnce()
        {
            var categoryRepo = new Mock<ICategoryRepository>();

            var service = GetService(categoryRepo);

            service.Delete(1);
            categoryRepo.Verify(x => x.Delete(1), Times.Once);
        }

        //----------------------Reading----------------------//

        [Fact]
        public void SearchByNameReturnsCorrectCategory()
        {
            var categories = new List<Category>();
            for (int i = 0; i < 1000; i++)
            {
                categories.Add(new Category()
                {
                    ID = i,
                    Name = "Cat" + i
                });
            }

            var expectedCategory = categories.Where(c => c.Name.Equals("Cat852"))
                .FirstOrDefault();

            var categoryRepo = new Mock<ICategoryRepository>();
            categoryRepo.Setup(cr => cr.ReadCategories())
                .Returns(categories);

            var service = GetService(categoryRepo);

            var foundCategory = service.FindCategoryProductsByCategoryName("Cat852");
            Assert.Equal(expectedCategory, foundCategory);
        }

        [Fact]

        public void CategoryReadByIdReturnsCorrectCategory()
        {
            var prod = new Category()
            {
                ID = 1,
                Name = "Whale"
            };

            var CategoryRepo = new Mock<ICategoryRepository>();
            CategoryRepo.Setup(cr => cr.FindCategoryWithID(It.IsAny<int>()))
                .Returns(prod);

            var service = GetService(CategoryRepo);

            var redCategory = service.FindCategoryWithID(prod.ID);

            Assert.Equal(prod, redCategory);
        }

        [Fact]
        public void CategoryReadAllReturnsAll()
        {
            var Categories = new List<Category>();
            for (int i = 0; i < 1000; i++)
            {
                Categories.Add(new Category()
                {
                    ID = i,
                    Name = "Prod" + i
                });
            }

            var CategoryRepo = new Mock<ICategoryRepository>();
            CategoryRepo.Setup(cr => cr.ReadCategories())
                .Returns(Categories);

            var service = GetService(CategoryRepo);

            var foundCategories = service.ReadCategories();
            Assert.Equal(Categories, foundCategories);
        }
/*
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
        }*/
    }
}
