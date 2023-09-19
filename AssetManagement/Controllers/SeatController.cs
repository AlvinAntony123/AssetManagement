using AssetManagementAPI.DTO;
using AssetManagementAPI.Exceptions;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeatService _context;

        public SeatController(ISeatService context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetSeats());
            }catch(Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult AddItem(SeatDTO seatDTO)
        {
            try
            {
                _context.AddSeat(seatDTO);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("allocate")]
        public IActionResult Allocate(SeatAllocateDTO seat)
        {
            try
            {
                _context.AllocateSeat(seat.SeatId, seat.EmployeeId);
                return Ok();
            }catch(EmployyeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(AssetAllocatedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("deallocate")]
        public IActionResult Deallocate(SeatAllocateDTO seat)
        {
            try
            {
                _context.DeallocateSeat(seat.SeatId);
                return Ok();
            }catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
