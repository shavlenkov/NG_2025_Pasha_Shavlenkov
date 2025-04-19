using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryModel>> GetAllAsync();
    Task<CategoryModel?> GetByIdAsync(Guid id);
    Task<CategoryModel> CreateAsync(CategoryModel categoryModel);
    Task<CategoryModel?> UpdateAsync(Guid id, CategoryModel categoryModel);
    Task<CategoryModel?> DeleteAsync(Guid id);
}