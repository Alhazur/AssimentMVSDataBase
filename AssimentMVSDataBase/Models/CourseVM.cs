using AssimentMVSDataBase.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class CourseVM
    {
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public int TeacherId { get; set; }

        public int AssiId { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Assignment> Assignments { get; set; }

        //public List<StudentsCourses> StudentsCourses { get; set; }


    }
}
