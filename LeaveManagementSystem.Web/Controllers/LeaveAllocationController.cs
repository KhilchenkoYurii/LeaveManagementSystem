using LeaveManagementSystem.Application.Models.LeaveAllocations;
using LeaveManagementSystem.Application.Services.LeaveAllocations;
using LeaveManagementSystem.Application.Services.LeaveTypes;
using LeaveManagementSystem.Common.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationsService,
        ILeaveTypesService _leaveTypesService) : Controller
    {
        [Authorize(Roles = Roles.AdminRoleName)]
        public async Task<IActionResult> Index()
        {
            var leaveAllocationVM = await _leaveAllocationsService.GetEmployees();

            return View(leaveAllocationVM);
        }

        [Authorize(Roles = Roles.AdminRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(string? id)
        {
            await _leaveAllocationsService.AllocateLeave(id);

            return RedirectToAction(nameof(Details), new { userId = id });
        }

        public async Task<IActionResult> EditAllocation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocations = await _leaveAllocationsService.GetEmployeeAllocations(id.Value);

            if (allocations == null)
            {
                return NotFound();
            }

            return View(allocations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocationEditVM)
        {
            if (await _leaveTypesService.DaysExceedMaximum(allocationEditVM.LeaveType.Id, allocationEditVM.Days))
            {
                ModelState.AddModelError("Days", "Allocation exceeds the maximum leave type value!");
            }

            if (ModelState.IsValid)
            {
                await _leaveAllocationsService.EditAllocation(allocationEditVM);

                return RedirectToAction(nameof(Details), new { userId = allocationEditVM.Employee.Id });
            }

            var days = allocationEditVM.Days;

            var allocations = await _leaveAllocationsService.GetEmployeeAllocations(allocationEditVM.Id);

            allocations.Days = days;

            return View(allocations);
        }

        public async Task<IActionResult> Details(string? userId)
        {
            var leaveAllocationVM = await _leaveAllocationsService.GetEmployeeAllocations(userId);

            return View(leaveAllocationVM);
        }
    }
}
