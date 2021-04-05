using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class StudentTagController : Controller
    {
        private StudentTaskDbContext context;
        private IAuthorizationService authorizationService;
        private UserManager<IdentityUser> userManager;

        public StudentTagController(StudentTaskDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<StudentTag> studentTags = context.StudentTags.ToList();
            return View(studentTags);
        }

        public IActionResult Add()
        {

            StudentTag studentTag = new StudentTag();
            return View(studentTag);

        }

        [HttpPost]
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

    }  
}
