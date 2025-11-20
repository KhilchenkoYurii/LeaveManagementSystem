namespace LeaveManagementSystem.Data
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int NumberOfDays{ get; set; }

        public List<LeaveAllocation>? LeaveAllocations { get; set; }
    }
}
