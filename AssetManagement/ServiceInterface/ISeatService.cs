﻿using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface ISeatService
    {
        IQueryable<Seat> GetSeats();
        void AddSeat(SeatDTO seatDTO);

        void AllocateSeat(int seatId, int employeeId);

        void DeallocateSeat(int seatId);
    }
}
