using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Data.Implementation;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagemnt.IntegrationTest
{
    public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<ProjectManagement.Api.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<ProjectManagementContext>(options =>
                {
                    options.UseInMemoryDatabase("ProjectManagementTest");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<ProjectManagementContext>();

                    appDb.Database.EnsureCreated();

                    appDb.AddTestData();
                }
            });
        }
    }
}
