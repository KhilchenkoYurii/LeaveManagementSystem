using LeaveManagementSystem.Common.Static;
using LeaveManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.Application.Services.User
{
    public class UserService(UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor) : IUserService
    {
        public async Task<List<ApplicationUser>> GetEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.EmployeeRoleName);

            return employees.ToList();
        }

        public async Task<ApplicationUser> GetLoggedInUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);

            return user;
        }

        public async Task<ApplicationUser> GetUserbyId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }
    }
}
