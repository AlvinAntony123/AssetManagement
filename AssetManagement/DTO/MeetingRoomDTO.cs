using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.DTO
{
    public class MeetingRoomDTO
    {
        public string MeetingRoomName { get; set; }
        public int FacilityId { get; set; }

        public int TotalSeats { get; set; }
    }
}
