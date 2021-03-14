using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class StudentTask
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Id { get; set; }
        private static int nextId = 1;

        public StudentTask()
        {
            Id = nextId;
            nextId++;
        }
        
        public StudentTask(string name, string description) : this()
        {
            this.Name = name;
            this.Description = description;
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
