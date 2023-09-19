using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IReportService _context;

        public ReportController(IReportService context)
        {
            _context = context;
        }

        [HttpGet("allocatedlist")]

        public IActionResult GetAllocated()
        {
            try
            {
                return Ok(_context.GetAllocatedList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpGet("deallocatedlist")]

        public IActionResult GetDealloactedList()
        {
            try
            {
                return Ok(_context.GetUnallocatedList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpGet("facilitylist")]

        public IActionResult GetFacilityList()
        {
            try
            {
                return Ok(_context.GetFacilityList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpGet("cabinallocated")]

        public IActionResult GetCabinAllocated()
        {
            try
            {
                return Ok(_context.GetCabinAllocatedList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpGet("cabinunallocated")]

        public IActionResult GetCabinUnallocated()
        {
            try
            {
                return Ok(_context.GetCabinUnallocatedList());
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
    }
}
