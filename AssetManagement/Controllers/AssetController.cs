using AssetManagementAPI.DTO;
using AssetManagementAPI.Exceptions;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : Controller
    {
        private readonly IAssetService _context;

        public AssetController(IAssetService context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetAssets());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]

        public IActionResult AddItem(AssetDTO dtoItem)
        {
            try
            {
                var id = _context.AddAssets(dtoItem);
                return Ok(id);
            }catch(ObjectAlreadyExistException ex)
            {
                return Conflict(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
