using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.Period
{
    public class PeriodService(ApplicationDbContext _applicationDbContext) : IPeriodService
    {
        public async Task<Data.Period> GetCurrentPeriod()
        {
            var currentDate = DateTime.Now;

            var period = await _applicationDbContext.Periods.SingleAsync(x => x.EndDate.Year == currentDate.Year);

            return period;
        }
    }
}
