using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Models
{
    public class MeetingRoom
    {
        [Key]
        public int MeetingRoomId { get; set; }

        public string MeetingRoomName { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }

        public int TotalSeats { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
