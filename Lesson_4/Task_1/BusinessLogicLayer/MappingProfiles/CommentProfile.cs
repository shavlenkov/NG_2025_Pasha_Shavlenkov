using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.MappingProfiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Category, CategoryModel>();
        CreateMap<CategoryModel, Category>();
    }
}