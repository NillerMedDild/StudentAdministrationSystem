using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
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
        /// Flag indicating whether a person is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

        /// <summary>
        /// Virtual reference to provide easy access to courses relevant to the person.
        /// </summary>
        public virtual ICollection<Course> Courses { get; set; }

        /// <summary>
        /// A Dictionary of the student's grades from completed courses.
        /// </summary>
        public Dictionary<Course, double> Grades { get; set; }
        
    }
}
