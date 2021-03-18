using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectManagement.Data.Implementation;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;

namespace ProjectManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen();
            services.AddDbContext<ProjectManagementContext>(opt =>
            {
                opt.UseInMemoryDatabase("ProjectManagement");
            });
            services.AddTransient(typeof(IBaseRepository<Project>), typeof(BaseRepository<Project>));
            services.AddTransient(typeof(IBaseRepository<User>), typeof(BaseRepository<User>));
            services.AddTransient(typeof(IBaseRepository<Tasks>), typeof(BaseRepository<Tasks>));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("v1/swagger.json", "Project Management V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //var context = app.ApplicationServices.GetService<ProjectManagementContext>();
            //AddTestData(context);

        }


        #region Private Methods

        public void AddTestData(ProjectManagementContext context)
        {
            User testUser1 = new User
            {
                FirstName = "Test",
                LastName = "User1",
                Email = "testuser1@test.com",
                Password = "test123"
            };
            context.User.Add(testUser1);
            User testUser2 = new User
            {
                FirstName = "Test",
                LastName = "User2",
                Email = "testuser2@gmail.com",
                Password = "test123"
            };
            context.User.Add(testUser2);

            Project testProject1 = new Project { Name = "TestProject1", CreatedOn = DateTime.Now, Detail = "This is Test project 1" };
            Project testProject2 = new Project { Name = "TestProject2", CreatedOn = DateTime.Now, Detail = "This is Test project 2" };

            context.Project.Add(testProject1);
            context.Project.Add(testProject2);
            context.SaveChanges();
        }

        #endregion
    }
}
