using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Interface
{
    interface ITeacher
    {
        Teacher CreateTeacher(string name, int price, string details);

        List<Teacher> AllTeacher();

        Teacher FindTeacher(int id);

        bool UpdateTeacher(Teacher teacher);

        bool DeleteTeacher(int id);
    }
}
