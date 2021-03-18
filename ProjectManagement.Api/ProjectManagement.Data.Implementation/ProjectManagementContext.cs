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

        public void AddTestData()
        {
            User testUser1 = new User
            {
                FirstName = "Test",
                LastName = "User1",
                Email = "testuser1@test.com",
                Password = "test123"
            };
            User.Add(testUser1);
            User testUser2 = new User
            {
                FirstName = "Test",
                LastName = "User2",
                Email = "testuser2@gmail.com",
                Password = "test123"
            };
            User.Add(testUser2);

            Project testProject1 = new Project { Name = "TestProject1", CreatedOn = DateTime.Now, Detail = "This is Test project 1" };
            Project testProject2 = new Project { Name = "TestProject2", CreatedOn = DateTime.Now, Detail = "This is Test project 2" };

            Project.Add(testProject1);
            Project.Add(testProject2);
            this.SaveChanges();
        }
        public DbSet<User> User { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Tasks> Task { get; set; }
    }
}
