using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFirst.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        //[Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        //[Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string LastName { get; set; }
        public int? AverageScore { get; set; }

        public List<Score> Scores { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
