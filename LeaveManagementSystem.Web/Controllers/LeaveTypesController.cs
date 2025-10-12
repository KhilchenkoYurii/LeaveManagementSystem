using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const string NameExistValidationError = "Name is already exist";

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var data = await _context.LeaveTypes.ToListAsync();

            var mappedData = _mapper.Map<List<LeaveTypeReadonlyVM>>(data);

            return View(mappedData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var mappedData = _mapper.Map<LeaveTypeReadonlyVM>(leaveType);

            return View(mappedData);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreateVM)
        {
            //Add custom validation
            if (await CheckIfLeaveTypeNameExists(leaveTypeCreateVM.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreateVM.Name), NameExistValidationError);
            }

            if (ModelState.IsValid)
            {
                var leavetype = _mapper.Map<LeaveType>(leaveTypeCreateVM);

                _context.Add(leavetype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreateVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var mappedData = _mapper.Map<LeaveTypeEditVM>(leaveType);

            return View(mappedData);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            //Add custom validation
            if (await CheckIfLeaveTypeNameExistsForEdit(leaveTypeVM))
            {
                ModelState.AddModelError(nameof(leaveTypeVM.Name), NameExistValidationError);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedData = _mapper.Map<LeaveType>(leaveTypeVM);

                    _context.Update(mappedData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveTypeVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        private async Task<bool> CheckIfLeaveTypeNameExists(string name)
        {
            return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(name.ToLower()));
        }

        private async Task<bool> CheckIfLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEditVM)
        {
            var lowerName = leaveTypeEditVM.Name.ToLower();
            return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(lowerName) 
            && !e.Id.Equals(leaveTypeEditVM.Id));
        }
    }
}
