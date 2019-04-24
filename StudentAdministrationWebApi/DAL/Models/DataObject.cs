using StudentAdministrationWebApi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdministrationWebApi.DAL.Models
{
    /// <summary>
    /// Piece of data related to either a lesson or course. This can be images, documents or plain text.
    /// </summary>
    public class DataObject
    {
        /// <summary>
        /// A unique identifer to the data object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type identification of the related data. Can be either text, document or image.
        /// </summary>
        public ContentType DataType { get; set; }

        /// <summary>
        /// If the content type is text, this property will hold the text.
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// The id of the relevant lesson.
        /// </summary>
        public int LessonId { get; set; }

        /// <summary>
        /// A virtual reference to provide easy access to the lesson 
        /// the data object is attached to, if the data object is attached to a lesson.
        /// </summary>
        public virtual Lesson Lesson { get; set; }

        /// <summary>
        /// The id of the relevant course.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// A virtual reference to provide easy access to the course 
        /// the data object is attached to, if the data object is attached to a course.
        /// </summary>
        public virtual Course Course { get; set; }
    }
}
