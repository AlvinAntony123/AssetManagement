using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IBuildingService
    {
        List<Building> GetBuildings();

        int AddBuildings(BuildingDTO item);
    }
}
