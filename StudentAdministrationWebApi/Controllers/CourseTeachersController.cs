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
    public class CourseTeachersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseTeachersController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<CourseTeacher> GetCourseTeachers()
        {
            return _context.CourseTeachers;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseTeacher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseTeacher = await _context.CourseTeachers.FindAsync(id);

            if (courseTeacher == null)
            {
                return NotFound();
            }

            return Ok(courseTeacher);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseTeacher([FromRoute] int id, [FromBody] CourseTeacher courseTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseTeacher.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(courseTeacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseTeacherExists(id))
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

        // POST: api/CourseTeachers
        [HttpPost]
        public async Task<IActionResult> PostCourseTeacher([FromBody] CourseTeacher courseTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Courses.FindAsync(courseTeacher.CourseId);
            if (course == null)
            {

                return BadRequest($"Course with ID {courseTeacher.CourseId} not found.");
            }

            var student = await _context.Teachers.FindAsync(courseTeacher.TeacherId);
            if (student == null)
            {
                return BadRequest($"Teacher with ID {courseTeacher.TeacherId} not found.");
            }

            var oldCourseTeacher = await _context.CourseTeachers.FindAsync(courseTeacher.TeacherId);
            if (oldCourseTeacher != null)
            {
                oldCourseTeacher = await _context.CourseTeachers.FindAsync(courseTeacher.CourseId);
                if (oldCourseTeacher != null)
                {
                    return BadRequest($"CourseTeacher with CourseId {courseTeacher.CourseId} and TeacherId {courseTeacher.TeacherId} already exists.");
                }
            }

            _context.CourseTeachers.Add(courseTeacher);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseTeacherExists(courseTeacher.CourseId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourseTeacher", new { id = courseTeacher.CourseId }, courseTeacher);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseTeacher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseTeacher = await _context.CourseTeachers.FindAsync(id);
            if (courseTeacher == null)
            {
                return NotFound();
            }

            _context.CourseTeachers.Remove(courseTeacher);
            await _context.SaveChangesAsync();

            return Ok(courseTeacher);
        }

        private bool CourseTeacherExists(int id)
        {
            return _context.CourseTeachers.Any(e => e.CourseId == id);
        }
    }
}