using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFirst.Models
{
    public class SubjectCourse
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
