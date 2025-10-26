using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services.LeaveTypes
{
    public interface ILeaveTypesService
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name);

        Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEditVM);

        Task Create(LeaveTypeCreateVM leaveTypeCreateVM);
        Task<bool> DaysExceedMaximum(int leaveTypeId, int days);
        Task Edit(LeaveTypeEditVM leaveTypeEditVM);

        Task<T?> Get<T>(int id) where T : class;

        Task<List<LeaveTypeReadonlyVM>> GetAll();

        bool LeaveTypeExists(int id);

        Task Remove(int id);
    }
}
