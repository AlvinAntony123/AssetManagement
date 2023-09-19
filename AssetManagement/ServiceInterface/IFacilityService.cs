using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IFacilityService
    {
        IQueryable<Facility> GetFacilities();

        void AddFacilities(FacilityDTO facility);
    }
}
