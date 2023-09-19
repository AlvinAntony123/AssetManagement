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
            _context =  context;
            _employeeContext = employeeContext;
        }
        public void AddCabin(CabinDTO cabin)
        {
            if (cabin.CabinName == "string" || cabin.FacilityId == 0) throw new Exception("Cannot add record");
            else
            {
                var item = new Cabin
                {
                    CabinName = cabin.CabinName,
                    FacilityId = cabin.FacilityId,
                    EmployeeId = null
                };
                _context.Add(item);
                _context.Save();
            }
        }

        public void AllocateCabin(int cabinId, int employeeId)
        {
            if(cabinId == 0 || employeeId == 0)
            {
                throw new Exception("Cannot allocate cabin");
            }
            else
            {
                var currCabin = _context.GetById(cabinId);
                if (currCabin != null)
                {
                    if (currCabin.EmployeeId != null)
                    {
                        throw new AssetAllocatedException();
                    }
                    else
                    {
                        var emp = _employeeContext.GetById(employeeId);
                        if (emp != null)
                        {
                            if (emp.IsAllocated == false)
                            {
                                currCabin.EmployeeId = employeeId;
                                emp.IsAllocated = true;
                                _employeeContext.Save();
                            }
                            else throw new Exception("Employee already allocated");
                        }
                        else
                        {
                            throw new EmployyeNotFoundException();
                        }
                    }
                }
                else throw new Exception("Cabin doe not exist");
                _context.Save();
            }
        }

        public void DeallocateCabin(int cabinId)
        {
            if(cabinId == 0)
            {
                throw new Exception("Cannot deallocate");
            }
            else
            {
                var currCabin = _context.GetById(cabinId);
                if (currCabin != null)
                {
                    if (currCabin.EmployeeId == null)
                        throw new Exception("Cabin already not allocated.");
                    else
                    {
                        var emp = _employeeContext.GetById((int)currCabin.EmployeeId);
                        currCabin.EmployeeId = null;
                        emp.IsAllocated = false;
                        _employeeContext.Save();
                    }
                }
                else
                {
                    throw new Exception("Cabin doesn't exist");
                }
                _context.Save();
            }
        }

        public List<Cabin> GetCabins()
        {
            var item = _context.GetAll();
            if(item.Count == 0)
            {
                throw new Exception("No records found");
            }
            else return item;
        }
    }
}
