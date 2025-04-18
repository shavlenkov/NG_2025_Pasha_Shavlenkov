﻿using Microsoft.Extensions.DependencyInjection;
using BusinessLogicLayer.MappingProfiles;
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
        
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IVoteService, VoteService>();
    }
}