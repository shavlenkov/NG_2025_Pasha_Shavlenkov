using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public ProjectService(
        IProjectRepository projectRepository, 
        IUserRepository userRepository, 
        ICategoryRepository categoryRepository, 
        IMapper mapper)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProjectModel>> GetAllProjects()
    {
        var projects = await _projectRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<ProjectModel>>(projects);
    }
    
    public async Task<ProjectModel> GetProjectById(Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        
        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id '{id}' was not found");
        }
        
        return _mapper.Map<ProjectModel>(project);
    }
    
    public async Task<ProjectModel> AddProject(ProjectModel projectModel)
    {
        if (await _userRepository.GetByIdAsync(projectModel.CreatorId) == null)
        {
            throw new InvalidOperationException($"User with id '{projectModel.CreatorId}' does not exist");
        }
        
        if (await _categoryRepository.GetByIdAsync(projectModel.CategoryId) == null)
        {
            throw new InvalidOperationException($"Category with id '{projectModel.CategoryId}' does not exist");
        }
        
        var project = _mapper.Map<Project>(projectModel);
        
        var addedProject = await _projectRepository.AddAsync(project);
        
        return _mapper.Map<ProjectModel>(addedProject);
    }
    
    public async Task<ProjectModel> UpdateProject(Guid id, ProjectModel projectModel)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        
        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id '{id}' was not found");
        }
        
        if (await _userRepository.GetByIdAsync(projectModel.CreatorId) == null)
        {
            throw new InvalidOperationException($"User with id '{projectModel.CreatorId}' does not exist");
        }
        
        if (await _projectRepository.GetByIdAsync(projectModel.CategoryId) == null)
        {
            throw new InvalidOperationException($"Category with id '{projectModel.CategoryId}' does not exist");
        }
        
        project.Name = projectModel.Name;
        project.Description = projectModel.Description;
        project.CreatorId = projectModel.CreatorId;
        project.CategoryId = projectModel.CategoryId;
        
        var updatedProject = await _projectRepository.UpdateAsync(project);
        
        return _mapper.Map<ProjectModel>(updatedProject);
    }
    
    public async Task<ProjectModel> DeleteProject(Guid id)
    { 
        var project = await _projectRepository.GetByIdAsync(id);
        
        if (project == null)
        {
            throw new KeyNotFoundException($"Project with id '{id}' was not found");
        }
        
        var deletedProject = await _projectRepository.DeleteAsync(project);
        
        return _mapper.Map<ProjectModel>(deletedProject);
    }
}