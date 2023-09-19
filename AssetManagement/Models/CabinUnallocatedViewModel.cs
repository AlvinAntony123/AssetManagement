namespace AssetManagementAPI.Models
{
    public class CabinUnallocatedViewModel
    {
        public int CabinId { get; set; }
        public string CityAbbrv { get; set; }

        public string BuildingAbbrv { get; set; }

        public Int16 FaciltyFloor { get; set; }

        public string FaciltyName { get; set; }

        public string CabinName { get; set; }
    }
}
