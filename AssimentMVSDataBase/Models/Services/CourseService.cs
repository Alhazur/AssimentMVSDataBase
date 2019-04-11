using AssimentMVSDataBase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssimentMVSDataBase.Models.Mock
{
    public class CourseService : ICourseService
    {
        readonly SchoolDbContext _schoolDbContext;

        public CourseService(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public List<Course> AllCourse()
        {//                           till   ta med      Class teacher
            return _schoolDbContext.Courses
                .Include(c => c.Teacher)
                .Include(c => c.StudentsCourses)
                .ThenInclude(c => c.Student)
                .Include(c => c.Assignments)
                .ToList();
        }

        public void AssingCourseToTeacher(int courseId, int teacherId)//11111111111111111
        {
            Course course = _schoolDbContext.Courses.Include(t => t.Teacher).SingleOrDefault(c => c.CourseId == courseId);
            var teacher = _schoolDbContext.Teachers.SingleOrDefault(t => t.Id == teacherId);

            course.Teacher = teacher;
            //course.Teacher = null;

            _schoolDbContext.SaveChanges();
        }

        public Course CreateCourse(string title, string description)
        {
            Course course = new Course()
            {   Title = title,
                Description = description
            };

            _schoolDbContext.Courses.Add(course);
            _schoolDbContext.SaveChanges();
            return course;
        }

        public bool DeleteCourse(int id)
        {
            bool wasRemoved = false;

            Course course = _schoolDbContext.Courses.SingleOrDefault(courses => courses.CourseId == id);//Najti i ydalit

            if (course == null)
            {
                return wasRemoved;
            }

            _schoolDbContext.Courses.Remove(course);
            _schoolDbContext.SaveChanges();
            return wasRemoved;
        }

        public Course FindCourse(int id)
        {//                                 Lägg till teacher för att visa i view
            var course = _schoolDbContext.Courses
                .Include(c => c.Teacher)// här den visar i Details
                .Include(c => c.StudentsCourses)
                .Include("StudentsCourses.Student")
                .Include(c => c.Assignments)
                .SingleOrDefault(courses => courses.CourseId == id);

            return course;
        }

        public bool UpdateCourse(Course course)
        {
            bool wasUpdate = false;

            Course oldCourse = FindCourse(course.CourseId);//använda method FindCourse eftersom den tar med sig teacher, student

            if (oldCourse != null)
            {
                oldCourse.Title = course.Title;
                oldCourse.Description = course.Description;
                
                if (course.Teacher != null)
                {
                    oldCourse.Teacher = course.Teacher;//den kopplar teacher till course
                }

                if (course.StudentsCourses != null)// glöm inte att lägga till
                {
                    oldCourse.StudentsCourses = course.StudentsCourses;
                }

                if (course.Assignments != null)
                {
                    oldCourse.Assignments = course.Assignments;
                }

                _schoolDbContext.SaveChanges();
                wasUpdate = true;
            }

            return wasUpdate;
        }
    }
}
