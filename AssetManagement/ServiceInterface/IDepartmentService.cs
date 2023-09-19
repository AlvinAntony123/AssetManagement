using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();

        void AddDepartment(DepartmentDTO departmentDTO);
    }
}
