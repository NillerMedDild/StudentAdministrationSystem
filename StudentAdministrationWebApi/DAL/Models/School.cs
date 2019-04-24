using StudentAdministrationWebApi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// The school class defines a place where students receive education from teachers.
    /// </summary>
    public class School
    {
        /// <summary>
        /// A unique ID for the school.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the school.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The address of the school.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The level of the education the school provides.
        /// </summary>
        public EducationLevel EducationLevel { get; set; }

        /// <summary>
        /// The school type defines the type of the school.
        /// </summary>
        public SchoolType SchoolType { get; set; }

        /// <summary>
        /// A flag indicating whether the school is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

        /// <summary>
        /// A virtual reference to all courses taught at the school.
        /// </summary>
        public virtual ICollection<Course> Courses { get; set; }
    }
}
