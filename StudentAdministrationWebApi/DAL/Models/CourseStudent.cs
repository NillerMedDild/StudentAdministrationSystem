using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// The course students class defines a collection of students for a specific course.
    /// </summary>
    public class CourseStudent
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
        /// ID of the relevant student.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// A virtual reference to provide easy access to student relevant to the course.
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// The grade the student has received in the course.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// A flag indicating whether a person is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

    }
}
