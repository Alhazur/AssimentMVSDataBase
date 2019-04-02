using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Interface
{
    public interface ITeacherService
    {
        Teacher CreateTeacher(string name, string description);

        List<Teacher> AllTeacher();

        Teacher FindTeacher(int id);

        bool UpdateTeacher(Teacher teacher);

        bool DeleteTeacher(int id);
    }
}
