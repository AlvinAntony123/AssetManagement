using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.DTO
{
    public class CabinDTO
    {
        public string CabinName { get; set; }
        public int FacilityId { get; set; }
    }
}
