using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AssetManagementAPI.Models
{
    [Index(nameof(City.CityAbbrv), IsUnique = true)]
    public class City
    {
        [Key]
        public int CityId { get; set; }
        
        public string? CityName { get; set; }
        
        public string? CityAbbrv { get; set; }
    }
}
