using AssimentMVSDataBase.Models;
using AssimentMVSDataBase.Models.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Database
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsCourses>()
                .HasKey(t => new { t.CourseId, t.StudentId });

            modelBuilder.Entity<StudentsCourses>()
                .HasOne(pt => pt.Course)
                .WithMany(pt => pt.StudentsCourses)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<StudentsCourses>()
                .HasOne(pt => pt.Student)
                .WithMany(t => t.StudentsCourses)
                .HasForeignKey(pt => pt.StudentId);

            modelBuilder.Entity<Course>()
            .HasMany(c => c.Assignments)
            .WithOne();

            modelBuilder.Entity<Teacher>()
           .HasMany(t => t.Courses)
           .WithOne(t => t.Teacher);
        }
    }
}
