using Microsoft.EntityFrameworkCore;
using CrudMVCByKING.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING.Data;

public class UsersDbContext : IdentityDbContext<ApplicationUser>
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

    public DbSet<Users> Users { get; set; }
    public DbSet<Courses> Courses { get; set; }
    public DbSet<UserCourses> UserCourses { get; set; }
    public DbSet<Comments> Comments { get; set; }
    public DbSet<LessonExcerpt> LessonExcerpt { get; set; }
    public DbSet<Faq> Faq { get; set; }
    public DbSet<Result> Result { get; set; }
    public DbSet<Homeworks> Homeworks { get; set; }
    public DbSet<Lessons> Lessons { get; set; }
    public DbSet<Teachers> OurTeachers { get; set; }
    public DbSet<UserStep> UserStep { get; set; }
    public DbSet<Contact> Contact { get; set; }
    public DbSet<About> About { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        this.SeedUsers(modelBuilder);
        this.SeedRoles(modelBuilder);
        this.SeedUserRoles(modelBuilder);

        // Configure primary key for IdentityUserLogin
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
{
entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
});
        modelBuilder.Entity<UserCourses>()
            .HasKey(uc => new { uc.UserId, uc.CourseId });

        modelBuilder.Entity<Users>()
            .HasMany(uc => uc.Courses)
            .WithMany(u => u.Users)
        .UsingEntity<UserCourses>();

        modelBuilder.Entity<Lessons>()
        .HasOne(l => l.Course)
        .WithMany(c => c.Lessons)
        .HasForeignKey(l => l.CourseId);

        modelBuilder.Entity<Homeworks>()
       .HasOne(l => l.Lesson)
       .WithMany(c => c.Homeworks)
       .HasForeignKey(l => l.LessonId);
    }

    private void SeedUsers(ModelBuilder builder)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Admin",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            LockoutEnabled = false,
            PhoneNumber = "1234567890",
            PasswordHash = "Admin*123"

        };

        PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");  // Assign the hashed password

        builder.Entity<ApplicationUser>().HasData(user);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
            new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "HR", ConcurrencyStamp = "2", NormalizedName = "Human Resource" }
        );
    }

    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
        );
    }

    public override int SaveChanges()
    {
        // Capture audit information here and create AuditLog entries
        // Example code for capturing audit information:

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is ApplicationUser || entry.Entity is IdentityRole)
            {
                var auditLog = new AuditLog
                {
                    UserId ="dawdawdawd" ,
                    Action = entry.State.ToString(),
                    EntityName = entry.Entity.GetType().Name,
                    EntityId = "dawdawdwad",
                    TimeStamp = DateTime.Now
                };
                AuditLogs.Add(auditLog);
            }
        }

        return base.SaveChanges();
    }



}
