using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }

        public string? FaciltyName { get; set; }

        public Int16 FaciltyFloor { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        [ForeignKey("BuildingId")]
        public int BuildingId { get; set; }

        public virtual City? City { get; set; }

        public virtual Building? Building { get; set; }
    }
}
