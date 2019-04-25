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
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<DataObject> DataObjects { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
                    entity.HasMany<Lesson>(e => e.Lessons).WithOne(e => e.Course).HasForeignKey(e => e.CourseId);
                    entity.HasMany<DataObject>(e => e.DataObjects);
                    
                });
            builder.Entity<CourseStudent>(
                entity =>
                {
                    entity.HasKey(cs => new { cs.CourseId, cs.StudentId });
                    entity.HasOne<Course>(cs => cs.Course).WithMany(c => c.CourseStudents).HasForeignKey(cs => cs.CourseId);
                    entity.HasOne<Student>(cs => cs.Student).WithMany(s => s.StudentCourses).HasForeignKey(cs => cs.StudentId);
                });
            builder.Entity<CourseTeacher>(
                entity =>
                {
                    entity.HasKey(cs => new { cs.CourseId, cs.TeacherId });
                    entity.HasOne<Course>(cs => cs.Course).WithMany(c => c.CourseTeachers).HasForeignKey(cs => cs.CourseId);
                    entity.HasOne<Teacher>(cs => cs.Teacher).WithMany(t => t.TeacherCourses).HasForeignKey(cs => cs.TeacherId);
                });
            builder.Entity<School>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasMany<Course>(e => e.Courses).WithOne(c => c.School).HasForeignKey(c => c.SchoolId);
                });
            builder.Entity<Lesson>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasOne<Course>(e => e.Course).WithMany(e => e.Lessons).HasForeignKey(e => e.CourseId);
                    entity.HasMany<DataObject>(e => e.DataObjects);
                });
            builder.Entity<DataObject>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });
        }
    }
}
