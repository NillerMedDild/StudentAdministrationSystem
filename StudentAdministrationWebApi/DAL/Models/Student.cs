using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// The student class defines a person who is or has been enrolled on a course.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// A unique ID for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The full name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The person's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The person's phonenumber.
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// The person's e-mail address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating whether the student is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

        /// <summary>
        /// The id of the school where the student is enrolled.
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// A virtual reference to provide easy access to the school relevant to the student.
        /// </summary>
        public virtual School School { get; set; }

        /// <summary>
        /// A virtual reference to all course-student pairs.
        /// </summary>
        public virtual ICollection<CourseStudent> StudentCourses { get; set; }


    }
}
