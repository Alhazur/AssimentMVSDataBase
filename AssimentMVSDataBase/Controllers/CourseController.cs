using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSDataBase.Models;
using AssimentMVSDataBase.Models.Class;
using AssimentMVSDataBase.Models.Interface;
using Microsoft.AspNetCore.Mvc;


namespace AssimentMVSDataBase.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;
        private readonly IAssignmentService _assignmentService;
        private readonly IStudentService _studentService;



        public CourseController(ICourseService courseService, ITeacherService teacherService, IAssignmentService assignmentService, IStudentService studentService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
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

        public IActionResult CreateAssignment(int courseId)
        {
            var vm = new AssignmentVM
            {
                CourseId = courseId
            };

            return View(vm);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAssignment(Assignment assignment, int courseId)//för att skappa assig till course use class assig o course id
        {
            if (ModelState.IsValid)
            {
                _assignmentService.CreateAssignment(assignment, courseId);//samma posion som i interfase

                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
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
            //CourseVM will be used her in the controller
            CourseVM name = new CourseVM
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Description = course.Description,
                Teachers = _teacherService.AllTeacher(),
                //Assignments = _assignmentService.AllAssignment()//001
            };
            return View(name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseVM course)
        {
            if (ModelState.IsValid)
            {
                var teacherF = _teacherService.FindTeacher(course.TeacherId);//använda hitta teacher

                var courseToUpdate = new Course
                {
                    Title = course.Title,
                    Description = course.Description,
                    Teacher = teacherF,
                    CourseId = course.CourseId
                };
                _courseService.UpdateCourse(courseToUpdate);
                return RedirectToAction(nameof(Index));
            }

            CourseViewModel CourseViewModel = new CourseViewModel();
            //CourseViewModel.course = new Course();
            //CourseViewModel.teachers = _teacherService.AllTeacher();//för att byta id tx
            //CourseViewModel.students = _studentService.AllStudents();            

            return View(course);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _courseService.DeleteCourse((int)id);
                _assignmentService.DeleteAssignment((int)id);
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

            CourseViewModel CourseViewModel = new CourseViewModel();//först kalla vm vilket innehåller LIST dem som vill du hantera
            CourseViewModel.Course = course;

            CourseViewModel.Assignments = course.Assignments;//inte allAssignments 

            //++
            List<Student> studentsNotInCourse = _studentService.AllStudents();//för att visa all dem som ej koplat till courses

            foreach (var item in course.StudentsCourses)
            {
                studentsNotInCourse.Remove(item.Student);
            }

            CourseViewModel.Students = studentsNotInCourse;// lägg till vm.alla studenter eller vad som helst
            //++
            return View(CourseViewModel);
        }

        //public IActionResult AddStudentToCourse(int id)
        //{
        //    var course = _courseService.FindCourse(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    List<Student> students = _studentService.AllStudents();

        //    foreach (var item in course.StudentsCourses)
        //    {
        //        students.Remove(item.Student);
        //    }

        //    ViewBag.cId = course.CourseId;
        //    return View(students);
        //}

        public IActionResult AddStudentToCourseSave(int cId, int sId)
        {
            var course = _courseService.FindCourse(cId);
            if (course == null)
            {
                return NotFound();
            }

            var student = _studentService.FindStudent(sId);
            if (student == null)
            {
                return NotFound();
            }

            foreach (var item in course.StudentsCourses)//kontrolerar om eleven redan finns
            {
                if (item.StudentId == sId)
                {
                    return RedirectToAction(nameof(Details), new { id = cId });
                }
            }

            _courseService.AddStudentToCourse(course,student);//koplar student course med varandra        

            return RedirectToAction(nameof(Details), new { id = cId });
        }

        public IActionResult RemoveStudentToCourse(int cId, int sId)//ybrat iz coursa
        {
            var course = _courseService.FindCourse(cId);
            if (course == null)
            {
                return NotFound();
            }

            _courseService.RemoveStudentToCourse(course, sId);//ispolzovat method iz courseservica RemoveStudentToCourse

            return RedirectToAction(nameof(Details), new { id = cId });
        }
    }
}