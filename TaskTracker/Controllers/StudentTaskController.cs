using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Data;
using TaskTracker.Models;
using TaskTracker.ViewModels;

namespace TaskTracker.Controllers
{
    [Authorize]   
    public class StudentTaskController : Controller
    {
        //static private List<StudentTask> studentTasks = new List<StudentTask>();
        private StudentTaskDbContext context;
        private IAuthorizationService authorizationService;
        private UserManager<IdentityUser> userManager;

        public StudentTaskController(StudentTaskDbContext dbContext, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base()
        {
            context = dbContext;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var currentUserId = userManager.GetUserId(User);
;            //studentTasks.Add("Clean Desk");
             //studentTasks.Add("Monitor Gallery");
             //ViewBag.studentTasks = StudentTaskData.GetAll();
             //List<StudentTask> studentTasks = new List<StudentTask>(StudentTaskData.GetAll());
             //List<StudentTask> studecdntTasks = context.StudentTasks
             //.Where(e => e.UserId == currentUserId)
             //.ToList();
            List<StudentTag> studentTags = context.StudentTags.ToList();
            
            return View(studentTags);
        }

        [HttpGet]
        [Authorize(Roles = "Administration")]
        public IActionResult AllTasks()
        {
            var currentUserId = userManager.GetUserId(User);
            //studentTasks.Add("Clean Desk");
            //studentTasks.Add("Monitor Gallery");
            //ViewBag.studentTasks = StudentTaskData.GetAll();
            //List<StudentTask> studentTasks = new List<StudentTask>(StudentTaskData.GetAll());
            List<StudentTask> studentTasks = context.StudentTasks
                .Where(e => e.UserId == currentUserId)
                .ToList();

            //List<TaskTag> taskTags = context.TaskTags.ToList();

            //AllTasksViewModel allTasksViewModel = new AllTasksViewModel(studentTasks, taskTags);
            //return View(allTasksViewModel);

            return View(studentTasks);
        }

        [HttpGet]
        [Authorize(Roles = "Administration")]
        public IActionResult Add()
        {
            AddStudentTaskViewModel addStudentTaskViewModel = new AddStudentTaskViewModel();
            return View(addStudentTaskViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public IActionResult Add(AddStudentTaskViewModel addStudentTaskViewModel)
        {
            var currentUserId = userManager.GetUserId(User);
            
            StudentTask newStudentTask = new StudentTask
            {
                Name = addStudentTaskViewModel.Name,
                Description = addStudentTaskViewModel.Description,
                DueDate = addStudentTaskViewModel.DueDate,
                UserId = currentUserId
            };
            //StudentTaskData.Add(newStudentTask);
            //Next two lines store to persistent database
            context.StudentTasks.Add(newStudentTask);
            context.SaveChanges();

            return Redirect("/StudentTask/AllTasks");
        }

        [HttpGet]
        [Authorize(Roles = "Administration")]
        public IActionResult Delete()
        {
            //ViewBag.studentTasks = StudentTaskData.GetAll();
            //ViewBag.studentTasks = context.StudentTasks.ToList();
            //return View();
            var currentUserId = userManager.GetUserId(User);
            List<StudentTask> studentTasks = context.StudentTasks
                .Where(e => e.UserId == currentUserId)
                .ToList();

            return View(studentTasks);
        }

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public IActionResult Delete(int[] studentTaskIds)
        {
            foreach(int studentTaskId in studentTaskIds)
            {
                //StudentTaskData.Remove(studentTaskId);
                StudentTask theStudentTask = context.StudentTasks.Find(studentTaskId);
                context.StudentTasks.Remove(theStudentTask);
            }
            context.SaveChanges();

            return Redirect("/StudentTask/AllTasks");
        }

        public IActionResult Update(int id)
        {
            StudentTask theStudentTask = context.StudentTasks.Single(e => e.Id == id);
            DetailStudentTaskViewModel viewModel = new DetailStudentTaskViewModel(theStudentTask);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(int id, string name, string description, DateTime dueDate, Boolean approved, DateTime approveDate)
        {
            StudentTask theStudentTask = context.StudentTasks.Find(id);
            theStudentTask.Name = name;
            theStudentTask.Description = description;
            theStudentTask.DueDate = dueDate;
            theStudentTask.Approved = approved;
            theStudentTask.ApproveDate = approveDate;
            context.SaveChanges();
            return Redirect("/StudentTask/AllTasks");
        }

        [HttpGet]
        public IActionResult Duplicate(int id)
        {
            StudentTask theStudentTask = context.StudentTasks.Single(e => e.Id == id);

            DuplicateStudentTaskViewModel duplicateStudentTaskViewModel = new DuplicateStudentTaskViewModel(theStudentTask);
            return View(duplicateStudentTaskViewModel);
        }

        [HttpPost]
        public IActionResult Duplicate(int id, string name, string description)
        {
            StudentTask theStudentTask = context.StudentTasks.Single(e => e.Id == id);

            var currentUserId = userManager.GetUserId(User);

            StudentTask newStudentTask = new StudentTask
            {
                Name = theStudentTask.Name,
                Description = theStudentTask.Description,
                //DueDate = addStudentTaskViewModel.DueDate,
                UserId = currentUserId
            };
            
            context.StudentTasks.Add(newStudentTask);
            context.SaveChanges();

            return Redirect("/StudentTask/AllTasks");


            //DuplicateStudentTaskViewModel viewModel = new DuplicateStudentTaskViewModel(theStudentTask);

            //return View(viewModel);
        }
    

        public IActionResult Detail(int id)
        {
            StudentTask theStudentTask = context.StudentTasks.Single(e => e.Id == id);

            List<TaskTag> studentNamesText = context.TaskTags
                .Where(et => et.StudentTaskId == id)
                .Include(et => et.StudentTag)
                .ToList();

            DetailStudentTaskViewModel viewModel = new DetailStudentTaskViewModel(theStudentTask, studentNamesText);

            return View(viewModel);
        }
        
        public IActionResult DetailStudent(int id)
        {
            StudentTask theStudentTask = context.StudentTasks.Single(e => e.Id == id);
            //StudentTag theStudentTag = context.StudentTags.Single(e => e.Id == studentTagId);

            //List<TaskTag> studentNamesText = context.TaskTags
            //    .Where(et => et.StudentTaskId == id)
            //    .Include(et => et.StudentTag)
            //    .ToList();

            DetailStudentTaskViewModel viewModel = new DetailStudentTaskViewModel(theStudentTask);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DetailStudent(int id, DateTime submitDate)
        {
            StudentTask theStudentTask = context.StudentTasks.Find(id);
            //TaskTag theStudentTask = context.TaskTags.Find(studentTaskId);
            theStudentTask.SubmitDate = submitDate;
            context.SaveChanges();
            return Redirect("/StudentTask");
        }

        [HttpGet]
        [Authorize(Roles = "Administration")]
        public IActionResult AddStudentTag(int id)
        {
            StudentTask studentTask = context.StudentTasks.Find(id);
            List<StudentTag> possibleTags = context.StudentTags.ToList();

            AddTaskTagViewModel viewModel = new AddTaskTagViewModel(studentTask, possibleTags);

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public IActionResult AddStudentTag(AddTaskTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //int studentTaskId = viewModel.StudentTaskId;
                StudentTask studentTask = context.StudentTasks.Find(viewModel.StudentTaskId);
                int studentTagId = viewModel.StudentTagId;

                List<TaskTag> existingItems = context.TaskTags
                    .Where(et => et.StudentTaskId == studentTask.Id)
                    .Where(et => et.StudentTagId == studentTagId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    TaskTag taskTag = new TaskTag
                    {
                        //StudentTask = studentTask,
                        StudentTagId = studentTagId,
                        StudentTaskId = studentTask.Id,
                        DueDate = studentTask.DueDate,
                        SubmitDate = studentTask.SubmitDate,
                        ApproveDate = studentTask.ApproveDate,
                        Approved = studentTask.Approved
                    };

                    context.TaskTags.Add(taskTag);
                    context.SaveChanges();
                }

                return Redirect("/StudentTask/Detail/" + studentTask.Id);
            }

            return View(viewModel);
        }
    }
}
