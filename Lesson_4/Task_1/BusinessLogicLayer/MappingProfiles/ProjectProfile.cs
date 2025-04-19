using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.MappingProfiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectModel>();
        CreateMap<ProjectModel, Project>();
    }
}