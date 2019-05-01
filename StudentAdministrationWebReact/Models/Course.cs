using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebReact.Models
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
        /// The id of the student relevant to this course.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// A virtual reference to a student relevant to this course.
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// The id of the teacher relevant to this course.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// A virtual reference to a teacher relevant to this course.
        /// </summary>
        public virtual Teacher Teacher { get; set; }

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
