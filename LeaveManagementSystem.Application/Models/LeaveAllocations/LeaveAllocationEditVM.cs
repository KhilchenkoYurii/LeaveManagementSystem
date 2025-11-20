using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Application.Models.LeaveAllocations
{
    public class LeaveAllocationEditVM : LeaveAllocation
    {
        public EmployeeListVM? Employee { get; set; }
    }
}
