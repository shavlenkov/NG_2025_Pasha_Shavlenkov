using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectModel>> GetAllProjects();
    Task<ProjectModel> GetProjectById(Guid id);
    Task<ProjectModel> AddProject(ProjectModel projectModel);
    Task<ProjectModel> UpdateProject(Guid id, ProjectModel projectModel);
    Task<ProjectModel> DeleteProject(Guid id);
}