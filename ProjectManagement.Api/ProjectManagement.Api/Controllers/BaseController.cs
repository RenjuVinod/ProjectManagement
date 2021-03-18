using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseController(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _baseRepository.Get();
            if (result != null)
                return Ok(result);
            else
                return StatusCode(500);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var result = _baseRepository.Get(id);
            if (result != null)
                return Ok(result);
            else
                return StatusCode(500);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T value)
        {
            var result = await _baseRepository.Add(value);
            if (result != null)
                return Ok(result);
            else
                return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] T value)
        {
            var result = await _baseRepository.Update(value);
            if (result != null)
                return Ok(result);
            else
                return StatusCode(500);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var result = _baseRepository.Get(id);
            if (result == null)
                return StatusCode(500);

            await _baseRepository.Delete(id);
            return Ok();
        }
    }
}
