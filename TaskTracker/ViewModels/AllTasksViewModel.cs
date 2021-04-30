using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Models;

namespace TaskTracker.ViewModels
{
    public class AllTasksViewModel
    {
        public StudentTask StudentTask { get; set; }
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApproveDate { get; set; }

        public Boolean Approved { get; set; }

        public TaskTag TaskTag { get; set; }
        public int StudentTagId { get; set; }

        public int StudentTaskId { get; set; }

        public string StudentNamesText { get; set; }

        List<TaskTag> TaskTags { get; set; }
        List<StudentTask> StudentTasks { get; set; }

        public AllTasksViewModel(List<StudentTask> theStudentTasks, List<TaskTag> theTaskTags)
        {
            this.StudentTasks = theStudentTasks;
            this.TaskTags = theTaskTags;
            
            for (var i = 0; i < StudentTasks.Count; i++)
            {
                this.TaskId = StudentTasks[i].Id;
                this.Name = StudentTasks[i].Name;
                this.Description = StudentTasks[i].Description;
                this.DueDate = StudentTasks[i].DueDate;
                this.SubmitDate = StudentTasks[i].SubmitDate;
                this.ApproveDate = StudentTasks[i].ApproveDate;
                this.Approved = StudentTasks[i].Approved;
            }

            for (var i = 0; i < TaskTags.Count; i++)
            {
                this.StudentTaskId = TaskTags[i].StudentTaskId;
                this.StudentTagId = TaskTags[i].StudentTagId;
            }

        //public AllTasksViewModel(StudentTask studentTask, List<TaskTag> taskTags)
        //{
        //    this.TaskId = studentTask.Id;
        //    //this.StudentTagId = studentTag.Id;
        //    //this.StudentTaskId = studentTask.Id;
        //    this.Name = studentTask.Name;
        //    this.Description = studentTask.Description;
        //    this.DueDate = studentTask.DueDate;
        //    this.SubmitDate = studentTask.SubmitDate;
        //    this.ApproveDate = studentTask.ApproveDate;
        //    this.Approved = studentTask.Approved;

        //    this.StudentNamesText = "";

        //    for (var i = 0; i < taskTags.Count; i++)
        //    {
        //        StudentNamesText += taskTags[i].StudentTag.StudentName;

        //        if (i < taskTags.Count - 1)
        //        {
        //            StudentNamesText += ", ";
        //        }

        //    }
        //}

        //public AllTasksViewModel() { }
        }
    }
}
