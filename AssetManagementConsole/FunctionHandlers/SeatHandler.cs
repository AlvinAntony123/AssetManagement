using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementConsole.Interfaces;
using AssetManagementConsole.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementConsole.FunctionHandlers
{
    public class SeatHandler
    {
        private readonly IEnitityManager<Seat> seatManager;
        private readonly FacilityHandler facilityHandler;
        private readonly ReportsHandler reportManager;
        private readonly EmployeeHandler employeeHandler;
        private readonly IAllocationManager<SeatAllocateDTO> seatAllocationManager;
        public SeatHandler()
        {
            seatManager = new EntityManager<Seat>("api/seat");
            facilityHandler = new FacilityHandler();
            reportManager = new ReportsHandler();
            employeeHandler = new EmployeeHandler();
            seatAllocationManager = new AllocationManager<SeatAllocateDTO>("api/seat");
        }
        public void OnboardSeats()
        {
            Console.Clear();
            Console.WriteLine("--------------------Onboard Seats------------------");
            facilityHandler.GetFacilities();
            Console.WriteLine("Choose the facility id:");
            var facilityId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of seats to add:");
            var noOfSeats = Convert.ToInt32(Console.ReadLine());
            var seatListCount = seatManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            int seatCount = seatListCount + 1;
            int requestNo = seatManager.AddMany(noOfSeats, facilityId, seatCount);
            if(requestNo == -1)
            {
                Console.WriteLine("Could not add seat");
            }
            else
                Console.WriteLine("Your seats has been added successfully");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void AllocateSeat()
        {
            Console.Clear();
            Console.WriteLine("--------------------Allocate Seats------------------");
            var unallocatedList = reportManager.GetUnallocatedSeatList().ToList();
            var employeeList = employeeHandler.GetEmployeeList().Where(x => x.IsAllocated == false).ToList();
            Console.WriteLine("The unallocated seat list: ");
            foreach (var unallo in unallocatedList)
            {
                Console.WriteLine($"{unallo.SeatId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.SeatName}");
            }
            Console.WriteLine("Enter the seat id you want to allocate: ");
            var seatId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The unallocated employee list:");
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"{emp.EmployeeId}. {emp.EmployeeName}");
            }
            Console.WriteLine("Enter the employee id to allocate: ");
            var empId = Convert.ToInt32(Console.ReadLine());

            var seat = new SeatAllocateDTO
            {
                EmployeeId = empId,
                SeatId = seatId
            };
            var requestNo = seatAllocationManager.Allocate(seat);
            if(requestNo != -1)
            {
                Console.WriteLine("Seat allocated successfully successfully");
            }
            else
            {
                Console.WriteLine("Could not allocate seat");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void DeallocateSeat()
        {
            Console.Clear();
            Console.WriteLine("--------------------Deallocate Seats------------------");
            var allocatedList = reportManager.GetAllocatedSeatList().ToList();
            Console.WriteLine("The allocated seat list: ");
            foreach (var allo in allocatedList)
            {
                Console.WriteLine($"{allo.SeatId}. {allo.CityAbbrv}-{allo.BuildingAbbrv}-{allo.FaciltyFloor}-{allo.FaciltyName}-{allo.SeatName}-{allo.EmployeeName}");
            }
            Console.WriteLine("Enter the seat id you want to deallocate: ");
            var seatId = Convert.ToInt32(Console.ReadLine());

            var seat = new SeatAllocateDTO
            {
                SeatId = seatId,
            };

            var requestNo = seatAllocationManager.Deallocate(seat);
            if(requestNo != -1 )
            {
                Console.WriteLine("Seat deallocated successfully successfully");
            }
            else
            {
                Console.WriteLine("Could not deallocate seat");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
