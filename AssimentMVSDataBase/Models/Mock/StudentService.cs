using AssimentMVSDataBase.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Mock
{
    public class StudentService : IStudentService
    {
        public List<Student> AllStudent()
        {
            throw new NotImplementedException();
        }

        public Student CreateStudent(string name, int price, string details)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Student FindStudent(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
