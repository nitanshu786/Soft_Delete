using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeApi : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeApi(IEmployee employee)
        {
            _employee = employee;
        }
        [Route("get")]
        [HttpGet]
        public async Task<IEnumerable<Employee>>  GetAll()
        {
            return await _employee.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employee.GetbyId(id);
        }
        [Route("save")]
        [HttpPost]
        public async Task<Employee> Post([FromBody] Employee employee)
        {
            await _employee.AddEmploye(employee);
            return (employee);
        }
       
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _employee.DeleteEmploye(id);
        }
        [Route("update")]
        [HttpPut]
        public Task Update([FromBody] Employee employee)
        {
            return _employee.UpdateEmploye(employee);

        }
    }
}
