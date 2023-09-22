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
            return item;

        }

        public void AddSeat(int count, int facilityId, int currCount)
        {
            if (facilityId == 0)
            {
                throw new Exception("Cannot add seats");
            }
            for (var i = 0; i < count; i++)
            {
                var seatName = "S" + currCount++;
                var seat = new Seat
                {
                    SeatName = seatName,
                    FacilityId = facilityId,
                    EmployeeId = null
                };
                _context.Add(seat);
            }
            _context.Save();

        }

        public void AllocateSeat(int seatId, int employeeId)
        {
            if (seatId == 0 || employeeId == 0)
                throw new Exception("Cannot allocate seat");

            var seat = _context.GetById(seatId);

            if (seat == null)
                throw new Exception("Seat does not exist");

            if (seat.EmployeeId != null)
                throw new AssetAllocatedException();

            var emp = _employeeContext.GetById(employeeId);

            if (emp == null)
                throw new EmployyeNotFoundException();

            if (emp.IsAllocated != false)
                throw new Exception("Employee already allocated.");

            seat.EmployeeId = employeeId;
            emp.IsAllocated = true;
            _employeeContext.Save();

            _context.Save();

        }

        public void DeallocateSeat(int seatId)
        {
            if (seatId == 0)
                throw new Exception("Cannot deallocate seat");
            var seat = _context.GetById(seatId);
            if (seat == null)
                throw new Exception("Seat does not exist");

            if (seat.EmployeeId == null)
                throw new Exception("Seat already not allocated.");

            var emp = _employeeContext.GetById((int)seat.EmployeeId);
            emp.IsAllocated = false;
            seat.EmployeeId = null;
            _employeeContext.Save();


            _context.Save();

        }
    }
}
