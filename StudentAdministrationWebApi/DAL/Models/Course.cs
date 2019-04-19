using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// The course class defines a set of classes or a plan of study on a particular subject.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// A unique ID for the course.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the course.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A short description of the course.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A flag indicating whether a person is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

        /// <summary>
        /// A virtual reference to all course-student pairs.
        /// </summary>
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }

        /// <summary>
        /// A virtual reference to all course-teacher pairs.
        /// </summary>
        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }
    }
}
