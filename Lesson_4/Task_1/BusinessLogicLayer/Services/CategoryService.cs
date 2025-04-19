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
    
    public async Task<IEnumerable<CategoryModel>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<CategoryModel>>(categories);
    }
    
    public async Task<CategoryModel?> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        
        return category == null ? null : _mapper.Map<CategoryModel>(category);
    }
    
    public async Task<CategoryModel> CreateAsync(CategoryModel categoryModel)
    {
        var category = _mapper.Map<Category>(categoryModel);
        
        var createdCategory = await _categoryRepository.AddAsync(category);
        
        return _mapper.Map<CategoryModel>(createdCategory);
    }
    
    public async Task<CategoryModel?> UpdateAsync(Guid id, CategoryModel categoryModel)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
        {
            return null;
        }
        
        category.Description = categoryModel.Description;
        
        var updatedCategory = await _categoryRepository.UpdateAsync(category);

        return _mapper.Map<CategoryModel>(updatedCategory);
    }

    public async Task<CategoryModel?> DeleteAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
        {
            return null;
        }
        
        var deletedCategory = await _categoryRepository.DeleteAsync(category);

        return _mapper.Map<CategoryModel>(deletedCategory);
    }
}