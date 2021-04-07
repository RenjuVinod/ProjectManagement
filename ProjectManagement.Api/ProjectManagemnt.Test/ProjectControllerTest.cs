using Moq;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Threading.Tasks;
using Xunit;


namespace ProjectManagemnt.Test
{
    public class ProjectControllerTest
    {
        private FakeDbSet<Project> project;
        Mock<IBaseRepository<Project>> mockObject;

        public ProjectControllerTest()
        {
            mockObject = new Mock<IBaseRepository<Project>>();
            var testProject1 = new Project { ID = 10, Name = "Project1", CreatedOn = DateTime.Now, Detail = "This is project 1" };
            mockObject.Object.Add(testProject1);
        }

        [Fact]
        public void GetProject_Test_ReturnSuccess()
        {
            project = new FakeDbSet<Project>();
            var testProject1 = new Project { Name = "Project1", CreatedOn = DateTime.Now, Detail = "This is project 1" };
            var testProject2 = new Project { Name = "Project2", CreatedOn = DateTime.Now, Detail = "This is project 2" };
            project.Add(testProject1);
            project.Add(testProject2);

            mockObject.Setup(m => m.Get()).Returns(project);
            ProjectController projectController = new ProjectController(mockObject.Object);
            var result = projectController.Get();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetProjectById_Test_ReturnSuccess()
        {
            var testProject1 = new Project { ID = 1, Name = "Project1", CreatedOn = DateTime.Now, Detail = "This is project 1" };

            mockObject.Setup(m => m.Get(1)).Returns(testProject1);
            ProjectController projectController = new ProjectController(mockObject.Object);
            var result = projectController.Get(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void AddProject_Test_ReturnSuccess()
        {
            var projectAdd = new Project { Name = "Project3", CreatedOn = DateTime.Now, Detail = "This is project 3" };

            mockObject.Setup(m => m.Add(projectAdd)).Returns(() => Task<Project>.FromResult(projectAdd));
            ProjectController projectController = new ProjectController(mockObject.Object);
            var result = projectController.Add(projectAdd);
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateProject_Test_ReturnSuccess()
        {
            var projectUpdate = new Project { Name = "Project3", CreatedOn = DateTime.Now, Detail = "This is project 3" };

            mockObject.Setup(m => m.Update(projectUpdate)).Returns(() => Task<Project>.FromResult(projectUpdate));
            ProjectController projectController = new ProjectController(mockObject.Object);
            var result = projectController.Put(projectUpdate);
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteProject_Test_ReturnSuccess()
        {
            mockObject.Setup(m => m.Delete(1)).Returns(() => Task<int>.FromResult(1));
            ProjectController projectController = new ProjectController(mockObject.Object);
            var result = projectController.Delete(1);
            Assert.NotNull(result);
        }

    }
}
