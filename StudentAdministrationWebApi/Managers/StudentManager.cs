using Microsoft.EntityFrameworkCore;
using StudentAdministrationWebApi.DAL.Models;
using StudentAdministrationWebApi.DAL.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.Managers
{
    public class StudentManager
    {
        private readonly ApplicationDbContext _context;
        private readonly DataIntegrityManager _dataIntegrityManager;

        public StudentManager(ApplicationDbContext context)
        {
            _context = context;
            _dataIntegrityManager = new DataIntegrityManager(context);
        }

        public List<Student> RetrieveAllStudents()
        {
            using (_context)
            {
                return _context.Students.ToList();
            }
        }

        public Student RetrieveStudent(int id)
        {
            using (_context)
            {
                return _context.Students.SingleOrDefault(e => e.Id == id); ;
            }
        }

        public async Task AmendStudentAsync(Student type)
        {
            _context.Entry(type).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /*
        public async Task<int> CreateStudentAsync(Student type)
        {
            
            var category = _context.Categories.FirstOrDefault(e => e.Id == type.CategoryId);

            // Related objects are allowed to be null, they are not allowed to reference non-existant data
            if (category == null && type.CategoryId != 0)
            {
                throw new KeyNotFoundException("No such category id in ARIA.");
            }

            await _dataIntegrityManager.CreateStudent(type);
            return type.Id;
        }*/
        /*
        public async Task RetireStudent(int id)
        {
            await _dataIntegrityManager.RetireStudent(id);
        }*/
    }
}
