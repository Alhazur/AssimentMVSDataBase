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

        public Course Course { get; set; }
    }
}
