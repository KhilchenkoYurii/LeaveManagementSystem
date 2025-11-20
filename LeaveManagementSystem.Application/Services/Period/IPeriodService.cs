namespace LeaveManagementSystem.Application.Services.Period
{
    public interface IPeriodService
    {
        Task<Data.Period> GetCurrentPeriod();
    }
}
