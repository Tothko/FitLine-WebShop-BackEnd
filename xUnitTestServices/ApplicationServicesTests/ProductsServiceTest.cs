using AppCore.Appliaction_Services_Impl;
using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace TestCore.ApplicationServices
{
    public class ProductsServiceTest
    {
        private IProductService GetService(Mock<IProductRepository> prodRepo = null
            ,Mock<ICategoryRepository> catRepo= null)
        {
            var productRepo = prodRepo != null ? prodRepo : new Mock<IProductRepository>();
            var categoryRepo = catRepo != null ? catRepo : new Mock<ICategoryRepository>();

            var service = new ProductService(productRepo.Object,categoryRepo.Object);

            return service;
        }

        //----------------------Creating---------------------------//
        [Fact]
        public void CreateNullProductThrowsException()
        {
            var service = GetService();

            Exception ex = Assert.Throws<ArgumentException>(() => service.Create(null));
            Assert.Equal("Cannot create null product", ex.Message);
        }

        [Fact]
        public void CreateProductWithMissingNameThrowsException()
        {
            var category = new Category { ID = 1, Name = "Cat" };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null, catRepo);

            var product = new Product() { };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(product));
            Assert.Equal("Cannot create product without a name", ex.Message);

        }

        [Fact]
        public void CreateProductWithBlankNameThrowsException()
        {
            var category = new Category { ID = 1, Name = "Cat" };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null,catRepo);

            var prod = new Product() { Name = "",Category = category };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(prod));

            Assert.Equal("Cannot create product with blank name", ex.Message);

        }

        [Fact]
        public void CreateProductWithoutCategoryThrowsException()
        {
            var service = GetService();

            var prod = new Product() { Name = "Name" };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(prod));

            Assert.Equal("Cannot create product without a category", ex.Message);

        }

        [Theory]
        [InlineData(double.MinValue)]
        [InlineData(-1)]
        [InlineData(double.MaxValue)]
        [InlineData(5.01)]
        public void CreateProductInvalidRatingThrowsException(double rating)
        {
            var category = new Category { ID = 1, Name = "Cat" };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null, catRepo);

            var prod = new Product() { Name = "Name", Rating = rating, Category = category };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(prod));

            Assert.Equal("Product Rating has to be between 0-5", ex.Message);
        }

        [Fact]
        public void CreateProductWithCategoryTheCategoryShouldExistThrowsException()
        {
            var category = new Category()
            {
                ID = 1,
                Name = "SomeCat"
            };

            var service = GetService();


            var prod = new Product()
            {
                Name = "Food",
                Category = category
            };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Create(prod));

            Assert.Equal("Product contains invalid category", ex.Message);

        }

        [Fact]
        public void CreateProductWithCategoryShouldOnlyCallReadCategoryByIdOnce()
        {
            var category = new Category()
            {
                ID= 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null,catRepo);

            var prod = new Product()
            {
                Name = "Whale",
                Category = category
            };

            service.Create(prod);
            catRepo.Verify(x => x.FindCategoryWithID(category.ID), Times.Once);
        }

        [Fact]
        public void CreateProductCreatesProductWithNewId()
        {
            //Setup category
            var category = new Category()
            {
                ID= 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);
            
            var prod = new Product()
            {
                Name = "Whale",
                Category = category
            };

            const int NEW_ID = 20;

            var productRepo = new Mock<IProductRepository>();
            productRepo.Setup(cr => cr.Create(It.IsAny<Product>()))
                .Returns(new Product {Name = prod.Name,Category = prod.Category,ID= NEW_ID });

            var service = GetService(productRepo, catRepo);

            var newProd = service.Create(prod);
            Assert.Equal(newProd.ID, NEW_ID);
        }

        [Fact]
        public void CreateProductCreateShouldBeCalledOnce()
        {
            var category = new Category()
            {
                ID= 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var prodRepo = new Mock<IProductRepository>();

            var service = GetService(prodRepo, catRepo);

            var prod = new Product()
            {
                Name = "Whale",
                Category = category
            };

            service.Create(prod);
            prodRepo.Verify(x => x.Create(prod), Times.Once);
        }

        //----------------------Updating---------------------//

        [Fact]
        public void UpdateNullProductThrowsException()
        {
            var service = GetService();

            Exception ex = Assert.Throws<ArgumentException>(() => service.Update(null));
            Assert.Equal("Cannot update null product", ex.Message);
        }

        [Fact]
        public void UpdateProductWithMissingNameThrowsException()
        {
            var category = new Category { ID= 1, Name = "Cat" };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null, catRepo);

            var product = new Product() { };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(product));
            Assert.Equal("Cannot update product without a name", ex.Message);

        }

        [Fact]
        public void UpdateProductWithBlankNameThrowsException()
        {
            var category = new Category { ID= 1, Name = "Cat" };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null, catRepo);

            var prod = new Product() { Name = "", Category = category };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(prod));

            Assert.Equal("Cannot update product with blank name", ex.Message);

        }

        [Fact]
        public void UpdateProductWithoutCategoryThrowsException()
        {
            var service = GetService();

            var prod = new Product() { Name = "Name" };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(prod));

            Assert.Equal("Cannot update product without a category", ex.Message);

        }

        [Theory]
        [InlineData(double.MinValue)]
        [InlineData(-1)]
        [InlineData(double.MaxValue)]
        [InlineData(5.01)]

        public void UpdateProductInvalidRatingThrowsException(double rating)
        {
            var category = new Category { ID= 1, Name = "Cat" };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null, catRepo);

            var prod = new Product() { Name = "Name", Rating = rating, Category = category };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(prod));

            Assert.Equal("Product Rating has to be between 0-5", ex.Message);
        }

        [Fact]
        public void UpdateProductWithCategoryTheCategoryShouldExistThrowsException()
        {
            var category = new Category()
            {
                ID= 1,
                Name = "SomeCat"
            };

            var service = GetService();


            var prod = new Product()
            {
                Name = "Food",
                Category = category
            };
            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Update(prod));

            Assert.Equal("Product contains invalid category", ex.Message);

        }

        [Fact]
        public void UpdateProductWithCategoryShouldOnlyCallReadCategoryByIdOnce()
        {
            var category = new Category()
            {
                ID= 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var service = GetService(null, catRepo);

            var prod = new Product()
            {
                Name = "Whale",
                Category = category
            };

            service.Update(prod);
            catRepo.Verify(x => x.FindCategoryWithID(category.ID), Times.Once);
        }

        [Fact]
        public void UpdateProductUpdatesProduct()
        {
            //Setup category
            var category = new Category()
            {
                ID= 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var prod = new Product()
            {
                Name = "Whale",
                Category = category
            };


            var productRepo = new Mock<IProductRepository>();
            productRepo.Setup(cr => cr.Update(It.IsAny<Product>()))
                .Returns(prod);

            var service = GetService(productRepo, catRepo);

            var newProd = service.Update(prod);
            Assert.Equal(newProd, prod);
        }

        [Fact]
        public void UpdateProductUpdateShouldBeCalledOnce()
        {
            var category = new Category()
            {
                ID= 1,
                Name = "cat"
            };

            var catRepo = new Mock<ICategoryRepository>();
            catRepo.Setup(x => x.FindCategoryWithID(It.IsAny<int>()))
                .Returns(category);

            var prodRepo = new Mock<IProductRepository>();

            var service = GetService(prodRepo, catRepo);

            var prod = new Product()
            {
                ID= 1,
                Name = "Whale",
                Category = category
            };

            service.Update(prod);
            prodRepo.Verify(x => x.Update(prod), Times.Once);
        }

        //----------------------Deleting---------------------//

        [Fact]

        public void DeleteProductDeletesProduct()
        {
            var prod = new Product()
            {
                ID= 1,
                Name = "Whale"
            };

            var prodList = new List<Product> { prod };


            var productRepo = new Mock<IProductRepository>();
            productRepo.Setup(cr => cr.Delete(It.IsAny<int>()))
                .Callback(()=>prodList.Remove(prod))
                .Returns(prod);

            var service = GetService(productRepo);

            var newProd = service.Delete(prod.ID);
            Assert.Empty(prodList);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void DeleteProductThrowsOnInvalidId(int id)
        {
            var service = GetService();

            Exception ex = Assert.Throws<ArgumentException>(() =>
                service.Delete(id));

            Assert.Equal("Product Id has to be bigger than 0", ex.Message);
        }

        [Fact]
        public void DeleteProductReturnsNullIfThereIsNoRecord()
        {
            var service = GetService();

            Assert.Null(service.Delete(1));
        }

        [Fact]
        public void DeleteProductReturnsCorrectProductIfIsDeleted()
        {
            var prod = new Product()
            {
                ID = 1,
                Name = "Whale"
            };

            var productRepo = new Mock<IProductRepository>();
            productRepo.Setup(cr => cr.Delete(It.IsAny<int>()))
                .Returns(prod);

            var service = GetService(productRepo);

            var deletedProduct = service.Delete(prod.ID);

            Assert.Equal(prod, deletedProduct);
        }

        [Fact]
        public void DeleteProductDeleteShouldBeCalledOnce()
        {
            var prodRepo = new Mock<IProductRepository>();

            var service = GetService(prodRepo);

            service.Delete(1);
            prodRepo.Verify(x => x.Delete(1), Times.Once);
        }

        //----------------------Reading----------------------//

        [Fact]
        public void SearchReturnsCorrectProduct()
        {
            var products = new List<Product>();
            for (int i = 0; i < 1000; i++)
            {
                products.Add(new Product()
                {
                    ID = i,
                    Name = "Prod" + i
                });
            }

            var filter = new ProductsFilter()
            {
                CurrentPage = 1,
                PageSize = 10,
                SearchTextName = "Prod1"
            };

            var expectedFilteredList = products.Where(c => c.Name.Contains(filter.SearchTextName))
                    .Take(10);

            var productRepo = new Mock<IProductRepository>();
            productRepo.Setup(cr => cr.ReadProducts())
                .Returns(products);

            var service = GetService(productRepo);

            var foundProducts = service.ReadFiltered(filter);
            Assert.Equal(expectedFilteredList, foundProducts);
        }

        [Fact]

        public void ProductReadByIdReturnsCorrectProduct()
        {
            var prod = new Product()
            {
                ID = 1,
                Name = "Whale"
            };

            var productRepo = new Mock<IProductRepository>();
            productRepo.Setup(cr => cr.FindProductWithID(It.IsAny<int>()))
                .Returns(prod);

            var service = GetService(productRepo);

            var redProduct = service.FindProductWithID(prod.ID);

            Assert.Equal(prod, redProduct);
        }

        [Fact]
        public void ProductReadAllReturnsAll()
        {
            var products = new List<Product>();
            for (int i = 0; i < 1000; i++)
            {
                products.Add(new Product()
                {
                    ID = i,
                    Name = "Prod" + i
                });
            }

            var productRepo = new Mock<IProductRepository>();
            productRepo.Setup(cr => cr.ReadProducts())
                .Returns(products);

            var service = GetService(productRepo);

            var foundProducts = service.ReadProducts();
            Assert.Equal(products, foundProducts);
        }
    }
}
