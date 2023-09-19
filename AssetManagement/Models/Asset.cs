using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }

        public string? AssetName { get; set; }
    }
}
