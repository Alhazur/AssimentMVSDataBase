using AssimentMVSDataBase.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Location { get; set; }

        public List<StudentsCourses> StudentsCourses { get; set; }

        public List<Course> Courses { get; set; }

        public List<Assignment> Assignments { get; set; }
    }
}
