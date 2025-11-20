using LeaveManagementSystem.Application.Models.LeaveRequests;

namespace LeaveManagementSystem.Application.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM leaveRequestVM);
        Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests();
        
        Task <EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests();

        Task CancelLeaveRequest(int leaveRequestId);

        Task ReviewLeaveRequest(int leaveRequestId, bool approved);

        Task<bool> CheckDatesExceedAllocation(LeaveRequestCreateVM leaveRequestCreateVM);

        Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);
    }
}
