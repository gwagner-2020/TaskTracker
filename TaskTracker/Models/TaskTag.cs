using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class TaskTag
    {
        public int StudentTaskId { get; set; }
        public StudentTask StudentTask { get; set; }


        public int StudentTagId { get; set; }
        public StudentTag StudentTag { get; set; }

        public TaskTag()
        {

        }
    }
}
