using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Interface
{
    public interface IStudentService
    {
        Student CreateStudent(string name, int price, string details);

        List<Student> AllStudent();

        Student FindStudent(int id);

        bool UpdateStudent(Student student);

        bool DeleteStudent(int id);
    }
}
