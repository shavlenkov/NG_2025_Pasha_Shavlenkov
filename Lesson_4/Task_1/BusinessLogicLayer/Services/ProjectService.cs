using AutoMapper;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    
    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProjectModel>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<ProjectModel>>(projects);
    }
    
    public async Task<ProjectModel?> GetByIdAsync(Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        
        if (project == null)
        {
            return null;
        }
        
        return _mapper.Map<ProjectModel>(project);
    }
    
    public async Task<ProjectModel> CreateAsync(ProjectModel projectModel)
    {
        var createdProject = await _projectRepository.AddAsync(_mapper.Map<Project>(projectModel));
        
        return _mapper.Map<ProjectModel>(createdProject);
    }
    
    public async Task<ProjectModel?> UpdateAsync(Guid id, ProjectModel projectModel)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project == null)
        {
            return null;
        }

        project.Name = projectModel.Name;
        project.Description = projectModel.Description;
        project.CreatorId = projectModel.CreatorId;
        project.CategoryId = projectModel.CategoryId;

        var updatedProject = await _projectRepository.UpdateAsync(project);

        return _mapper.Map<ProjectModel>(updatedProject);
    }

    public async Task<ProjectModel?> DeleteAsync(Guid id)
    { 
        var project = await _projectRepository.GetByIdAsync(id);
        
        if (project == null)
        {
            return null;
        }
        
        var deletedProject = await _projectRepository.DeleteAsync(project);
        
        return _mapper.Map<ProjectModel>(deletedProject);
    }
}