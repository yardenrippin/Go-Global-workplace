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
           
            if (id <= 0)
            return BadRequest("this employee dont exist on data");
          
            var employe = await _repo.GetEmployee(id);

            if (employe == null)
                return BadRequest("server error canot found empployee");

            var employeeTOReturn = _maapper.Map<EmployeesforList>(employe);

            return Ok(employeeTOReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpployees()
        {
            
            var employees = await _repo.GetAllEmployees();

            if (employees == null || employees.Count()<=0)
                return BadRequest("list cannot be found");

            var employeesTOReturn = _maapper.Map<IEnumerable<EmployeesforList>>(employees);

            return Ok(employeesTOReturn);
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Deleteemployee(int id)
        {
            if (id <= 0)
                return BadRequest("this employee dont exist on data");

            await _repo.Delete(id);

            if (await _repo.SaveAll())
                return Ok();

            throw new Exception(" user" + id + "failed on delete");
        }
        
        [HttpPost("Add")]
     
        public async Task<IActionResult> Add([FromBody]Employees employee)
        {

            if (employee == null)
                return BadRequest("server cannot add null employee , check all fields ");

            _repo.Add(employee);

            if (await _repo.SaveAll())
                return Ok();

            throw new Exception(" employee" + employee.FirstName + " failed on add ");
        }

        [HttpGet("byfirstname")]
        public async Task<IActionResult> Firstname(string firstname)
        {
            if (string.IsNullOrEmpty(firstname))
          
                return BadRequest("first namr cannot be null");
          
            var employees = await _repo.GetEmployeesByFirsName(firstname);

            if (employees==null || employees.Count()<=0)
                return BadRequest(" employee firstname " + firstname + " dont Exists ");


            var employeesTOReturn = _maapper.Map<IEnumerable<EmployeesforList>>(employees);

            

            return Ok(employeesTOReturn);
        }

        [HttpGet("bylastname")]
        public async Task<IActionResult> Lastname (string lastname)
        {
            if (string.IsNullOrEmpty(lastname))

                return BadRequest("last name cannot be null");

            var employees = await _repo.GetEmployeesByLastName(lastname);

            if (employees == null || employees.Count() <= 0)
                return BadRequest(" employee lastname " + lastname + "dont Exists");


            var employeesTOReturn = _maapper.Map<IEnumerable<EmployeesforList>>(employees);



            return Ok(employeesTOReturn);
        }

        [HttpGet("byid")]
        public async Task<IActionResult> byid (string id)
        {
            if (string.IsNullOrEmpty(id))

                return BadRequest("IdentityCard cannot be null");

            var employees = await _repo.GetEmployeesByIdentityCard(id);

            if (employees == null || employees.Count() <= 0)
                return BadRequest(" employee IdentityCard " + id + "dont Exists");


            var employeesTOReturn = _maapper.Map<IEnumerable<EmployeesforList>>(employees);



            return Ok(employeesTOReturn);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update ([FromBody] EmployeesforUpdateDto employee_update)
        {
            

            if (employee_update.ID < 0 || employee_update == null)
                return BadRequest("failed on update");

            employee_update.Last_Update = DateTime.Now;


            var employee = await _repo.GetEmployee(employee_update.ID);


            if (employee_update.Last_Update>= employee.Last_Update&& employee_update.ID== employee.ID)
            {
                _maapper.Map(employee_update, employee);




                if (await _repo.SaveAll())
                    return Ok();
            }
            return NoContent();
           

            


        }
    }
}