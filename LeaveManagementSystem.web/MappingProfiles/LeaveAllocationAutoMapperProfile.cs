using AutoMapper;
using LeaveManagementSystem.web.Models.LeaveAllocations;
using LeaveManagementSystem.web.Models.LeaveTypes;
using LeaveManagementSystem.web.Models.Period;

namespace LeaveManagementSystem.web.MappingProfiles;

public class LeaveAllocationAutoMapperProfile : Profile
{
    public LeaveAllocationAutoMapperProfile()
    {
        CreateMap<LeaveAllocation, LeaveAllocationVM>();
        CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
        CreateMap<ApplicationUser, EmployeeListVM>();
        CreateMap<Period, PeriodVM>();
    }
}