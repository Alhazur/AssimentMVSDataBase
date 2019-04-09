using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSDataBase.Database;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVSDataBase.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentCourseController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}