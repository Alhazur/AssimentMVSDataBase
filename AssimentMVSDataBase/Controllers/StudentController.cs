using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSDataBase.Database;
using AssimentMVSDataBase.Models;
using AssimentMVSDataBase.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVSDataBase.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _student;

        public StudentController(IStudentService student)
        {
            _student = student;
        }

        public IActionResult Index()
        {
            return View(_student.AllStudents());//måste finns att visa folk
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent([Bind("Name,Phone,Location")]Student student)
        {
            if (ModelState.IsValid)
            {
                student = _student.CreateStudent(student.Name, student.Phone, student.Location);
                return RedirectToAction(nameof(Index));
            }

            return View(student);//gick inte vidare utan måste skriva allt 
        }
        [HttpGet]
        public IActionResult Edit(int? id)//kolla efter id
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = _student.FindStudent((int)id);//cför att byta namn måste method hitta person
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {

            if (ModelState.IsValid)
            {
                _student.UpdateStudent(student);
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _student.DeleteStudent((int)id);
                return RedirectToAction(nameof(Index));
            }
            return Content("");
        }
    }
}