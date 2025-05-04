using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.DatabaseContext;

namespace DataAccessLayer.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(CrowdfundingDbContext context) : base(context)
    {
    }
}