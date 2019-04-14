using AssimentMVSDataBase.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class CourseViewModel
    {
        
        public List<Teacher> Teachers = new List<Teacher>();

        public List<Student> Students = new List<Student>();

        public List<Assignment> Assignments = new List<Assignment>();

        public Course Course { get; set; }
    }
}
