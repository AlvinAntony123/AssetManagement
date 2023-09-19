using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IDepartmentService
    {
        IQueryable<Department> GetDepartments();

        void AddDepartment(DepartmentDTO departmentDTO);
    }
}
