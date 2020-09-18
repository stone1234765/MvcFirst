using Microsoft.EntityFrameworkCore;
using MvcFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFirst.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            :base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectCourse> SubjectCourses { get; set; }
        public DbSet<SubjectSpecialty> SubjectSpecialties { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(GetSqlConnectionStringBuilder().ConnectionString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectSpecialty>()
                .HasKey(ss => new { ss.SubjectId, ss.SpecialtyId });
            modelBuilder.Entity<SubjectCourse>()
                .HasKey(sc => new { sc.SubjectId, sc.CourseId });

            modelBuilder.Entity<Score>()
                .HasOne(s => s.Student)
                .WithMany(s => s.Scores)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Seed();
        }
    }
}
