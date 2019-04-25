using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// The lesson class defines a specific lesson held in a course.
    /// </summary>
    public class Lesson
    {
        /// <summary>
        /// A unique ID for the lesson.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// A short description of the lesson.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The location where the lesson is held.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The date and start time of the lesson.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The duration of the lesson, in minutes.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// A flag indicating whether the lesson is currently active or historic.
        /// </summary>
        public bool Historic { get; set; }

        /// <summary>
        /// The id of the course the lesson is in.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// A virtual reference to provide easy access to the course relevant to the lesson.
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// A virtual reference to all related data objects.
        /// </summary>
        public virtual ICollection<DataObject> DataObjects { get; set; }
        
    }
}
