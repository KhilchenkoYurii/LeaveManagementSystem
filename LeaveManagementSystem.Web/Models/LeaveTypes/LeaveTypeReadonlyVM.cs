using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadonlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; } = string.Empty;

        [DisplayName("Maximum allocation of days")]
        public int Days { get; set; }
    }
}
