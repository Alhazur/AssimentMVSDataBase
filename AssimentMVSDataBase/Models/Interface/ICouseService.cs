using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    interface ICouseService
    {
        Course CreateCake(string name, int price, string details);

        List<Course> AllCakes();

        Course FindCake(int id);

        bool UpdateCake(Course Course);

        bool DeleteCake(int id);
    }
}
