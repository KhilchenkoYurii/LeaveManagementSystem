using LeaveManagementSystem.Common.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "cba8f906-e6f4-42d1-93fd-68d27cdfb718",
                    Name = Roles.EmployeeRoleName,
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "73697ef3-8b7e-40df-a508-a284d2164bfd",
                    Name = Roles.SupervisorRoleName,
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "167bfeee-7c2c-42b2-9892-75288de99daf",
                    Name = Roles.AdminRoleName,
                    NormalizedName = "ADMINISTRATOR"
                });
        }
    }
}
