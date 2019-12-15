using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class ProductService : IProductService
    {
        /*
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

        public IEnumerable<Product> ReadFiltered(ProductsFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ReadProducts()
        {
            return ProductRepo.ReadProducts();
        }

        public Product Update(Product ProductUpdate)
        {
            return ProductRepo.Update(ProductUpdate);
        }*/

        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        public ProductService(IProductRepository productRepo, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        public Product Create(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Cannot create null product");
            }

            if (product.Name == null)
            {
                throw new ArgumentException("Cannot create product without a name");
            }

            if (product.Name == "")
            {
                throw new ArgumentException("Cannot create product with blank name");
            }

            if (product.Category == null)
            {
                throw new ArgumentException("Cannot create product without a category");
            }

            if (product.Rating < 0 || product.Rating > 5)
            {
                throw new ArgumentException("Product Rating has to be between 0-5");
            }


            //Check Category
            var category = _categoryRepo.FindCategoryWithID(product.Category.ID);

            if (category == null)// || !category.Name.Equals(product.Category.Name))
            {
                throw new ArgumentException("Product contains invalid category");
            }

            return _productRepo.Create(product);
        }

        public Product Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("Product Id has to be bigger than 0");
            }

            return _productRepo.Delete(id);
        }

        private List<int> GetCategoriesSubIds(Category cat)
        {
            var rval = new List<int>();
            rval.Add(cat.ID);

            if (cat.Categories != null && cat.Categories.Count > 0)
            {
                foreach (var children in cat.Categories)
                {
                    rval = rval.Concat(GetCategoriesSubIds(children)).ToList();
                }
            }
            return rval;
        }

        public IEnumerable<Product> ReadFiltered(ProductsFilter filter)
        {
            if (filter == null || (filter.PageSize == 0 && filter.CurrentPage == 0))
            {
                return ReadProducts();
            }

            var allItems = _productRepo.ReadProducts()
                .Where(item => filter.Accepts(item));
            IEnumerable<Product> page;

            if (filter.CategoryId > 0)
            {
                var category = _categoryRepo.FindCategoryWithID(filter.CategoryId);

                var acceptedCategoryIds = GetCategoriesSubIds(category);

                allItems = allItems
                    .Where(item => acceptedCategoryIds.Contains(item.Category.ID));
            }

            page = allItems
                .Skip((filter.CurrentPage - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (page != null)
            {
                return page;
            }

            return new List<Product>();
        }

        public Product Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Cannot update null product");
            }

            if (product.Name == null)
            {
                throw new ArgumentException("Cannot update product without a name");
            }

            if (product.Name == "")
            {
                throw new ArgumentException("Cannot update product with blank name");
            }

            if (product.Category == null)
            {
                throw new ArgumentException("Cannot update product without a category");
            }

            if (product.Rating < 0 || product.Rating > 5)
            {
                throw new ArgumentException("Product Rating has to be between 0-5");
            }


            //Check Category
            var category = _categoryRepo.FindCategoryWithID(product.Category.ID);

            if (category == null)// || !category.Name.Equals(product.Category.Name))
            {
                throw new ArgumentException("Product contains invalid category");
            }

            return _productRepo.Update(product);
        }

        public IEnumerable<Product> ReadProducts()
        {
            return _productRepo.ReadProducts();
        }

        public Product FindProductWithID(int Id)
        {
            if (Id < 1)
            {
                throw new ArgumentException("Product Id has to be bigger than 0");
            }

            return _productRepo.FindProductWithID(Id);
        }
    }
}
