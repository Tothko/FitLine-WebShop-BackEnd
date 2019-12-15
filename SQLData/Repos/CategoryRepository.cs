using AppCore.Domain_Servives;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLData.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        

        readonly FitLineContext context;

        public CategoryRepository(FitLineContext ctx)
        {
            context = ctx;
        }

        public Category Create(Category Category)
        {
            context.Categories.Add(Category);
            context.SaveChanges();
            return context.Categories.Find(Category.ID);
        }

        public Category Delete(int Id)
        {
            context.Categories.Remove(FindCategoryWithID(Id));
            context.SaveChanges();
            return null;
        }

        public Category FindCategoryWithID(int Id)
        {
            return context.Categories.Include(p => p.Categories).Include(p => p.Products).FirstOrDefault(p => p.ID == Id);

        }

        public IEnumerable<Category> ReadCategories()
        {
            return context.Categories.Include(p => p.Categories);
        }
        public IEnumerable<Category> ReadSimpleCategories()
        {
            return context.Categories;
        }
        public Category Update(Category CategoryUpdate)
        {
            context.Attach(CategoryUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return context.Categories.Find(FindCategoryWithID(CategoryUpdate.ID));
        }
    }
    
}
