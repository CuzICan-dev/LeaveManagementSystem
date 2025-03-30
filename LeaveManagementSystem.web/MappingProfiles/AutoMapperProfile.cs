using AutoMapper;
using LeaveManagementSystem.web.Data;
using LeaveManagementSystem.web.Models.LeaveTypes;

namespace LeaveManagementSystem.web.MappingProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
        //.ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays));
        CreateMap<LeaveTypeCreateVM, LeaveType>();
        CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();
    }
}