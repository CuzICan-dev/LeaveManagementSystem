using LeaveManagementSystem.web.Models.LeaveAllocations;

namespace LeaveManagementSystem.web.Services.LeaveAllocations;

public interface ILeaveAllocationsService
{
    Task AllocateLeaveAsync(string employeeId);
    Task<EmployeeAllocationVM> GetEmployeeAllocationsAsync(string? userId);
    Task<LeaveAllocationEditVM> GetEmployeeAllocationAsync(int AllocationId);
    Task<List<EmployeeListVM>> GetEmployees();
    Task EditAllocation(LeaveAllocationEditVM allocationEditVm);
}