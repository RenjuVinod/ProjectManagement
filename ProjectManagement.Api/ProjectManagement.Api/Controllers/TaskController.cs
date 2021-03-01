using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Tasks")]
    public class TasksController : BaseController<Tasks>
    {
        public TasksController(IBaseRepository<Tasks> baseRepository) : base(baseRepository)
        {

        }
    }
}
