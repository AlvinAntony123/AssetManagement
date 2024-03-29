﻿using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface ICabinService
    {
        List<Cabin> GetCabins();

        void AddCabin(CabinDTO cabin);

        void AllocateCabin(int cabinId, int employeeId);

        void DeallocateCabin(int cabinId);
    }
}
