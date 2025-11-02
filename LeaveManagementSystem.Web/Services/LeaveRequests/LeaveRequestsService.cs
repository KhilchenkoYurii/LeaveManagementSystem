using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Models.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveAllocations;
using LeaveManagementSystem.Web.Services.Period;
using LeaveManagementSystem.Web.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveRequests
{
    public class LeaveRequestsService(IMapper _mapper, 
        ILeaveAllocationsService _leaveAllocationsService,
        ApplicationDbContext _applicationDb, 
        IPeriodService _periodService,
        IUserService _userService) : ILeaveRequestsService
    {
        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await _applicationDb.LeaveRequests.FindAsync(leaveRequestId);
            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Canceled;

            await UpdateAllocationDays(leaveRequest, false);

            await _applicationDb.SaveChangesAsync();
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM leaveRequestVM)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestVM);

            var user = await _userService.GetLoggedInUser();

            leaveRequest.EmployeeId = user.Id;

            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;

            _applicationDb.Add(leaveRequest);

            await UpdateAllocationDays(leaveRequest, true);

            await _applicationDb.SaveChangesAsync();
        }

        public async Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests()
        {
            var leaveRequests = await _applicationDb.LeaveRequests
                .Include(x => x.LeaveType)
                .ToListAsync();

            var leaveRequestsForModel = leaveRequests.Select(x => new LeaveRequestReadOnlyVM
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Id = x.Id,
                LeaveType = x.LeaveType.Name,
                LeaveRequestStatus = (LeaveRequestStatusEnum)x.LeaveRequestStatusId,
                NumberOfDays = x.EndDate.DayNumber - x.StartDate.DayNumber
            }).ToList();

            var model = new EmployeeLeaveRequestListVM
            {
                ApprovedRequests = leaveRequests.Count(x => x.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Approved),
                DeclinedRequests = leaveRequests.Count(x => x.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Declined),
                PendingRequests = leaveRequests.Count(x => x.LeaveRequestStatusId == (int)LeaveRequestStatusEnum.Pending),
                TotalRequests = leaveRequests.Count(),
                LeaveRequests = leaveRequestsForModel
            };

            return model;
        }

        public async Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests()
        {
            var user = await _userService.GetLoggedInUser();
            
            var leaveRequests = await _applicationDb.LeaveRequests
                .Include(x=> x.LeaveType)
                .Where(x => x.EmployeeId == user.Id)
                .ToListAsync();

            var model = leaveRequests.Select(x => new LeaveRequestReadOnlyVM
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Id = x.Id,
                LeaveType = x.LeaveType.Name,
                LeaveRequestStatus = (LeaveRequestStatusEnum)x.LeaveRequestStatusId,
                NumberOfDays = x.EndDate.DayNumber - x.StartDate.DayNumber,
            }).ToList();

            return model;
        }

        public async Task ReviewLeaveRequest(int leaveRequestId, bool approved)
        {
            var user = await _userService.GetLoggedInUser();

            var leaveRequest = await _applicationDb.LeaveRequests.FindAsync(leaveRequestId);

            leaveRequest.LeaveRequestStatusId = approved
                ? (int)LeaveRequestStatusEnum.Approved
                : (int)LeaveRequestStatusEnum.Declined;

            leaveRequest.ReviewerId = user.Id;

            if (!approved)
            {
                await UpdateAllocationDays(leaveRequest, false);
            }

            await _applicationDb.SaveChangesAsync();
        }

        public async Task<bool> CheckDatesExceedAllocation(LeaveRequestCreateVM leaveRequestCreateVM)
        {
            var user = await _userService.GetLoggedInUser();

            var numberOfDays = CalculateDays(leaveRequestCreateVM.StartDate, leaveRequestCreateVM.EndDate);

            var period = await _periodService.GetCurrentPeriod();

            var allocation = await _applicationDb.LeaveAllocations
                .FirstAsync(x => x.LeaveTypeId == leaveRequestCreateVM.LeaveTypeId 
                && x.EmployeeId == user.Id
                && x.PeriodId == period.Id);

            return allocation.Days < numberOfDays;
        }

        public async Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id)
        {
            var leaveRequests = await _applicationDb.LeaveRequests
                .Include(x => x.LeaveType)
                .FirstAsync(x => x.Id == id);

            var user = await _userService.GetUserbyId(leaveRequests.EmployeeId);

            var model = new ReviewLeaveRequestVM
            {
                StartDate = leaveRequests.StartDate,
                EndDate = leaveRequests.EndDate,
                NumberOfDays = leaveRequests.EndDate.DayNumber - leaveRequests.StartDate.DayNumber,
                LeaveRequestStatus = (LeaveRequestStatusEnum)leaveRequests.LeaveRequestStatusId,
                Id = leaveRequests.Id,
                LeaveType = leaveRequests.LeaveType.Name,
                RequestComments = leaveRequests.RequestComments,
                Employee = new EmployeeListVM
                {
                    Id = leaveRequests.EmployeeId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }
            };

            return model;
        }

        private async Task UpdateAllocationDays(LeaveRequest leaveRequest, bool deductDays)
        {
            var allocation = await _leaveAllocationsService.GetCurrentAllocation(leaveRequest.LeaveTypeId, leaveRequest.EmployeeId);

            var numberOfDays = CalculateDays(leaveRequest.StartDate, leaveRequest.EndDate);

            if (deductDays)
            {
                allocation.Days -= numberOfDays;
            }
            else
            {
                allocation.Days += numberOfDays;
            }

            _applicationDb.Entry(allocation).State = EntityState.Modified;
        }

        private int CalculateDays(DateOnly startDate, DateOnly endDate)
        {
            return endDate.DayNumber - startDate.DayNumber;
        }
    }
}
