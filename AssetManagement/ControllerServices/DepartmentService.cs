using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _context;

        public DepartmentService(IRepository<Department> context)
        {
            _context = context;
        }
        public void AddDepartment(DepartmentDTO departmentDTO)
        {
            if (departmentDTO.DepartmentName == "string")
                throw new Exception("Cannot add department");
            else
            {
                var item = new Department
                {
                    DepartmentName = departmentDTO.DepartmentName,
                };
                _context.Add(item);
                _context.Save();
            }
        }

        public IQueryable<Department> GetDepartments()
        {
            var item = _context.GetAll();
            if(item.Count() == 0)
            {
                throw new Exception("No records found");
            }else
                return item;
        }
    }
}
