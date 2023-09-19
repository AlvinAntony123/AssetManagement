using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _context;

        public EmployeeController(IEmployeeService context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetEmployees());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult AddItem(EmployeeDTO dtomItem)
        {
            try
            {
                _context.AddEmployees(dtomItem);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
