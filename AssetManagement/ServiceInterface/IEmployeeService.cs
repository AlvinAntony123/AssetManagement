using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        void AddEmployees(EmployeeDTO employeeDTO);
    }
}
