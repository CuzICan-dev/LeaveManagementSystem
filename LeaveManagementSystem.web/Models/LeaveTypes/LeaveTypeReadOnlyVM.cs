using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.web.Models.LeaveTypes;

public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
{
    [Display(Name = "Leave Type Name")]
    public string Name { get; set; } = string.Empty;
    [Display(Name = "Number of Days")]
    public int NumberOfDays { get; set; }
}