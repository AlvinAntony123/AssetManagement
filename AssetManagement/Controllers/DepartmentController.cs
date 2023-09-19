using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _context;

        public DepartmentController(IDepartmentService context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetDepartments());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]

        public IActionResult AddItem(DepartmentDTO dtoItem)
        {
            try
            {
                _context.AddDepartment(dtoItem);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
