using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : Controller
    {
        private readonly IMeetingRoomService _context;

        public MeetingRoomController(IMeetingRoomService context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetMeetingRooms());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult AddItem(MeetingRoomDTO dtoItem)
        {
            try
            {
                var id = _context.AddMeetingRooms(dtoItem);
                return Ok(id);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
