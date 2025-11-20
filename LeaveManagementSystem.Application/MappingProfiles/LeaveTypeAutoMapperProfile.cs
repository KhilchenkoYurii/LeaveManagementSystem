using AutoMapper;
using LeaveManagementSystem.Application.Models.LeaveTypes;
using LeaveManagementSystem.Data;

namespace LeaveManagementSystem.Application.MappingProfiles
{
    public class LeaveTypeAutoMapperProfile : Profile
    {
        public LeaveTypeAutoMapperProfile()
        {
            CreateMap<LeaveType, LeaveTypeReadonlyVM>()
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays) );

            CreateMap<LeaveTypeCreateVM, LeaveType>()
               .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Days));

            CreateMap<LeaveTypeEditVM, LeaveType>()
                .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Days));

            CreateMap<LeaveType, LeaveTypeEditVM>()
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
        }
    }
}
