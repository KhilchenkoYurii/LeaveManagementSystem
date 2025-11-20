using AutoMapper;
using LeaveManagementSystem.Application.Services.LeaveRequests;
using LeaveManagementSystem.Data;

public class LeaveRequestAutoMapperProfile : Profile
{
    public LeaveRequestAutoMapperProfile()
    {
        CreateMap<LeaveRequestCreateVM, LeaveRequest>();

    }
}
