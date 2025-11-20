using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Application.Models.LeaveTypes
{
    public class LeaveTypeEditVM : BaseLeaveTypeVM
    {
        [Required]
        [Length(4, 64, ErrorMessage = "Broke Length rule!")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 99)]
        [DisplayName("Maximum allocation of days")]
        public int Days { get; set; }
    }
}
