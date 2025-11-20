using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveRequests
{
    public class EmployeeLeaveRequestListVM
    {
        [DisplayName("Total number of requests")]
        public int TotalRequests { get; set; }

        [DisplayName("Approved requests")]
        public int ApprovedRequests { get; set; }

        [DisplayName("Pending requests")]
        public int PendingRequests { get; set; }

        [DisplayName("Declined requests")]
        public int DeclinedRequests { get; set; }

        public List<LeaveRequestReadOnlyVM> LeaveRequests { get; set; } = [];
    }
}