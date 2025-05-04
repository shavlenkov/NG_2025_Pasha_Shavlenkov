using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.Profiles;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer;

public static class BusinessLogicLayerInjection
{
    public static void AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        services.AddAutoMapper(typeof(CategoryProfile));
        services.AddAutoMapper(typeof(ProjectProfile));
        services.AddAutoMapper(typeof(CommentProfile));
        services.AddAutoMapper(typeof(VoteProfile));
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IVoteService, VoteService>();
    }
}