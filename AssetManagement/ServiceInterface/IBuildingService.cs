using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IBuildingService
    {
        IQueryable<Building> GetBuildings();

        int AddBuildings(BuildingDTO item);
    }
}
