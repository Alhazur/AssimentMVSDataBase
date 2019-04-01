using AssimentMVSDataBase.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Mock
{
    public class TeacherService : ITeacherService
    {
        public List<Teacher> AllTeacher()
        {
            throw new NotImplementedException();
        }

        public Teacher CreateTeacher(string name, int price, string details)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public Teacher FindTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
