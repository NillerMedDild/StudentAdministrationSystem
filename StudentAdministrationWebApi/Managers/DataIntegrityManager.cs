using StudentAdministrationWebApi.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.Managers
{
    public class DataIntegrityManager
    {
        private readonly ApplicationDbContext _context;

        public DataIntegrityManager(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
