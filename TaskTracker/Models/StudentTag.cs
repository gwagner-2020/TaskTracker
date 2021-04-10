using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class StudentTag
    {
        public int Id { get; set; }

        public string StudentName { get; set; }

        public StudentTag(string studentName)
        {
            this.StudentName = studentName;
        }

        public StudentTag() { }

    }
}
