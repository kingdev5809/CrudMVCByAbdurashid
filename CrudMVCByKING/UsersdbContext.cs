using Microsoft.EntityFrameworkCore;
using CrudMVCByKING.Models;
using CrudMVCByKING.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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

}
