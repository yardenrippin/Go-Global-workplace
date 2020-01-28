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

            return Ok(managers);
        }

        [HttpGet("employe")]
        public async Task<IActionResult> Getemploye(int id)
        {

            var employees = await _repo.Getemployees(id);

            return Ok(employees);

        }
        [HttpPost("Add")]
        public async Task<IActionResult> add([FromBody] Managers manager)
        {
            _repo.Add(manager);

            if (await _repo.SaveAll())
                return Ok();

            return NoContent();
        }

    }
}