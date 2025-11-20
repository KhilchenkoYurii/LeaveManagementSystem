using LeaveManagementSystem.Application.Services.LeaveRequests;
using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveRequests
{
    public class LeaveRequestReadOnlyVM
    {
        public int Id { get; set; }

        [DisplayName("Start Date")]
        public DateOnly StartDate { get; set; }

        [DisplayName("End Date")]
        public DateOnly EndDate { get; set; }

        [DisplayName("Total days")]
        public int NumberOfDays { get; set; }

        [DisplayName("Leave type")]
        public string LeaveType { get; set; } = string.Empty;

        [DisplayName("Status")]
        public LeaveRequestStatusEnum LeaveRequestStatus { get; set; }
    }
}
