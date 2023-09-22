using AssetManagementAPI.DTO;
using AssetManagementAPI.Exceptions;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class BuildingService : IBuildingService
    {
        private readonly IRepository<Building> _context;

        public BuildingService(IRepository<Building> context)
        {
            _context = context;
        }
        public int AddBuildings(BuildingDTO item)
        {
            if (item.BuildingName == "string" || item.BuildingAbbrv == "string")
            {
                throw new Exception("Cannot add record");
            }
            var buildings = _context.GetAll();
            foreach (var b in buildings)
            {
                if (b.BuildingAbbrv == item.BuildingAbbrv)
                    throw new SameAbbreviationException();
            }
            var building = new Building
            {
                BuildingName = item.BuildingName,
                BuildingAbbrv = item.BuildingAbbrv,
            };
            _context.Add(building);
            _context.Save();
            return building.BuildingId;
        }


        public IQueryable<Building> GetBuildings()
        {
            var item = _context.GetAll();
            if (item.Count() == 0)
            {
                throw new Exception("No records found");
            }
            else return item;
        }
    }
}
