using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required]
        [Length(4,64, ErrorMessage = "Broke Length rule!")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1,99)]
        [DisplayName("Maximum allocation of days")]
        public int Days { get; set; }
    }
}
