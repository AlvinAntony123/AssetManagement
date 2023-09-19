using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomAssetController : Controller
    {
        private readonly IMeetingRoomAssetService _context;

        public MeetingRoomAssetController(IMeetingRoomAssetService context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_context.GetMeetingRoomAssets());
            }catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult AddItem(MeetingRoomAssetDTO dtoItem)
        {
            try
            {
                _context.AddMeetingRoomAssests(dtoItem);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(MeetingRoomAsset item)
        {
            try
            {
                _context.UpdateAsset(item);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
