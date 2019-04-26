using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdministrationWebApi.DAL.Data;
using StudentAdministrationWebApi.DAL.Models;

namespace StudentAdministrationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<CourseStudent> GetCourseStudents()
        {
            return _context.CourseStudents;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseStudent = await _context.CourseStudents.FindAsync(id);

            if (courseStudent == null)
            {
                return NotFound();
            }

            return Ok(courseStudent);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseStudent([FromRoute] int id, [FromBody] CourseStudent courseStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseStudent.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(courseStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CourseStudents
        [HttpPost]
        public async Task<IActionResult> PostCourseStudent([FromBody] CourseStudent courseStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Courses.FindAsync(courseStudent.CourseId);
            if (course == null)
            {
                
                return BadRequest($"Course with ID {courseStudent.CourseId} not found.");
            }

            var student = await _context.Students.FindAsync(courseStudent.StudentId);
            if (student == null)
            {
                return BadRequest($"Student with ID {courseStudent.StudentId} not found.");
            }

            var oldCourseStudent = await _context.CourseStudents.FindAsync(courseStudent.StudentId);
            if (oldCourseStudent != null)
            {
                oldCourseStudent = await _context.CourseStudents.FindAsync(courseStudent.CourseId);
                if (oldCourseStudent != null)
                {
                    return BadRequest($"CourseStudent with CourseId {courseStudent.CourseId} and StudentId {courseStudent.StudentId} already exists.");
                }
            }

            _context.CourseStudents.Add(courseStudent);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseStudentExists(courseStudent.CourseId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourseStudent", new { id = courseStudent.CourseId }, courseStudent);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseStudent = await _context.CourseStudents.FindAsync(id);
            if (courseStudent == null)
            {
                return NotFound();
            }

            _context.CourseStudents.Remove(courseStudent);
            await _context.SaveChangesAsync();

            return Ok(courseStudent);
        }

        private bool CourseStudentExists(int id)
        {
            return _context.CourseStudents.Any(e => e.CourseId == id);
        }
    }
}