﻿
using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _applicationDb, IHttpContextAccessor 
        _httpContextAccessor, UserManager<ApplicationUser> _userManager, IMapper _mapper) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            var leaveTypes = await _applicationDb.LeaveTypes
                .Where(x => !x.LeaveAllocations.Any(q => q.EmployeeId == employeeId))
                .ToListAsync();

            var currentDate = DateTime.Now;

            var period = await _applicationDb.Periods.SingleAsync(x=> x.EndDate.Year == currentDate.Year);

            var monthsRemaining = period.EndDate.Month - currentDate.Month;

            foreach (var leaveType in leaveTypes)
            {
                //works but not good practice
                //var allocationExists = await IsAllocationExist(employeeId, period.Id, leaveType.Id);
                //if (allocationExists)
                //{
                //    continue;
                //}

                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);

                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
                };

                _applicationDb.Add(leaveAllocation);
            }

            await _applicationDb.SaveChangesAsync();

        }

        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {
            string employeeId = string.Empty;
            if (!string.IsNullOrEmpty(userId))
            {
                employeeId = userId;
            }
            else
            {
                var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
                employeeId = user?.Id;
            }


            var currentDate = DateTime.Now;

            var leaveAllocations = await _applicationDb.LeaveAllocations
                .Include(x=> x.LeaveType)
                .Include(x=> x.Period)
                .Where(x => x.EmployeeId == employeeId && x.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId)
                ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User)
                : await _userManager.FindByIdAsync(userId);

            var allocations = await GetAllocations(userId);

            var allocationsVmList = _mapper.Map<List<LeaveAllocation>,List<LeaveAllocationVM>>(allocations);

            var leaveTypesCount = await _applicationDb.LeaveTypes.CountAsync();

            var employeeVm = new EmployeeAllocationVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationsVmList,
                IsCompleatedAllocation = leaveTypesCount == allocations.Count ? true : false,
            };
            return employeeVm;
        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(GlobalConsts.EmployeeRoleName);

            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());

            return employees;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocations(int? allocationId)
        {
            var allocations = await _applicationDb.LeaveAllocations
                .Include(x=>x.LeaveType)
                .Include(x=>x.Employee)
                .FirstOrDefaultAsync(x=>x.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocations);

            return model;
        }

        public async Task EditAllocation(LeaveAllocationEditVM allocationEditVM)
        {
            //var allocations = await GetEmployeeAllocations(allocationEditVM.Id);

            //if(allocations == null)
            //{
            //    throw new Exception("Leave allocation record doesn't exist");
            //}

            //allocations.Days = allocationEditVM.Days;

            // option 1 _applicationDb.Update(allocations);
            // option 2_applicationDb.Entry(allocations).State = EntityState.Modified;
            // option 3 await _applicationDb.SaveChangesAsync();

            await _applicationDb.LeaveAllocations
                .Where(x => x.Id ==  allocationEditVM.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(x=>x.Days, allocationEditVM.Days));
        }

        //public async Task<bool> IsAllocationExist(string? userId, int periodId, int leaveTypeId)
        //{
        //    var exists = await _applicationDb.LeaveAllocations.AnyAsync(x =>
        //    x.EmployeeId ==  userId 
        //    && x.PeriodId == periodId 
        //    && x.LeaveTypeId == leaveTypeId
        //    );

        //    return exists;
        //}
    }
}
