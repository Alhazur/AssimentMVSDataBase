using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public interface ICourseService
    {
        Course CreateCake(string name, int price, string details);

        List<Course> AllCourse();

        Course FindCourse(int id);

        bool UpdateCourse(Course Course);

        bool DeleteCourse(int id);
    }
}
