using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
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
                    DateOfBirth = new DateOnly(1970, 01, 23)
                });
        }
    }
}
