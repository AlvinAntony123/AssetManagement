using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService _context;

        public CityController(ICityService context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetCities());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult AddItem(CityDTO cityDTO)
        {
            try
            {
                var id = _context.AddCities(cityDTO);
                return Ok(id);
            }catch (Exception ex)
            {
                return NoContent();
            }
        }
    }
}
