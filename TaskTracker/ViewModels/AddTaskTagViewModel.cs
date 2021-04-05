using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Models;

namespace TaskTracker.ViewModels
{
    public class AddTaskTagViewModel
    {
        public int StudentTaskId { get; set; }
        public StudentTask StudentTask { get; set; }

        public List<SelectListItem> StudentTags { get; set; }

        public int StudentTagId { get; set; }

        public AddTaskTagViewModel(StudentTask studentTask, List<StudentTag> possibleTags)
        {
            StudentTags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                StudentTags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.StudentName

                });
            }

            StudentTask = studentTask;
        }

        public AddTaskTagViewModel() { }
    }
}
