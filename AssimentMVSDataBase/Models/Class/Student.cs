using AssimentMVSDataBase.Models.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Location { get; set; }

        public List<Course> Cource { get; set; }
    }
}
