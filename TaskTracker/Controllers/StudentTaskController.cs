using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.ViewModels;

namespace TaskTracker.Controllers
{
    public class StudentTaskController : Controller
    {
        //static private List<StudentTask> studentTasks = new List<StudentTask>();
        
        [HttpGet]
        public IActionResult Index()
        {
            //studentTasks.Add("Clean Desk");
            //studentTasks.Add("Monitor Gallery");
            //ViewBag.studentTasks = StudentTaskData.GetAll();
            List<StudentTask> studentTasks = new List<StudentTask>(StudentTaskData.GetAll());

            return View(studentTasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddStudentTaskViewModel addStudentTaskViewModel = new AddStudentTaskViewModel();
            return View(addStudentTaskViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddStudentTaskViewModel addStudentTaskViewModel)
        {
            StudentTask newStudentTask = new StudentTask
            {
                Name = addStudentTaskViewModel.Name,
                Description = addStudentTaskViewModel.Description,
                DueDate = addStudentTaskViewModel.DueDate
            };
            StudentTaskData.Add(newStudentTask);
            return Redirect("/StudentTask");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.studentTasks = StudentTaskData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] studentTaskIds)
        {
            foreach(int studentTaskId in studentTaskIds)
            {
                StudentTaskData.Remove(studentTaskId);
            }

            return Redirect("/StudentTask");
        }

        //public IActionResult Detail()
        //{
        //    DetailStudentTaskViewModel detailStudentTaskViewModel = new DetailStudentTaskViewModel(StudentTaskData.GetById(1));
        //    return View();
        //}
    }
}
