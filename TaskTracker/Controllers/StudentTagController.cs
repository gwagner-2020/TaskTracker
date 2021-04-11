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
    public class StudentTagController : Controller
    {
        private StudentTaskDbContext context;
        //private IAuthorizationService authorizationService;
        //private UserManager<IdentityUser> userManager;

        public StudentTagController(StudentTaskDbContext dbContext)
        {
            context = dbContext;
        }

        [Authorize(Roles = "Administration")]
        public IActionResult Index()
        {
            List<StudentTag> studentTags = context.StudentTags.ToList();
            return View(studentTags);
        }

        [Authorize(Roles = "Administration")]
        public IActionResult Add()
        {

            StudentTag studentTag = new StudentTag();
            return View(studentTag);

        }

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public IActionResult Add(StudentTag studentTag)
        {
            if (ModelState.IsValid)
            {
                context.StudentTags.Add(studentTag);
                context.SaveChanges();
                return Redirect("/StudentTag/");
            }

            return View("Add", studentTag);
        }


        [Authorize(Roles = "Administration")]
        public IActionResult Delete()
        {
            List<StudentTag> studentTags = context.StudentTags.ToList();
            return View(studentTags);
        }

        [HttpPost]
        [Authorize(Roles = "Administration")]
        public IActionResult Delete(int[] studentTagIds)
        {
            foreach(int studentTagId in studentTagIds)
            {
                StudentTag theStudentTag = context.StudentTags.Find(studentTagId);
                context.StudentTags.Remove(theStudentTag);
            }
            context.SaveChanges();

            return Redirect("/StudentTag");
        }

        public IActionResult Detail(int id)
        {
            List<TaskTag> taskTags = context.TaskTags
                .Where(et => et.StudentTagId == id)
                .Include(et => et.StudentTask)
                .Include(et => et.StudentTag)
                .ToList();

            return View(taskTags);
        }


    }
}
