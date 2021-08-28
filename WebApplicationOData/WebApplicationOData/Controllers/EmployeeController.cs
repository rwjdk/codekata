using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApplicationOData.Models;
using WebApplicationOData.Services;

namespace WebApplicationOData.Controllers
{
    [Route("emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpGet("GetByKey")]
        [EnableQuery]
        public IActionResult Get(string key)
        {
            var firstOrDefault = _employeeService.GetEmployees().FirstOrDefault(x => x.Id.ToString() == key);
            return Ok(firstOrDefault);
        }
        /*
        [HttpPost]
        [EnableQuery]
        public IActionResult Post([FromBody] EmployeeModel postObject)
        {
            return Ok();
        }*/
    }
}