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
        private StudentTaskDbContext context;

        public StudentTaskController(StudentTaskDbContext dbContext)
        {
            context = dbContext;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            //studentTasks.Add("Clean Desk");
            //studentTasks.Add("Monitor Gallery");
            //ViewBag.studentTasks = StudentTaskData.GetAll();
            //List<StudentTask> studentTasks = new List<StudentTask>(StudentTaskData.GetAll());
            List<StudentTask> studentTasks = context.StudentTasks.ToList();

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
            //StudentTaskData.Add(newStudentTask);
            //New two lines store to persistent database
            context.StudentTasks.Add(newStudentTask);
            context.SaveChanges();

            return Redirect("/StudentTask");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            //ViewBag.studentTasks = StudentTaskData.GetAll();
            ViewBag.studentTasks = context.StudentTasks.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] studentTaskIds)
        {
            foreach(int studentTaskId in studentTaskIds)
            {
                //StudentTaskData.Remove(studentTaskId);
                StudentTask theStudentTask = context.StudentTasks.Find(studentTaskId);
                context.StudentTasks.Remove(theStudentTask);
            }
            context.SaveChanges();

            return Redirect("/StudentTask");
        }

        //public IActionResult Detail()
        //{
        //    DetailStudentTaskViewModel detailStudentTaskViewModel = new DetailStudentTaskViewModel(StudentTaskData.GetById(1));
        //    return View();
        //}
    }
}
