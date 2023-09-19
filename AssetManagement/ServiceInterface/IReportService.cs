using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IReportService
    {
        IQueryable<Overview> GetAllocatedList();

        IQueryable<UnallocatedViewModel> GetUnallocatedList();

        IQueryable<FacilityViewModel> GetFacilityList();

        IQueryable<CabinAllocatedViewModel> GetCabinAllocatedList();

        IQueryable<CabinUnallocatedViewModel> GetCabinUnallocatedList();
    }
}
