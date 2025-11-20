using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Application.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Application.Services.LeaveTypes
{
    public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
    {
        public async Task<List<LeaveTypeReadonlyVM>> GetAll()
        {
            var data = await _context.LeaveTypes.ToListAsync();

            var mappedData = _mapper.Map<List<LeaveTypeReadonlyVM>>(data);

            return mappedData;
        }

        public async Task<T?> Get<T>(int id)where T : class
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(e => e.Id.Equals(id));

            if(data == null)
            {
                return null;
            }

            var viewData = _mapper.Map<T>(data);

            return viewData;
        }

        public async Task Remove(int id)
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(e => e.Id.Equals(id));

            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Edit(LeaveTypeEditVM leaveTypeEditVM)
        {
            var mappedData = _mapper.Map<LeaveType>(leaveTypeEditVM);

            _context.Update(mappedData);
            await _context.SaveChangesAsync();
        }

        public async Task Create(LeaveTypeCreateVM leaveTypeCreateVM)
        {
            var leavetype = _mapper.Map<LeaveType>(leaveTypeCreateVM);

            _context.Add(leavetype);
            await _context.SaveChangesAsync();
        }

        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        public async Task<bool> CheckIfLeaveTypeNameExists(string name)
        {
            return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(name.ToLower()));
        }

        public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEditVM)
        {
            var lowerName = leaveTypeEditVM.Name.ToLower();
            return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(lowerName)
            && !e.Id.Equals(leaveTypeEditVM.Id));
        }

        public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);

            return leaveType.NumberOfDays < days;
        }
    }
}
