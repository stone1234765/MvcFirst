﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFirst.Models
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }
        //[Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string Name { get; set; }


        public List<Score> Scores { get; set; }
        public List<SubjectCourse> SubjectCourses { get; set; }
        public List<SubjectSpecialty> SubjectSpecialties { get; set; }
    }
}
