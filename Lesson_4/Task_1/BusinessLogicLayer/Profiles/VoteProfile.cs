using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Models;

namespace BusinessLogicLayer.Profiles;

public class VoteProfile : Profile
{
    public VoteProfile()
    {
        CreateMap<Vote, VoteModel>();
        CreateMap<VoteModel, Vote>();
    }
}