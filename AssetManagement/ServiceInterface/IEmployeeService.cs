using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployees();

        void AddEmployees(EmployeeDTO employeeDTO);
    }
}
