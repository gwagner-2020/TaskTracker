﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Models;

namespace TaskTracker.ViewModels
{
    public class DuplicateStudentTaskViewModel
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public DuplicateStudentTaskViewModel(StudentTask studentTask)
        {
            this.TaskId = studentTask.Id;
            this.Name = studentTask.Name;
            this.Description = studentTask.Description;
            //this.DueDate = studentTask.DueDate;
            //this.SubmitDate = studentTask.SubmitDate;
            //this.ApproveDate = studentTask.ApproveDate;
            //this.Approved = studentTask.Approved;
        }
    } 
 }