using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.DatabaseContext;

namespace DataAccessLayer.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(CrowdfundingDbContext context) : base(context)
    {
    }
}