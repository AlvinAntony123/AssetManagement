using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Models
{
    public class Cabin
    {
        [Key]
        public int CabinId { get; set; }

        public string CabinName { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }

        public virtual Employee? Employee { get; set; }

        public virtual Facility Facility { get; set; }
    }
}
