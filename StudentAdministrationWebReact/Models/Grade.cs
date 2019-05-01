using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebReact.Models
{
    /// <summary>
    /// The grade class defines the score a student has received in a course.
    /// </summary>
    public class Grade
    {
        /// <summary>
        /// A unique identifer to the grade.
        /// </summary>
        public int Id { get; set; }

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
        /// A virtual reference to the student.
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// The grade the student has received in the course.
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        /// A flag indicating whether the grade is valid or not.
        /// </summary>
        public bool Historic { get; set; }

    }
}
