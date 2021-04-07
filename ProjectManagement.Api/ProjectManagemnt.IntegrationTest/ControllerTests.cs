using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagemnt.IntegrationTest
{
    public class ControllerTests : IClassFixture<ApiWebApplicationFactory<ProjectManagement.Api.Startup>>
    {
        public HttpClient Client { get; }

        public ControllerTests(ApiWebApplicationFactory<ProjectManagement.Api.Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_UserById_ReturnSuccess()
        {
            //Act
            var response = await Client.GetAsync("/api/User/1");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<User>(stringResponse);

            //Asert
            Assert.Equal(1, users.ID);
        }

        [Fact]
        public async Task Get_User_ReturnSuccess()
        {
            //Act
            var response = await Client.GetAsync("/api/User");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(stringResponse);

            //Asert
            Assert.True(users.Count() > 0);
        }

        [Fact]
        public async Task Add_User_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/User/");
            User postBody = new User()
            {
                FirstName = "renju",
                LastName = "vinod",
                Email = "renju@gmail.com",
                Password = "pass1234",
                ID=123
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);

            //Assert
            Assert.Equal("renju", user.FirstName);            
        }

        [Fact]
        public async Task Update_User_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/User/");
            User postBody = new User()
            {
                FirstName = "Arjun",
                LastName = "vinod",
                Email = "arjun.vinod@gmail.com",
                Password = "pass1234",
                ID = 3
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);

            //Assert
            Assert.Equal("Arjun", user.FirstName);
        }

        [Fact]
        public async Task Delete_User_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "/api/User?id=2");
            
            //Act
            var response = await Client.SendAsync(postRequest);
            
            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Login_User_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/User/Login");
            User postBody = new User()
            {
                ID = 1,
                FirstName = "Test",
                LastName = "User1",
                Email = "testuser1@test.com",
                Password = "test123"
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        #region Task Controller

        [Fact]
        public async Task Get_TaskById_ReturnSuccess()
        {
            //Act
            var response = await Client.GetAsync("/api/Tasks/1");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Tasks>(stringResponse);

            //Asert
            Assert.Equal(1, tasks.ID);
        }

        [Fact]
        public async Task Get_Task_ReturnSuccess()
        {
            //Act
            var response = await Client.GetAsync("/api/Tasks");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var Tasks = JsonConvert.DeserializeObject<List<Task>>(stringResponse);

            //Asert
            Assert.True(Tasks.Count() > 0);
        }

        [Fact]
        public async Task Add_Task_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Tasks/");
            Tasks postBody = new Tasks()
            {
                ID = 5,
                AssignedToUserID = 2,
                CreatedOn = DateTime.Now,
                Detail = "This is Task3",
                ProjectID = 2,
                Status = ProjectManagement.Entities.Enums.TaskStatus.InProgress
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Tasks>(responseString);

            //Assert
            Assert.Equal("This is Task3", tasks.Detail);
        }

        [Fact]
        public async Task Update_Task_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/Tasks/");
            Tasks postBody = new Tasks()
            {
                ID = 1,
                AssignedToUserID = 2,
                CreatedOn = DateTime.Now,
                Detail = "This is Task3",
                ProjectID = 2,
                Status = ProjectManagement.Entities.Enums.TaskStatus.InProgress
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Tasks>(responseString);

            //Assert
            Assert.Equal("This is Task3", tasks.Detail);
        }

        [Fact]
        public async Task Delete_Task_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "/api/Tasks?id=2");

            //Act
            var response = await Client.SendAsync(postRequest);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        #endregion

        #region Project

        [Fact]
        public async Task Get_ProjectById_ReturnSuccess()
        {
            //Act
            var response = await Client.GetAsync("/api/Project/1");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(stringResponse);

            //Asert
            Assert.Equal(1, project.ID);
        }

        [Fact]
        public async Task Get_Project_ReturnSuccess()
        {
            //Act
            var response = await Client.GetAsync("/api/Project");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<List<Project>>(stringResponse);

            //Asert
            Assert.True(project.Count() > 0);
        }

        [Fact]
        public async Task Add_Project_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Project/");
            Project postBody = new Project()
            {
                ID = 3,
                Name = "TestProject3",
                CreatedOn = DateTime.Now,
                Detail = "This is Test project 3"
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(responseString);

            //Assert
            Assert.Equal("TestProject3", project.Name);
        }

        [Fact]
        public async Task Update_Project_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/Project/");
            Project postBody = new Project()
            {
                ID = 1,
                Name = "Main Test Project",
                CreatedOn = DateTime.Now,
                Detail = "This is Main Test project"
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(responseString);

            //Assert
            Assert.Equal("Main Test Project", project.Name);
        }

        [Fact]
        public async Task Delete_Project_ReturnSuccess()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "/api/Project?id=2");

            //Act
            var response = await Client.SendAsync(postRequest);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        #endregion
    }

}
