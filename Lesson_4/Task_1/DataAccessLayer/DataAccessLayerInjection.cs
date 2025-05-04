using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DataAccessLayer.DatabaseContext;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer;

public static class DataAccessLayerInjection
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CrowdfundingDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
        });
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IVoteRepository, VoteRepository>();
    }
}