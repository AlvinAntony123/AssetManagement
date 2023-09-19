using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AssetManagementAPI.Models
{
    public class Overview
    {
        public int SeatId { get; set; }
        public string CityAbbrv { get; set; }

        public string BuildingAbbrv { get; set; }

        public Int16 FaciltyFloor { get; set; }

        public string FaciltyName { get; set; }

        public string SeatName { get; set; }

        public string EmployeeName { get; set; }
    }
}
