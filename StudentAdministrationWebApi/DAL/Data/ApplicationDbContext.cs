using StudentAdministrationWebApi.DAL;
using Microsoft.EntityFrameworkCore;
using StudentAdministrationWebApi.DAL.Models;

namespace StudentAdministrationWebApi.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        //public DbSet<Grade> Grades { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Student>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });

            builder.Entity<Teacher>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });

            builder.Entity<Course>(
                entity => 
                {
                    entity.HasKey(e => e.Id);
                });
            builder.Entity<CourseStudent>(
                entity =>
                {
                    entity.HasKey(cs => new { cs.CourseId, cs.StudentId });
                    entity.HasOne(cs => cs.Course).WithMany(c => c.CourseStudents).HasForeignKey(cs => cs.CourseId);
                    entity.HasOne(cs => cs.Student).WithMany(s => s.StudentCourses).HasForeignKey(cs => cs.StudentId);
                });
            builder.Entity<CourseTeacher>(
                entity =>
                {
                    entity.HasKey(cs => new { cs.CourseId, cs.TeacherId });
                    entity.HasOne(cs => cs.Course).WithMany(c => c.CourseTeachers).HasForeignKey(cs => cs.CourseId);
                    entity.HasOne(cs => cs.Teacher).WithMany(t => t.TeacherCourses).HasForeignKey(cs => cs.TeacherId);
                });
            builder.Entity<School>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasMany<Course>(e => e.Courses).WithOne(c => c.School).HasForeignKey(c => c.SchoolId);
                });
        }
    }
}
