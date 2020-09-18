using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFirst.Models
{
    public class SubjectSpecialty
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}
