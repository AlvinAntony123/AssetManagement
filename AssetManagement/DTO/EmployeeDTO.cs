using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.DTO
{
    public class EmployeeDTO
    {
        public string? EmployeeName { get; set; }
        public int DepartmentId { get; set; }
    }
}
