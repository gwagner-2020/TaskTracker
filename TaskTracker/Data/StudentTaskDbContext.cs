using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    public class StudentTaskDbContext : DbContext
    {
        public DbSet<StudentTask> StudentTasks { get; set; }

        public StudentTaskDbContext(DbContextOptions<StudentTaskDbContext> options) : base(options) { }
    }
}
