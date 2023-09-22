using AssetManagementAPI.DTO;
using AssetManagementAPI.Exceptions;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class CabinService : ICabinService
    {
        private readonly IRepository<Cabin> _context;
        private readonly IRepository<Employee> _employeeContext;

        public CabinService(IRepository<Cabin> context, IRepository<Employee> employeeContext)
        {
            _context = context;
            _employeeContext = employeeContext;
        }
        public void AddCabin(int count, int facilityId, int currCount)
        {
            if (facilityId == 0) throw new Exception("Cannot add record");
            for (var i = 0; i < count; i++)
            {
                var cabinName = "C" + currCount++;
                var item = new Cabin
                {
                    CabinName = cabinName,
                    FacilityId = facilityId,
                    EmployeeId = null
                };
                _context.Add(item);
            }
            _context.Save();
        }

        public void AllocateCabin(int cabinId, int employeeId)
        {
            if (cabinId == 0 || employeeId == 0)
            {
                throw new Exception("Cannot allocate cabin");
            }
            var currCabin = _context.GetById(cabinId);
            if (currCabin == null)
                throw new Exception("Cabin does not exist");

            if (currCabin.EmployeeId != null)
            {
                throw new AssetAllocatedException();
            }
            var emp = _employeeContext.GetById(employeeId);
            if (emp == null)
            {
                throw new EmployyeNotFoundException();
            }
            if (emp.IsAllocated == false)
            {
                currCabin.EmployeeId = employeeId;
                emp.IsAllocated = true;
                _employeeContext.Save();
            }
            else throw new Exception("Employee already allocated");

            _context.Save();

        }

        public void DeallocateCabin(int cabinId)
        {
            if (cabinId == 0)
            {
                throw new Exception("Cannot deallocate");
            }
            var currCabin = _context.GetById(cabinId);
            if (currCabin == null)
                throw new Exception("Cabin doesn't exist");
            if (currCabin.EmployeeId == null)
                throw new Exception("Cabin already not allocated.");
            var emp = _employeeContext.GetById((int)currCabin.EmployeeId);
            currCabin.EmployeeId = null;
            emp.IsAllocated = false;
            _employeeContext.Save();

            _context.Save();

        }

        public IQueryable<Cabin> GetCabins()
        {
            var item = _context.GetAll();
            if (item.Count() == 0)
            {
                throw new Exception("No records found");
            }
            else return item;
        }
    }
}
