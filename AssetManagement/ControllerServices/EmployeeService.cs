using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _context;

        public EmployeeService(IRepository<Employee> context)
        {
            _context = context;
        }
        public void AddEmployees(EmployeeDTO employeeDTO)
        {
            if(employeeDTO.EmployeeName == "string" || employeeDTO.DepartmentId == 0)
            {
                throw new Exception("Cannot add employee");
            }
            else
            {
                var item = new Employee
                {
                    EmployeeName = employeeDTO.EmployeeName,
                    DepartmentId = employeeDTO.DepartmentId,
                    IsAllocated = false
                };
                _context.Add(item);
                _context.Save();
            }
        }

        public IQueryable<Employee> GetEmployees()
        {
            var item = _context.GetAll();
            if(item.Count() == 0)
            {
                throw new Exception("No records found");
            }
            else { return item; }
        }
    }
}
