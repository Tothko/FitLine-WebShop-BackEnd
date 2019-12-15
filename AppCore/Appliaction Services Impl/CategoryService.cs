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
        private List<Category> WantedCategories = new List<Category>();
        private ICategoryRepository CategoryRepo;
        private IProductRepository ProductRepo;
        private List<Category> AllCategories;
        private List<Product> AllProducts;
        public CategoryService(ICategoryRepository CategoryRepository, IProductRepository ProductRepository)
        {
            CategoryRepo = CategoryRepository;
            ProductRepo = ProductRepository;
        }
        public Category Create(Category Category)
        {
            return CategoryRepo.Create(Category);
        }

        public Category Delete(int Id)
        {
            return CategoryRepo.Delete(Id);
        }

        public Category FindCategoryWithID(int Id)
        {
            return CategoryRepo.FindCategoryWithID(Id);
        }

        public Category FindCategoryProductsByCategoryName(string name)

        {
            AllCategories = CategoryRepo.ReadSimpleCategories().ToList();
            AllProducts = ProductRepo.ReadSimpleProducts().ToList();

            Category FoundCategory = new Category();
            FoundCategory = AllCategories.Find(c => c.Name == name);

            WantedCategories.Add(FoundCategory);
            SearchForSubCategories(FoundCategory);
            List<Product> WantedProducts = FindProducts(WantedCategories);
            foreach (Product Product in WantedProducts)
            {
                FoundCategory.Products.Add(Product);
            }
            

            return FoundCategory;
        }

        private List<Product> FindProducts(List<Category> WantedCategories)
        {
            List<Product> FoundProducts = new List<Product>();
            foreach (Category cat in WantedCategories)
            {
                foreach (Product prod in AllProducts)
                {
                    if (prod.CategoryID == cat.ID) FoundProducts.Add(prod);
                }
            }
            return FoundProducts;
        }

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
            
           
        }

        public IEnumerable<Category> ReadCategories()
        {
            return CategoryRepo.ReadCategories();
        }

        public Category Update(Category CategoryUpdate)
        {
            return CategoryRepo.Update(CategoryUpdate);
        }
    }
}
