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
        /// A flag indicating whether the course is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

        /// <summary>
        /// The id of the school where the course is taught.
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// A virtual reference to provide easy access to the school relevant to the course.
        /// </summary>
        public virtual School School { get; set; }

        /// <summary>
        /// A virtual reference to all course-student pairs.
        /// </summary>
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }

        /// <summary>
        /// A virtual reference to all course-teacher pairs.
        /// </summary>
        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }

        /// <summary>
        /// A virtual reference to all related lessons.
        /// </summary>
        public virtual ICollection<Lesson> Lessons { get; set; }

        /// <summary>
        /// A virtual reference to all related data objects.
        /// </summary>
        public virtual ICollection<DataObject> DataObjects { get; set; }
    }
}
