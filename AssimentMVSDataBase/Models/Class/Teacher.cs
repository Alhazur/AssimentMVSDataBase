using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public List<Course> StudentCource { get; set; }
    }
}
