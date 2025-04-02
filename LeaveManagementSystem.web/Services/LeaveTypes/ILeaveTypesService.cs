using LeaveManagementSystem.web.Models.LeaveTypes;

namespace LeaveManagementSystem.web.Services.LeaveTypes;

public interface ILeaveTypesService
{
    Task<List<LeaveTypeReadOnlyVM>> GetAllAsync();
    Task<T> GetTypeByIdAsync<T>(int id) where T : class;
    Task RemoveAsync(int id);
    Task EditAsync(LeaveTypeEditVM leaveTypeEdit);
    Task CreateAsync(LeaveTypeCreateVM leaveTypeCreate);
    bool LeaveTypeExists(int id);
    Task<bool> CheckIfLeaveTypeNameExists(string name);
    Task<bool> CheckIfLeaveTypeNameExists(LeaveTypeEditVM leaveTypeEdit);
    Task<bool> DaysExceedMaximum(int leaveTypeId, int Days);
}