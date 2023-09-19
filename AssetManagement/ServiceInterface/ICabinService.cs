using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface ICabinService
    {
        IQueryable<Cabin> GetCabins();

        void AddCabin(int count, int facilityId, int currCount);

        void AllocateCabin(int cabinId, int employeeId);

        void DeallocateCabin(int cabinId);
    }
}
