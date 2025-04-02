using LeaveManagementSystem.web.Common;
using LeaveManagementSystem.web.Services.LeaveAllocations;
using LeaveManagementSystem.web.Services.LeaveTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.web.Controllers
{
    [Authorize]
    public class LeaveAllocationController(ILeaveAllocationsService leaveAllocationsService, ILeaveTypesService leaveTypesService) : Controller
    {
        private readonly ILeaveAllocationsService _leaveAllocationsService = leaveAllocationsService;
        private readonly ILeaveTypesService _leaveTypesService = leaveTypesService;

        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var employeeVm = await _leaveAllocationsService.GetEmployees();
            return View(employeeVm);
        }
        
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(string? Id)
        {
            await _leaveAllocationsService.AllocateLeaveAsync(Id);
            return RedirectToAction(nameof(Details), new { userId = Id });
        }

        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> EditAllocation(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var allocation = await _leaveAllocationsService.GetEmployeeAllocationAsync(id.Value);
            if(allocation == null)
            {
                return NotFound();
            }
            return View(allocation);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocation)
        {
            if (await _leaveTypesService.DaysExceedMaximum(allocation.LeaveType.Id, allocation.Days))
            {
                ModelState.AddModelError("Days", "The number of days exceeds the maximum allowed for this leave type.");
            }

            if (ModelState.IsValid)
            {
                await _leaveAllocationsService.EditAllocation(allocation);
                return RedirectToAction(nameof(Details), new { userId = allocation.Employee.Id});
            }
            
            var days = allocation.Days;
            var reloadAllocation = await _leaveAllocationsService.GetEmployeeAllocationAsync(allocation.Id);
            reloadAllocation.Days = days;
            
            return View(allocation);
        }
        
        public async Task<IActionResult> Details(string? userId)
        {
            var employeeVm = await _leaveAllocationsService.GetEmployeeAllocationsAsync(userId);
            return View(employeeVm);
        }

    }
}
