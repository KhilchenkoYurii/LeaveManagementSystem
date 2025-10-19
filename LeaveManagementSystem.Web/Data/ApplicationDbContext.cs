using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<LeaveType> LeaveTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { 
                    Id = "cba8f906-e6f4-42d1-93fd-68d27cdfb718",
                    Name = GlobalConsts.EmployeeRoleName,
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "73697ef3-8b7e-40df-a508-a284d2164bfd",
                    Name = GlobalConsts.SupervisorRoleName,
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "167bfeee-7c2c-42b2-9892-75288de99daf",
                    Name = GlobalConsts.AdminRoleName,
                    NormalizedName = "ADMINISTRATOR"
                });

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "a9193084-ff28-4cb2-be55-f0310bad461c",
                    Email = "admin@localhos.com",
                    NormalizedEmail = "admin@localhos.com".ToUpper(),
                    NormalizedUserName = "admin@localhos.com".ToUpper(),
                    UserName = "admin@localhos.com",
                    PasswordHash = hasher.HashPassword(null, "Admin12345!"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1970,01,23)
                });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "167bfeee-7c2c-42b2-9892-75288de99daf",
                UserId = "a9193084-ff28-4cb2-be55-f0310bad461c"
            });

        }
    }
}
