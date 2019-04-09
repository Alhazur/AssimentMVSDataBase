using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSDataBase.Models;
using AssimentMVSDataBase.Models.Interface;
using Microsoft.AspNetCore.Mvc;


namespace AssimentMVSDataBase.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;//+++++++++++++++++++++++++
        private readonly IAssignmentService _assignmentService;
        private readonly IStudentService _studentService;

        

        public CourseController(ICourseService courseService, ITeacherService teacherService, IAssignmentService assignmentService, IStudentService studentService)
        {
            _courseService = courseService;
            _teacherService = teacherService;//+++++++++++++++++++++++++
            _assignmentService = assignmentService;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View(_courseService.AllCourse());
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCourse([Bind("Title, Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                course = _courseService.CreateCourse(course.Title, course.Description);
                return RedirectToAction(nameof(Index));                              
            }

            return View(course);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _courseService.FindCourse((int)id);
            if (course == null)
            {
                return NotFound();
            }

            CourseViewModel CourseViewModel = new CourseViewModel();
            CourseViewModel.course = course;
            CourseViewModel.teachers = _teacherService.AllTeacher();//////////////////////////////
            

            return View(CourseViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {

            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(course);
                return RedirectToAction(nameof(Index));

            }

            CourseViewModel CourseViewModel = new CourseViewModel();
            CourseViewModel.course = course;
            CourseViewModel.teachers = _teacherService.AllTeacher();//////////////////////////////
            CourseViewModel.students = _studentService.AllStudents();

            return View(CourseViewModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _courseService.DeleteCourse((int)id);
                return RedirectToAction(nameof(Index));
            }
            return Content("");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _courseService.FindCourse((int)id);
            if (course == null)
            {
                return NotFound();
            }

            CourseViewModel CourseViewModel = new CourseViewModel();
            CourseViewModel.course = course;
            //CourseViewModel.teachers = _teacherService.AllTeacher();//////////////////////////////
            //CourseViewModel.students = _studentService.AllStudents();

            return View(CourseViewModel);


        }
    }
}