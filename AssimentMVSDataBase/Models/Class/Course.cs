using AssimentMVSDataBase.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public Teacher Teacher { get; set; }

        public List<Student> Student { get; set; }

        public List<Assignment> Assignments { get; set; }

    }
}
