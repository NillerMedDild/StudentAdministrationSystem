using Microsoft.EntityFrameworkCore;
using StudentAdministrationWebApi.DAL.Data;
using System;
using System.Collections.Generic;

namespace StudentAdministrationTest
{
    public abstract class DatabaseFixture : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        protected readonly ApplicationDbContextFactory ContextFactory;
        private readonly DbContextOptions<ApplicationDbContext> _options;
        public ApplicationDbContext _context;

        public DatabaseFixture(string databaseName)
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName).Options;
            _context = new ApplicationDbContext(_options);
            ContextFactory = new ApplicationDbContextFactory(_options);
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
            }

            disposed = true;
        }
    }
}
