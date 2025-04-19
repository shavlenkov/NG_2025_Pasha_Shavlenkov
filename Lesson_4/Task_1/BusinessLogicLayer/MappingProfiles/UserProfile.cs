﻿using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserModel>();
        CreateMap<UserModel, User>();
    }
}