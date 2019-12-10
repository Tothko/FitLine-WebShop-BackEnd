using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Domain_Servives
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> ReadCategories();
        Category Create(Category Category);
        Category Delete(int Id);
        Category Update(Category CategoryUpdate);
        Category FindCategoryWithID(int Id);
    }
}
