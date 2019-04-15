using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class AssignmentVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }//måste också ha courseid när skappas assign till course
    }
}
