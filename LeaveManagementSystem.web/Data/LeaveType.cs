using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.web.Data;

public class LeaveType : BaseEntity
{
    [StringLength(150)]
    public string Name { get; set; }
    public int NumberOfDays { get; set; }

    public List<LeaveAllocation>? LeaveAllocations { get; set; }
}