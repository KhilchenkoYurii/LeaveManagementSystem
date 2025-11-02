namespace LeaveManagementSystem.Web.Services.Period
{
    public interface IPeriodService
    {
        Task<Data.Period> GetCurrentPeriod();
    }
}
