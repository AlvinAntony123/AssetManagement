using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Models
{
    public class Seat
    {
        [Key]
        public int SeatId { get; set; }

        public string SeatName { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Facility Facility { get; set; }
    }
}
