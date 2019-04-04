﻿using System;
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

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
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
            var ff = _courseService.FindCourse((int)id);
            if (ff == null)
            {
                return NotFound();
            }
            return View(ff);
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
            return View(course);
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
    }
}