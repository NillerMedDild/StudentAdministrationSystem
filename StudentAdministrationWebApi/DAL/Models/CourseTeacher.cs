using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// The course teachers class defines a collection of teachers for a specific course.
    /// </summary>
    public class CourseTeacher
    {
        /// <summary>
        /// ID of the relevant course.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// A virtual reference to the course.
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// ID of the relevant teacher.
        /// </summary>
        public int TeacherId { get; set; }

        /// <summary>
        /// A virtual reference to provide easy access to teacher relevant to the course.
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        /// <summary>
        /// A flag indicating whether the course-teacher relationship is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

    }
}
