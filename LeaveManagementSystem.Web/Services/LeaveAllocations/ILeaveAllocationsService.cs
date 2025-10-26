using LeaveManagementSystem.Web.Models.LeaveAllocations;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);
        Task EditAllocation(LeaveAllocationEditVM allocationEditVM);
        Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);

        Task<LeaveAllocationEditVM> GetEmployeeAllocations(int? allocationId);

        Task<List<EmployeeListVM>> GetEmployees();
    }
}
