using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    public class StudentTaskData
    {
        //store tasks
        private static Dictionary<int, StudentTask> studentTasks = new Dictionary<int, StudentTask>();

        //add tasks
        public static void Add(StudentTask newStudentTask)
        {
            studentTasks.Add(newStudentTask.Id, newStudentTask);
        }

        //retrieve tasks
        public static IEnumerable<StudentTask> GetAll()
        {
            return studentTasks.Values;
        }

        //retrieve a single task
        public static StudentTask GetById(int id)
        {
            return studentTasks[id];
        }

        //remove a task
        public static void Remove(int id)
        {
            studentTasks.Remove(id);
        }

    }
}
