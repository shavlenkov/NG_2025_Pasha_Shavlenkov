using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryModel>> GetAllCategories();
    Task<CategoryModel> GetCategoryById(Guid id);
    Task<CategoryModel> AddCategory(CategoryModel categoryModel);
    Task<CategoryModel> UpdateCategory(Guid id, CategoryModel categoryModel);
    Task<CategoryModel> DeleteCategory(Guid id);
}