using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSDataBase.Models.Class
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Student> Student { get; set; }
    }
}
