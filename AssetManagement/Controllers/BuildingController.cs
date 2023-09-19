using AssetManagementAPI.DTO;
using AssetManagementAPI.Exceptions;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _context;

        public BuildingController(IBuildingService context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetBuildings());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]

        public IActionResult AddItem(BuildingDTO buildingDTO)
        {
            try
            {
                var id = _context.AddBuildings(buildingDTO);
                return Ok(id);
            }catch(SameAbbreviationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
