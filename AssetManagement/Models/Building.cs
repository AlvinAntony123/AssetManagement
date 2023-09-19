using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Models
{
    [Index(nameof(Building.BuildingAbbrv), IsUnique = true)]
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }

        public string? BuildingName { get; set; }

        public string? BuildingAbbrv { get; set; }
    }
}
