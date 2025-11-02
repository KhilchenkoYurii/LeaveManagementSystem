
namespace LeaveManagementSystem.Web.Services.User
{
    public interface IUserService
    {
        Task<ApplicationUser> GetLoggedInUser();

        Task<ApplicationUser> GetUserbyId(string userId);

        Task<List<ApplicationUser>> GetEmployees();
    }
}