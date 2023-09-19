using AssetManagementAPI.DTO;
using AssetManagementAPI.Exceptions;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class SeatService : ISeatService
    {
        private readonly IRepository<Seat> _context;
        private readonly IRepository<Employee> _employeeContext;

        public SeatService(IRepository<Seat> context, IRepository<Employee> employeeContext)
        {
            _context = context;
            _employeeContext = employeeContext;
        }

        public IQueryable<Seat> GetSeats()
        {
            var item = _context.GetAll();
            if (item.Count() == 0)
            {
                throw new Exception("No records found");
            }
            else
            {
                return item;
            }
        }

        public void AddSeat(SeatDTO dtoItem)
        {
            if(dtoItem.FacilityId == 0)
            {
                throw new Exception("Cannot add seats");
            }
            else
            {
                var seat = new Seat
                {
                    SeatName = dtoItem.SeatName,
                    FacilityId = dtoItem.FacilityId,
                    EmployeeId = null
                };
                _context.Add(seat);
                _context.Save();
            }
        }

        public void AllocateSeat(int seatId, int employeeId)
        {
            if (seatId == 0 || employeeId == 0)
                throw new Exception("Cannot allocate seat");
            else
            {
                var seat = _context.GetById(seatId);
                if(seat == null)
                {
                    throw new Exception("Seat does not exist");
                }
                else
                {
                    if (seat.EmployeeId == null)
                    {
                        var emp = _employeeContext.GetById(employeeId);
                        if (emp != null)
                        {
                            if(emp.IsAllocated == false)
                            {
                                seat.EmployeeId = employeeId;
                                emp.IsAllocated = true;
                                _employeeContext.Save();
                            }
                            else
                            {
                                throw new Exception("Employee already allocated.");
                            }
                        }
                        else throw new EmployyeNotFoundException();
                    }
                    else
                    {
                        throw new AssetAllocatedException();
                    }
                }
                _context.Save();
            }
        }

        public void DeallocateSeat(int seatId)
        {
            if (seatId == 0)
                throw new Exception("Cannot deallocate seat");
            else
            {
                var seat = _context.GetById(seatId);
                if (seat != null)
                {
                    if(seat.EmployeeId == null)
                    {
                        throw new Exception("Seat already not allocated.");
                    }
                    else
                    {
                        var emp = _employeeContext.GetById((int)seat.EmployeeId);
                        emp.IsAllocated = false;
                        seat.EmployeeId = null;
                        _employeeContext.Save();
                    }
                }
                else
                {
                    Console.WriteLine("Seat does not exist");
                }
                _context.Save();
            }
        }
    }
}
