using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CategoryModel>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<CategoryModel>>(categories);
    }
    
    public async Task<CategoryModel> GetCategoryById(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        
        if (category == null)
        {
            throw new KeyNotFoundException($"Category with id '{id}' was not found");
        }
        
        return _mapper.Map<CategoryModel>(category);
    }
    
    public async Task<CategoryModel> AddCategory(CategoryModel categoryModel)
    {
        var category = _mapper.Map<Category>(categoryModel);
        
        var addedCategory = await _categoryRepository.AddAsync(category);
        
        return _mapper.Map<CategoryModel>(addedCategory);
    }
    
    public async Task<CategoryModel> UpdateCategory(Guid id, CategoryModel categoryModel)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        
        if (category == null)
        {
            throw new KeyNotFoundException($"Category with id '{id}' was not found");
        }
        
        category.Description = categoryModel.Description;
        
        var updatedCategory = await _categoryRepository.UpdateAsync(category);
        
        return _mapper.Map<CategoryModel>(updatedCategory);
    }
    
    public async Task<CategoryModel> DeleteCategory(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        
        if (category == null)
        {
            throw new KeyNotFoundException($"Category with id '{id}' was not found");
        }
        
        var deletedCategory = await _categoryRepository.DeleteAsync(category);
        
        return _mapper.Map<CategoryModel>(deletedCategory);
    }
}