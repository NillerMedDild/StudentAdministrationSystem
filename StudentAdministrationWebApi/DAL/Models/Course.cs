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
        /// Virtual reference to provide easy access to teachers relevant to the course.
        /// </summary>
        public virtual ICollection<Teacher> Teachers { get; set; }

        /// <summary>
        /// Virtual reference to provide easy access to students relevant to the course.
        /// </summary>
        public virtual ICollection<Student> Students { get; set; }
    }
}
