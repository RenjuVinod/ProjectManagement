using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Interfaces;

namespace ProjectManagement.Api.Controllers
{
    public class BaseController<T> : ControllerBase where T : class
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
        public IActionResult Add([FromBody] T value)
        {
            var result = _baseRepository.Add(value);
            if (result != null)
                return Ok(result);
            else
                return StatusCode(500);
        }

        [HttpPut]
        public IActionResult Put([FromBody] T value)
        {
            var result = _baseRepository.Update(value);
            if (result != null)
                return Ok(result);
            else
                return StatusCode(500);
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            _baseRepository.Delete(id);
            return Ok();
        }

    }
}
