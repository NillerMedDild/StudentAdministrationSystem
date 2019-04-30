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
        public DbSet<School> Schools { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<DataObject> DataObjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

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
                    entity.HasMany<Course>(e => e.Courses).WithOne(e => e.Student).HasForeignKey(e => e.StudentId);
                });

            builder.Entity<Teacher>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasMany<Course>(e => e.Courses).WithOne(e => e.Teacher).HasForeignKey(e => e.TeacherId);
                });

            builder.Entity<Course>(
                entity => 
                {
                    entity.HasKey(e => e.Id);
                    entity.HasMany<Lesson>(e => e.Lessons).WithOne(e => e.Course).HasForeignKey(e => e.CourseId);
                    entity.HasMany<DataObject>(e => e.DataObjects);
                    
                });
            builder.Entity<School>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasMany<Course>(e => e.Courses).WithOne(e => e.School).HasForeignKey(e => e.SchoolId);
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
            builder.Entity<Grade>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });
        }
    }
}
