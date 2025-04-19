using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryModel>();
        CreateMap<CategoryModel, Category>();
    }
}