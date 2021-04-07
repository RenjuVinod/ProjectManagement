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
                ID=1,
                FirstName = "Test",
                LastName = "User1",
                Email = "testuser1@test.com",
                Password = "test123"
            };
            User.Add(testUser1);
            User testUser2 = new User
            {
                ID=2,
                FirstName = "Test",
                LastName = "User2",
                Email = "testuser2@gmail.com",
                Password = "test123"
            };
            User.Add(testUser2);
            User testUser3 = new User
            {
                ID = 3,
                FirstName = "Test",
                LastName = "User3",
                Email = "testuser2@gmail.com",
                Password = "test123"
            };
            User.Add(testUser3);

            Project testProject1 = new Project { ID=1,Name = "TestProject1", CreatedOn = DateTime.Now, Detail = "This is Test project 1" };
            Project testProject2 = new Project { ID=2, Name = "TestProject2", CreatedOn = DateTime.Now, Detail = "This is Test project 2" };

            Project.Add(testProject1);
            Project.Add(testProject2);

            Tasks tasks1 = new Tasks { ID = 1, AssignedToUserID = 1, CreatedOn = DateTime.Now, Detail = "This is Task1", ProjectID = 1, Status = Entities.Enums.TaskStatus.New };
            Tasks tasks2 = new Tasks { ID = 2, AssignedToUserID = 1, CreatedOn = DateTime.Now, Detail = "This is Task2", ProjectID = 1, Status = Entities.Enums.TaskStatus.InProgress };
            Tasks tasks3 = new Tasks { ID =3, AssignedToUserID = 2, CreatedOn = DateTime.Now, Detail = "This is Task1", ProjectID = 2, Status = Entities.Enums.TaskStatus.New };
            Tasks tasks4 = new Tasks { ID = 4, AssignedToUserID = 2, CreatedOn = DateTime.Now, Detail = "This is Task2", ProjectID = 2, Status = Entities.Enums.TaskStatus.InProgress };

            Task.Add(tasks1);
            Task.Add(tasks2);
            Task.Add(tasks3);
            Task.Add(tasks4);

            this.SaveChanges();
        }
        public DbSet<User> User { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Tasks> Task { get; set; }
    }
}
