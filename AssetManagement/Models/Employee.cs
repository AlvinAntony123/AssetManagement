using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public bool IsAllocated { get; set; }

        public virtual Department? Department { get; set; }
    }
}
