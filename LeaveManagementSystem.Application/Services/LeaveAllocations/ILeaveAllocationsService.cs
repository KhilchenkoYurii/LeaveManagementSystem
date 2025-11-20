using LeaveManagementSystem.Application.Models.LeaveAllocations;
using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Application.Services.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeeId);

        Task EditAllocation(LeaveAllocationEditVM allocationEditVM);

        Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);

        Task<LeaveAllocationEditVM> GetEmployeeAllocations(int? allocationId);

        Task<List<EmployeeListVM>> GetEmployees();

        Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId);
    }
}
