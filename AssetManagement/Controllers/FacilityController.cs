using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : Controller
    {
        private readonly IFacilityService _context;

        public FacilityController(IFacilityService context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult Get()
        {
            try
            {
                return Ok(_context.GetFacilities());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpPost]

        public ActionResult AddItem(FacilityDTO facilityDTO)
        {
            try
            {
                _context.AddFacilities(facilityDTO);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
