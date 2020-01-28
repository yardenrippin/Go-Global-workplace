using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_workeplae.Data;
using My_workeplae.Helpers;
using My_workeplae.Modles;

namespace My_workeplae.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepositoey _repo;
        private readonly IMapper _maapper;
        public EmployeesController(IEmployeesRepositoey repo, IMapper mapper)
        {
            _maapper = mapper;
            _repo = repo;
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmpployee(int id)
        {
            if (id < 0)
            return BadRequest();

            var employe = await _repo.GetEmployee(id);

            return Ok(employe);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpployees()
        {
            var employe = await _repo.GetAllEmployees();

            return Ok(employe);
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Deleteemployee(int id)
        {
            await _repo.Delete(id);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception(" user" + id + "failed on delete");
        }
        [HttpPost("Add")]
        public async Task<IActionResult> add([FromBody] Employees employee)
        {
            _repo.Add(employee);

            if (await _repo.SaveAll())
                return Ok();

            return NoContent();
        }

        [HttpGet("byfirstname")]
        public async Task<IActionResult> firstname(string firstname)
        {
            if (string.IsNullOrEmpty(firstname))
            {
                return BadRequest();
            }
            var employees = await _repo.GetEmployeesByFirsName(firstname);

            return Ok(employees);
        }

        [HttpGet("bylastname")]
        public async Task<IActionResult> lastname (string lastname)
        {
            if (string.IsNullOrEmpty(lastname))
            {
                return BadRequest();
            }

            var employees = await _repo.GetEmployeesByLastName(lastname);

            return Ok(employees);
        }

        [HttpGet("byid")]
        public async Task<IActionResult> byid (string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var employees = await _repo.GetEmployeesByIdentityCard(id);

            return Ok(employees);
        }
        [HttpPost("update")]
        public async Task<IActionResult> update ([FromBody] EmployeesforUpdateDto employees)
        {
            

            if (employees.ID < 0)
                return BadRequest();

            var employe = await _repo.GetEmployee(employees.ID);

            _maapper.Map(employees, employe);

            if (await _repo.SaveAll())
                return Ok();

            return NoContent();
        }
    }
}