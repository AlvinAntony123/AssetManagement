﻿using AssetManagementAPI.DTO;
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
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult AddItem(int count, int facilityId, int currCount)
        {
            try
            {
                _context.AddSeat(count, facilityId, currCount);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}/allocations")]
        public IActionResult Allocate(int id, int empId)
        {
            try
            {
                _context.AllocateSeat(id, empId);
                return Ok();
            }
            catch (EmployyeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AssetAllocatedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [Route("{id}/deallocations")]
        public IActionResult Deallocate(int id)
        {
            try
            {
                _context.DeallocateSeat(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
