using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> _context;

        public FacilityService(IRepository<Facility> context)
        {
            _context = context;
        }
        public void AddFacilities(FacilityDTO facilityDTO) { 
            if(facilityDTO.CityId == 0 || facilityDTO.BuildingId == 0)
            {
                throw new Exception("Cannot add facility");
            }
            else
            {
                var facility = new Facility
                {
                    FaciltyName = facilityDTO.FaciltyName,
                    FaciltyFloor = facilityDTO.FaciltyFloor,
                    CityId = facilityDTO.CityId,
                    BuildingId = facilityDTO.BuildingId,
                };
                _context.Add(facility);
                _context.Save();
            }
        }

        public IQueryable<Facility> GetFacilities()
        {
            var item = _context.GetAll();
            if (item.Count() == 0) throw new Exception("No records found");
            else return _context.GetAll();
        }
    }
}
