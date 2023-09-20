using AssetManagementAPI.DTO;
using AssetManagementAPI.Exceptions;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : Controller
    {
        private readonly ICabinService _context;

        public CabinController(ICabinService context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetCabins());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpPost]

        public IActionResult AddItem(int count, int facilityId, int currCount)
        {
            try
            {
                _context.AddCabin(count, facilityId, currCount);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult Allocate(int id, int empId)
        {
            try
            {
                if(empId != 0)
                    _context.AllocateCabin(id, empId);
                else
                    _context.DeallocateCabin(id);

                return Ok();
            }catch(AssetAllocatedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(EmployyeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
