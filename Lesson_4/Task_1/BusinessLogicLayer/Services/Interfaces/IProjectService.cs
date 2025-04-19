using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectModel>> GetAllAsync();
    Task<ProjectModel?> GetByIdAsync(Guid id);
    Task<ProjectModel> CreateAsync(ProjectModel projectModel);
    Task<ProjectModel?> UpdateAsync(Guid id, ProjectModel projectModel);
    Task<ProjectModel?> DeleteAsync(Guid id);
}