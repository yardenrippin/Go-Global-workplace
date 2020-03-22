using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_workeplae.Data;
using My_workeplae.Modles;

namespace My_workeplae.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagers _repo;

        public ManagersController(IManagers repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenegers()
        {
            var managers = await _repo.GetManagers();

            if (managers == null || managers.Count() <= 0)
                return BadRequest ("there is no managers to show");
            return Ok(managers);
        }

        [HttpGet("employe")]
        public async Task<IActionResult> Getemployees(int id)
        {
            if (id <= 0)
                return BadRequest("cnot get list");

            var employees = await _repo.Getemployees(id);

            if (employees == null || employees.Count()<=0)
                return BadRequest("this manager Donot Have any Subordinate employees");

            return Ok(employees);

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Managers manager)
        {
      
            if (manager == null)
                return BadRequest("manager failed on add ");
            _repo.Add(manager);

            if (await _repo.SaveAll())
                return Ok();

            throw new Exception(" manager" + manager.FirstName + " failed on add ");
        }

    }
}