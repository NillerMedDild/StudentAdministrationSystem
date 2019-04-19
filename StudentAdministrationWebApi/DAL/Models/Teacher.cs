using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// The teacher class defines a person who is or has been teaching a course.
    /// </summary>
    public class Teacher
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
        /// A flag indicating whether a person is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

        /// <summary>
        /// A virtual reference to all course-teacher pairs.
        /// </summary>
        public virtual ICollection<CourseTeacher> TeacherCourses { get; set; }
    }
}
