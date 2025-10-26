using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Models.Period;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }

        [Display(Name = "Number of days")]
        public int Days { get; set; }

        [Display(Name = "Allocation period")]
        public PeriodVM Period { get; set; } = new PeriodVM();

        public LeaveTypeReadonlyVM LeaveType { get; set; } = new LeaveTypeReadonlyVM();
    }
}
