using AssimentMVSDataBase.Database;
using AssimentMVSDataBase.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Services
{
    public class StudentCourseService
    {
        readonly SchoolDbContext _schoolDbContext;

        public StudentCourseService(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public Course FindCourse(int id)
        {
            return _schoolDbContext.Courses
                .Include(c => c.Teacher)
                .Include(c => c.StudentsCourses)
                .Include(c => c.Assignments)
                .SingleOrDefault(courses => courses.CourseId == id);
        }

        public bool UpdateCourse(Course course)
        {
            bool wasUpdate = false;

            Course item = _schoolDbContext.Courses.SingleOrDefault(qq => qq.CourseId == course.CourseId);
            {
                if (item != null)
                {
                    item.Title = course.Title;
                    item.Description = course.Description;

                    if (course.Teacher != null)// glöm inte att lägga till//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    {
                        item.Teacher = course.Teacher;
                    }

                    if (course.StudentsCourses != null)// glöm inte att lägga till
                    {
                        item.StudentsCourses = course.StudentsCourses;
                    }

                    if (course.Assignments != null)
                    {
                        item.Assignments = course.Assignments;
                    }

                    _schoolDbContext.SaveChanges();
                    wasUpdate = true;
                }
            }
            return wasUpdate;
        }
    }
}
