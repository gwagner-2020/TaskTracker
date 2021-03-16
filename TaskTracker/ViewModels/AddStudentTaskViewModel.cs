using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.ViewModels
{
    public class AddStudentTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        //public DateTime SubmitDate { get; set; }
        //public DateTime ApproveDate { get; set; }
    }
}
