using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IFacilityService
    {
        List<Facility> GetFacilities();

        void AddFacilities(FacilityDTO facility);
    }
}
