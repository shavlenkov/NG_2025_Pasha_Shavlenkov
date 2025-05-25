using AutoMapper;
using DAL_Core.Entities;
using VendorBLL.Models;

namespace VendorBLL.Profiles;

public class VendorProfile : Profile
{
    public VendorProfile()
    {
        CreateMap<Vendor, VendorDto>();
        CreateMap<VendorDto, Vendor>();
    }
}