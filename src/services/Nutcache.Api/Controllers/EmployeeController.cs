using Microsoft.AspNetCore.Mvc;
using Nutcache.Application.Contracts;
using Nutcache.Application.Models;

namespace Nutcache.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        protected readonly IApplicationServices<EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto, ListEmployeeDto> _applicationServices;

        public EmployeeController(IApplicationServices<EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto, ListEmployeeDto> applicationServices)
        {
            _applicationServices = applicationServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var response = await _applicationServices.Add(createEmployeeDto);
            if (response.Ok) return Created("", response.Entity);
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var response = await _applicationServices.Update(updateEmployeeDto);
            if (response.Ok) return Ok(response.Entity);
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _applicationServices.Delete(id);
            if (response.Ok) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _applicationServices.Get(id);
            if (employee == null) return NoContent();
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _applicationServices.Get();
            if(employees == null) return NoContent();
            return Ok(employees);
        }
    }
}
