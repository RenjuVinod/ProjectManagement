using Moq;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagemnt.Test
{
    public class TasksControllerTest
    {
        private FakeDbSet<Tasks> tasks;
        Mock<IBaseRepository<Tasks>> mockObject;

        public TasksControllerTest()
        {
            mockObject = new Mock<IBaseRepository<Tasks>>();
            var testTasks1 = new Tasks { ID = 1, AssignedToUserID = 1, ProjectID = 1, Detail = "Test Task 1", CreatedOn = DateTime.Now, Status = ProjectManagement.Entities.Enums.TaskStatus.New };
            mockObject.Object.Add(testTasks1);
        }

        [Fact]
        public void GetTasks_Test_ReturnSuccess()
        {
            tasks = new FakeDbSet<Tasks>();
            var testTasks1 = new Tasks { ID = 1, AssignedToUserID = 1, ProjectID = 1, Detail = "Test Task 1", CreatedOn = DateTime.Now, Status = ProjectManagement.Entities.Enums.TaskStatus.New };
            var testTasks2 = new Tasks { ID = 2, AssignedToUserID = 1, ProjectID = 1, Detail = "Test Task 2", CreatedOn = DateTime.Now, Status = ProjectManagement.Entities.Enums.TaskStatus.New };
            tasks.Add(testTasks1);
            tasks.Add(testTasks2);

            mockObject.Setup(m => m.Get()).Returns(tasks);
            TasksController tasksController = new TasksController(mockObject.Object);
            var result = tasksController.Get();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetTaskById_Test_ReturnSuccess()
        {
            var testTasks1 = new Tasks { ID = 1, AssignedToUserID = 1, ProjectID = 1, Detail = "Test Task 1", CreatedOn = DateTime.Now, Status = ProjectManagement.Entities.Enums.TaskStatus.New };

            mockObject.Setup(m => m.Get(1)).Returns(testTasks1);
            TasksController tasksController = new TasksController(mockObject.Object);
            var result = tasksController.Get(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void AddTasks_Test_ReturnSuccess()
        {
            var tasksAdd = new Tasks { ID = 5, AssignedToUserID = 1, ProjectID = 1, Detail = "Test Task 1", CreatedOn = DateTime.Now, Status = ProjectManagement.Entities.Enums.TaskStatus.New };

            mockObject.Setup(m => m.Add(tasksAdd)).Returns(() => Task<Tasks>.FromResult(tasksAdd));
            TasksController tasksController = new TasksController(mockObject.Object);
            var result = tasksController.Add(tasksAdd);
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateTasks_Test_ReturnSuccess()
        {
            var tasksUpdate = new Tasks { Detail = "Test Task 1", CreatedOn = DateTime.Now, Status = ProjectManagement.Entities.Enums.TaskStatus.New };

            mockObject.Setup(m => m.Update(tasksUpdate)).Returns(() => Task<Tasks>.FromResult(tasksUpdate));
            TasksController tasksController = new TasksController(mockObject.Object);
            var result = tasksController.Put(tasksUpdate);
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteTasks_Test_ReturnSuccess()
        {
            mockObject.Setup(m => m.Delete(1)).Returns(() => Task<int>.FromResult(1));
            TasksController tasksController = new TasksController(mockObject.Object);
            var result = tasksController.Delete(1);
            Assert.NotNull(result);
        }

    }
}