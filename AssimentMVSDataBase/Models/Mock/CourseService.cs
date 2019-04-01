using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Mock
{
    public class CourseService : ICourseService
    {
        public List<Course> AllCourse()
        {
            throw new NotImplementedException();
        }

        public Course CreateCake(string name, int price, string details)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Course FindCourse(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCourse(Course Course)
        {
            throw new NotImplementedException();
        }
    }
}
