using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Overview> _Allocatedcontext;
        private readonly IRepository<UnallocatedViewModel> _unallocated;
        private readonly IRepository<FacilityViewModel> _facilityContext;
        private readonly IRepository<CabinAllocatedViewModel> _cabinAllocated;
        private readonly IRepository<CabinUnallocatedViewModel> _cabinUnallocated;

        public ReportService(IRepository<Overview> Allocatedcontext, IRepository<UnallocatedViewModel> Unallocatedcontext, IRepository<FacilityViewModel> facilityContext, IRepository<CabinAllocatedViewModel> cabinAllocatedContext, IRepository<CabinUnallocatedViewModel> cabinUnallocatedContext)
        {
            _Allocatedcontext = Allocatedcontext;
            _unallocated = Unallocatedcontext;
            _facilityContext = facilityContext;
            _cabinAllocated = cabinAllocatedContext;
            _cabinUnallocated = cabinUnallocatedContext;
        }

        public List<Overview> GetAllocatedList()
        {
            var item = _Allocatedcontext.GetAll();
            if (item.Count == 0)
            {
                throw new Exception("Cannot generate report");
            }
            else return item;
        }

        public List<FacilityViewModel> GetFacilityList()
        {
            var item = _facilityContext.GetAll();
            if (item.Count == 0)
            {
                throw new Exception("Cannot generate report");
            }
            else return item;
        }

        public List<UnallocatedViewModel> GetUnallocatedList()
        {
            var item = _unallocated.GetAll();
            if (item.Count == 0)
            {
                throw new Exception("Cannot generate report");
            }
            else return item;
        }

        public List<CabinAllocatedViewModel> GetCabinAllocatedList()
        {
            var item = _cabinAllocated.GetAll();
            if (item.Count == 0)
            {
                throw new Exception("Cannot generate report");
            }
            else return item;
        }

        public List<CabinUnallocatedViewModel> GetCabinUnallocatedList()
        {
            var item = _cabinUnallocated.GetAll();
            if (item.Count == 0)
            {
                throw new Exception("Cannot generate report");
            }
            else return item;
        }
    }
}
