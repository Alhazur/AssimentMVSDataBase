using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class CourseViewModel
    {
        
        public List<Teacher> teachers = new List<Teacher>();

        public List<Student> students = new List<Student>();

        public Course course { get; set; }
    }
}
