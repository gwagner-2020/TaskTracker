using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    public class StudentTaskDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<StudentTask> StudentTasks { get; set; }
        public DbSet<StudentTag> StudentTags { get; set; }

        public DbSet<TaskTag> TaskTags { get; set; }

        public StudentTaskDbContext(DbContextOptions<StudentTaskDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskTag>()
                .HasKey(et => new { et.StudentTaskId, et.StudentTagId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
