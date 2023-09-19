using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.DTO
{
    public class FacilityDTO
    {
        public string? FaciltyName { get; set; }

        public Int16 FaciltyFloor { get; set; }
        public int CityId { get; set; }
        public int BuildingId { get; set; }
    }
}
