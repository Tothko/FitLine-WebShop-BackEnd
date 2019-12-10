using Entities;
using System.Collections.Generic;

namespace AppCore.Appliaction_Services_Impl
{
    public interface ICategoryService
    {
        IEnumerable<Category> ReadCategories();
        Category Create(Category Category);
        Category Delete(int Id);
        Category Update(Category CategoryUpdate);
        Category FindCategoryWithID(int Id);
    }
}