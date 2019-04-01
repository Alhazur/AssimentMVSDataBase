using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Interface
{
    interface IStudent
    {
        Student CreateStudent(string name, int price, string details);

        List<Student> AllStudent();

        Student FindCake(int id);

        bool UpdateCake(Student student);

        bool DeleteCake(int id);
    }
}
