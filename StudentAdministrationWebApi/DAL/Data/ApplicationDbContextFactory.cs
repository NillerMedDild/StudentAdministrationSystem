using Microsoft.EntityFrameworkCore;

namespace StudentAdministrationWebApi.DAL.Data
{
    public class ApplicationDbContextFactory
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public ApplicationDbContextFactory(DbContextOptions<ApplicationDbContext> options)
        {
            _options = options;
        }

        public ApplicationDbContext BuildContext()
        {
            return new ApplicationDbContext(_options);
        }
    }
}
