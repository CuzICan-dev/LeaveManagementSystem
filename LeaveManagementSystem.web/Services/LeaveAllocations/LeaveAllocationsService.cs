using AutoMapper;
using LeaveManagementSystem.web.Common;
using LeaveManagementSystem.web.Models.LeaveAllocations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.web.Services.LeaveAllocations;

public class LeaveAllocationsService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, 
    UserManager<ApplicationUser> userManager, IMapper mapper) : ILeaveAllocationsService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IMapper _mapper = mapper;

    public async Task AllocateLeaveAsync(string employeeId)
    {
        //get all leave types
        var leaveTypes = await _context.LeaveTypes
            .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
            .ToListAsync();
        
        //get the current period based on the current year
        var currentDate = DateTime.Now;
        var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
        var monthsRemaining = period.EndDate.Month - currentDate.Month;
        
        //foreach lave type, create an allocation entry
        foreach (var leaveType in leaveTypes)
        {
            //works but not best practice
            // var allocationExists = await AllocationExists(employeeId, period.Id, leaveType.Id);
            // if (allocationExists)
            // {
            //     continue;
            // }
            var accrualRate = decimal.Divide(leaveType.NumberOfDays, 12);
            var leaveAllocation = new LeaveAllocation
            {
                EmployeeId = employeeId,
                LeaveTypeId = leaveType.Id,
                PeriodId = period.Id,
                Days = (int)Math.Ceiling(accrualRate * monthsRemaining)
            };
            
            _context.Add(leaveAllocation);
            await _context.SaveChangesAsync();
        }
        
        await _context.SaveChangesAsync();
    }
    
    public async Task<EmployeeAllocationVM> GetEmployeeAllocationsAsync(string? userId)
    {
        var user = string.IsNullOrWhiteSpace(userId) 
            ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User) 
            : await _userManager.FindByIdAsync(userId);
        
        var allocations = await GetAllAllocationsAsync(user.Id);
        var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
        var leaveTypesCount = await _context.LeaveTypes.CountAsync();
        
        var employeeVM = new EmployeeAllocationVM
        {
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            LeaveAllocations = allocationVmList,
            IsCompletedAllocation = leaveTypesCount == allocationVmList.Count,
        };
        
        return employeeVM;
    }

    public async Task<LeaveAllocationEditVM> GetEmployeeAllocationAsync(int AllocationId)
    {
        var allocation = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Employee)
            .FirstOrDefaultAsync(q => q.Id == AllocationId);
        
        var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
        return model;
    }

    public async Task<List<EmployeeListVM>> GetEmployees()
    {
        var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
        var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());
        
        return employees;
    }

    public async Task EditAllocation(LeaveAllocationEditVM allocationEditVm)
    {
        //part of option 1 and option 2
        // var leaveAllocation = await GetEmployeeAllocationAsync(allocationEditVm.Id);
        // if (leaveAllocation == null)
        // {
        //     throw new Exception("Leave allocation record not found");
        // }
        // leaveAllocation.Days = allocationEditVm.Days;
        
        //update all the fields even if they are not changed
        //option 1-  _context.Update(leaveAllocation);
        
        //update only the fields that are changed only
        //option 2- _context.Entry(leaveAllocation).State = EntityState.Modified;
        //await _context.SaveChangesAsync();
        
        //option 3
        await _context.LeaveAllocations
            .Where(q => q.Id == allocationEditVm.Id)
            .ExecuteUpdateAsync(s => s.SetProperty(e=> e.Days, allocationEditVm.Days));
    }

    private async Task<List<LeaveAllocation>> GetAllAllocationsAsync(string? userId)
    {
        var currentDate = DateTime.Now;
        var leaveAllocations = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Period)
            .Where(q => q.EmployeeId == userId && q.Period.EndDate.Year == currentDate.Year).ToListAsync();
        
        return leaveAllocations;
    }
    
    private async Task<bool> AllocationExists(string userId, int periodId, int leaveTypeId)
    {
       var exists = await _context.LeaveAllocations.AnyAsync(q => 
           q.EmployeeId == userId 
           && q.LeaveTypeId == leaveTypeId 
           && q.PeriodId == periodId
           );
       
         return exists;
    }
}