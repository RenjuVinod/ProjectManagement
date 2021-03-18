using Microsoft.EntityFrameworkCore;
using ProjectManagement.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Data.Implementation
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Tasks> Task { get; set; }
    }
}
