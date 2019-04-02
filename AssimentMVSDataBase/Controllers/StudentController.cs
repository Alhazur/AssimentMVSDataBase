using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSDataBase.Database;
using AssimentMVSDataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVSDataBase.Controllers
{
    public class StudentController : Controller
    {
        readonly SchoolDbContext _schoolDbContext;

        public StudentController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IActionResult Index()
        {
            return View(_schoolDbContext.Students);
        }
        [HttpPost]
        public IActionResult CreateStudent([Bind("Name,Phone,Location")]Student student)
        {
            if (ModelState.IsValid)
            {
                _schoolDbContext.Add(student);
                _schoolDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(student);//gick inte bra tillbaka
        }
    }
}