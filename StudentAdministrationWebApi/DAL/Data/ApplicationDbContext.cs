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
        public DbSet<Grade> Grades { get; set; }

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
                    entity.HasMany(e => e.Courses);
                });

            builder.Entity<Teacher>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.HasMany(e => e.Courses);
                });

            builder.Entity<Course>(
                entity => 
                {
                    entity.HasKey(e => e.Id);
                    entity.HasMany(e => e.Teachers);
                    entity.HasMany(e => e.Students);

                });

            builder.Entity<Grade>(
                entity =>
                {
                    entity.HasKey(e => e.Id);
                });
        }
    }
}
