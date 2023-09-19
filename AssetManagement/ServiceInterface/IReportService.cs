using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IReportService
    {
        List<Overview> GetAllocatedList();

        List<UnallocatedViewModel> GetUnallocatedList();

        List<FacilityViewModel> GetFacilityList();

        List<CabinAllocatedViewModel> GetCabinAllocatedList();

        List<CabinUnallocatedViewModel> GetCabinUnallocatedList();
    }
}
