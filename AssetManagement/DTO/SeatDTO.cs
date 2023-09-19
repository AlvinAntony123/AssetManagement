using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.DTO
{
    public class SeatDTO
    {
        public string SeatName { get; set; }
        public int FacilityId { get; set; }
    }
}
