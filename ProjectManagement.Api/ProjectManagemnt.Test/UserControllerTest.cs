using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using ProjectManagement.Api.Controllers;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagemnt.Test
{
    public class UserControllerTest
    {
        private FakeDbSet<User> Users;
        Mock<IUserRepository> mockObject;

        public UserControllerTest()
        {
            mockObject = new Mock<IUserRepository>();
        }

        [Fact]
        public void GetUsers_Test_ReturnSuccess()
        {
            Users = new FakeDbSet<User>();
            User testUser1 = new User
            {
                ID = 1,
                FirstName = "Test",
                LastName = "User1",
                Email = "testuser1@test.com",
                Password = "test123"
            };
            Users.Add(testUser1);
            User testUser2 = new User
            {
                ID = 2,
                FirstName = "Test",
                LastName = "User2",
                Email = "testuser2@gmail.com",
                Password = "test123"
            };
            Users.Add(testUser2);

            mockObject.Setup(m => m.Get()).Returns(Users);
            UserController userController = new UserController(mockObject.Object);
            var result = userController.Get();
            Assert.NotNull(result);
        }
        [Fact]
        public void GetUserById_Test_ReturnSuccess()
        {
            var testUser1 = new User
            {
                FirstName = "renju",
                LastName = "vinod",
                Email = "renju@gmail.com",
                Password = "pass1234",
                ID = 1
            };

            mockObject.Setup(m => m.Get(1)).Returns(testUser1);
            UserController userController = new UserController(mockObject.Object);
            var result = userController.Get(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void AddUsers_Test_ReturnSuccess()
        {
            var userAdd = new User
            {
                FirstName = "renju",
                LastName = "vinod",
                Email = "renju@gmail.com",
                Password = "pass1234",
                ID = 123
            };
            mockObject.Setup(m => m.Add(userAdd)).Returns(() => Task<User>.FromResult(userAdd));
            UserController userController = new UserController(mockObject.Object);
            var result = userController.Add(userAdd);
            Assert.NotNull(result);
        }

        [Fact]
        public void LoginUsers_Test_ReturnSuccess()
        {
            var userAdd = new User
            {
                ID = 1,
                FirstName = "Test",
                LastName = "User1",
                Email = "testuser1@test.com",
                Password = "test123"
            };
            mockObject.Setup(m => m.Login(userAdd)).Returns(userAdd);
            UserController userController = new UserController(mockObject.Object);
            var result = userController.Login(userAdd);
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(StatusCodes.Status200OK, statusCodeResult.StatusCode);
        }

        [Fact]
        public void UpdateUsers_Test_ReturnSuccess()
        {
            var user = new User
            {
                FirstName = "Arjun",
                LastName = "vinod",
                Email = "arjun.vinod@gmail.com",
                Password = "pass1234",
                ID = 3
            };

            mockObject.Setup(m => m.Update(user)).Returns(() => Task<User>.FromResult(user));
            UserController userController = new UserController(mockObject.Object);
            var result = userController.Put(user);
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteUsers_Test_ReturnSuccess()
        {
            mockObject.Setup(m => m.Delete(1)).Returns(() => Task<int>.FromResult(1));
            UserController userController = new UserController(mockObject.Object);
            var result = userController.Delete(1);
            Assert.NotNull(result);
        }

    }
}
