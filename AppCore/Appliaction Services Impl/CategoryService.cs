using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepo;
        private IProductRepository _productRepo;

        public CategoryService(ICategoryRepository CategoryRepository, IProductRepository ProductRepository)
        {
            _categoryRepo = CategoryRepository;
            _productRepo = ProductRepository;
        }

        public Category Create(Category category)
        {
            if(category == null)
            {
                throw new ArgumentException("Cannot create null category");
            }

            if(category.Name == null)
            {
                throw new ArgumentException("Cannot create category without a name");
            }

            if(category.Name == "")
            {
                throw new ArgumentException("Cannot create category with blank name");
            }

            if(category.ParentCategory != null)
            {
                var parent = _categoryRepo.FindCategoryWithID(category.ParentCategory.ID);

                if(parent == null)
                {
                    throw new ArgumentException("Category contains invalid parent category");
                }
            }

            return _categoryRepo.Create(category);
        }

        public Category Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("Category Id has to be bigger than 0");
            }

            return _categoryRepo.Delete(id);
        }

        public Category FindCategoryWithID(int Id)
        {
            return _categoryRepo.FindCategoryWithID(Id);
        }

        public Category FindCategoryProductsByCategoryName(string name)
        {
            var allCategories = _categoryRepo.ReadCategories();

            var foundCategory = allCategories.Where(c => c.Name.ToLower().Equals(name.ToLower()))
                .FirstOrDefault();

            if(foundCategory == null)
            {
                throw new ArgumentException($"There is no category by name: {name}");
            }

            
          /*  var allProducts = _productRepo.ReadSimpleProducts();

            var wantedCategories = GetSubCategories(foundCategory);
            var wantedProducts = FindProducts(wantedCategories,allProducts);
            foreach (Product Product in wantedProducts)
            {
                foundCategory.Products.Add(Product);
            }*/
         
            return foundCategory;
        }

        /*private List<Product> FindProducts(IEnumerable<Category> WantedCategories,IEnumerable<Product> allProducts)
        {
            List<Product> FoundProducts = new List<Product>();
            foreach (Category cat in WantedCategories)
            {
                foreach (Product prod in allProducts)
                {
                    if (prod.CategoryID == cat.ID) FoundProducts.Add(prod);
                }
            }
            return FoundProducts;
        }*/

        private IEnumerable<Category> GetSubCategories(Category category)
        {
            var rval = new List<Category>();
            rval.Add(category);

            if (category.Children != null && category.Children.Count > 0)
            {
                foreach (var children in category.Children)
                {
                    rval = rval.Concat(GetSubCategories(children)).ToList();
                }
            }
            return rval;
        }
        /*
        private void SearchForSubCategories(Category FoundCategory)
        {
            List<Category> SubCategories = new List<Category>();
            foreach (Category cat in AllCategories)
            { 
                    if (cat.ParentCategoryID == FoundCategory.ID)
                {
                    SubCategories.Add(cat);
                }
                if (SubCategories.Count > 0)
                {
                    WantedCategories.Add(SubCategories.ElementAt(0));
                    SearchForSubCategories(SubCategories.ElementAt(0));
                    SubCategories.RemoveAt(0);
                }
            }
        }*/

        public IEnumerable<Category> ReadCategories()
        {
            return _categoryRepo.ReadCategories();
        }

        public Category Update(Category category)
        {
            if (category == null)
            {
                throw new ArgumentException("Cannot update null category");
            }

            if (category.Name == null)
            {
                throw new ArgumentException("Cannot update category without a name");
            }

            if (category.Name == "")
            {
                throw new ArgumentException("Cannot update category with blank name");
            }

            if (category.ParentCategory != null)
            {
                var parent = _categoryRepo.FindCategoryWithID(category.ParentCategory.ID);

                if (parent == null)
                {
                    throw new ArgumentException("Category contains invalid parent category");
                }
            }

            return _categoryRepo.Update(category);
        }
    }
}
