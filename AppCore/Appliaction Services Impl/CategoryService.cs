using AppCore.Application_Services;
using AppCore.Domain_Servives;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Appliaction_Services_Impl
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository CategoryRepo;
        public CategoryService(ICategoryRepository CategoryRepository)
        {
            CategoryRepo = CategoryRepository;
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
