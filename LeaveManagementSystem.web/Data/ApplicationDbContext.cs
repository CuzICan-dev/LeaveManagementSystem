using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "4fdeb75e-cbdd-4cb3-871d-4d0cee998c67",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            }, 
            new IdentityRole
            {
                Id = "270edc1f-8185-4d77-9484-04c3dafbadca",
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR"
            }, 
            new IdentityRole
            {
                Id = "a83295f2-0168-44a4-8e78-ceeb026422bf",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );

        var hasher = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "8603bdef-45d6-492d-9572-fcd6ba28b315",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true,
                FirstName = "Default",
                LastName = "Admin",
                DateOfBirth = new DateOnly(1992, 06, 21)
            });
        
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "a83295f2-0168-44a4-8e78-ceeb026422bf",
                UserId = "8603bdef-45d6-492d-9572-fcd6ba28b315"
            });
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
}