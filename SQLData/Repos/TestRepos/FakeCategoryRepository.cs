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
    public class FakeCategoryRepository : ICategoryRepository
    {

        private readonly List<Category> FakeCategories = new List<Category>()
            {
            new Category { ID = 1, Name = "Test1", Description = "Test", ParentCategoryID = 0 },
            new Category { ID = 2, Name = "Test2", Description = "Test", ParentCategoryID = 1 },
            new Category { ID = 3, Name = "Test3", Description = "Test", ParentCategoryID = 1 },
            new Category { ID = 4, Name = "Test4", Description = "Test", ParentCategoryID = 0 },
            new Category { ID = 5, Name = "Test5", Description = "Test", ParentCategoryID = 2 },
            new Category { ID = 6, Name = "Test6", Description = "Test", ParentCategoryID = 3 },
            new Category { ID = 7, Name = "Test7", Description = "Test", ParentCategoryID = 4 },
            new Category { ID = 8, Name = "Test8", Description = "Test", ParentCategoryID = 4 },
            new Category { ID = 9, Name = "Test9", Description = "Test", ParentCategoryID = 5 }
            };

        public Category Create(Category Category)
        {
            return null;
        }

        public Category Delete(int Id)
        {
            return null;
        }

        public Category FindCategoryWithID(int Id)
        {
            return null;

        }

        public IEnumerable<Category> ReadCategories()
        {
            return FakeCategories;
        }

        public IEnumerable<Category> ReadSimpleCategories()
        {
            return FakeCategories;
        }

        public Category Update(Category CategoryUpdate)
        {
            return null;
        }
    }
    
}
*/