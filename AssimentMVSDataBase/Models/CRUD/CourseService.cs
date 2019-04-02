using AssimentMVSDataBase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        {
            return _schoolDbContext.Courses.ToList();
        }

        public Course CreateCourse(string title, string description)
        {
            Course course = new Course() { Title = title, Description = description };

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
        {
            return _schoolDbContext.Courses.SingleOrDefault(courses => courses.CourseId == id);
        }

        public bool UpdateCourse(Course course)
        {
            bool wasUpdate = false;

            Course original = _schoolDbContext.Courses.SingleOrDefault(courses => courses.CourseId == course.CourseId);//Najti i ydalit

            if (original == null)
            {
                return wasUpdate;
            }

            _schoolDbContext.Courses.Remove(original);
            _schoolDbContext.SaveChanges();

            return wasUpdate;
        }
    }
}
