using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class StudentTask
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApproveDate { get; set; }

        public Boolean Approved { get; set; }
        
        public string UserId { get; set; }
        public int Id { get; set; }
        //private static int nextId = 1;

        public StudentTask()
        {
            //Id = nextId;
            //nextId++;
        }
        
        public StudentTask(string name, string description, DateTime dueDate) //: this()
        {
            this.Name = name;
            this.Description = description;
            this.DueDate = dueDate;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is StudentTask @studentTask &&
                Id == studentTask.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
