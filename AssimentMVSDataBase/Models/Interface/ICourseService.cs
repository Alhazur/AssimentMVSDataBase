using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public interface ICourseService
    {
        Course CreateCourse(string name, string description);

        List<Course> AllCourse();

        Course FindCourse(int id);

        bool UpdateCourse(Course Course);

        bool DeleteCourse(int id);

        void AssingCourseToTeacher(int CourseId, int teacherId);
    }
}
