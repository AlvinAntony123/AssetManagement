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
    public class ReportsHandler
    {
        private readonly IReportManager<UnallocatedViewModel> unallocatedSeatManager;
        private readonly IReportManager<CabinUnallocatedViewModel> unallocatedCabinManager;
        private readonly IReportManager<Overview> alloactedSeatManager;
        private readonly IReportManager<CabinAllocatedViewModel> allocatedCabinManager;
        private readonly FacilityHandler facilityHandler;
        public ReportsHandler()
        {
            unallocatedSeatManager = new ReportManager<UnallocatedViewModel>("api/report/deallocatedlist");
            unallocatedCabinManager = new ReportManager<CabinUnallocatedViewModel>("api/report/cabinunallocated");
            facilityHandler = new FacilityHandler();
            alloactedSeatManager = new ReportManager<Overview>("api/report/allocatedlist");
            allocatedCabinManager = new ReportManager<CabinAllocatedViewModel>("api/report/cabinallocated");
        }

        public List<UnallocatedViewModel> GetUnallocatedSeatList()
        {
            return unallocatedSeatManager.GenerateReport();
        }

        public List<CabinUnallocatedViewModel> GetUnallocatedCabinList()
        {
            return unallocatedCabinManager.GenerateReport();
        }

        public List<Overview> GetAllocatedSeatList()
        {
            return alloactedSeatManager.GenerateReport();
        }

        public List<CabinAllocatedViewModel> GetAllocatedCabinList()
        {
            return allocatedCabinManager.GenerateReport();
        }
        public void GenerateReport()
        {
            Console.Clear();
            Console.WriteLine("--------------------Report Generation------------------");
            var unalloSeatList = GetUnallocatedSeatList();
            var unalloCabinList = GetUnallocatedCabinList();
            Console.WriteLine("How do you want to filter?:");
            Console.WriteLine("1.By name of location\n2.By Seats\n3.By Cabins\n4.By Floor");
            Console.Write("Enter your option:");
            var op = Convert.ToInt32(Console.ReadLine());
            if (op == 1)
            {
                facilityHandler.GetFacilities();
                Console.WriteLine("Enter the location name by which you want to search: ");
                var facilityName = Console.ReadLine();
                var filteredSeatList = unalloSeatList.Where(x => x.FaciltyName.Equals(facilityName)).ToList();
                var filteredCabinList = unalloCabinList.Where(x => x.FaciltyName.Equals(facilityName)).ToList();

                Console.WriteLine("Unallocated seat report:");
                foreach (var unallo in filteredSeatList)
                {
                    Console.WriteLine($"{unallo.SeatId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.SeatName}");
                }

                Console.WriteLine("Unallocated cabin report:");
                foreach (var unallo in filteredCabinList)
                {
                    Console.WriteLine($"{unallo.CabinId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.CabinName}");
                }
            }

            else if (op == 2)
            {
                Console.WriteLine("Unallocated seat report:");
                foreach (var unallo in unalloSeatList)
                {
                    Console.WriteLine($"{unallo.SeatId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.SeatName}");
                }
            }

            else if (op == 3)
            {
                Console.WriteLine("Unallocated cabin report:");
                foreach (var unallo in unalloCabinList)
                {
                    Console.WriteLine($"{unallo.CabinId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.CabinName}");
                }
            }

            else if (op == 4)
            {
                Console.Write("Enter the floor number by which you want to search: ");
                var floorNo = Convert.ToInt16(Console.ReadLine());
                var facilityOnFloorList = facilityHandler.GetFacilityList().Where(x => x.FaciltyFloor ==  floorNo).ToList();

                Console.WriteLine("Facilities On Floor List:");
                foreach (FacilityViewModel facility in facilityOnFloorList)
                {
                    Console.WriteLine($"{facility.FacilityId}. {facility.CityAbbrv}-{facility.BuildingAbbrv}-{facility.FaciltyFloor}-{facility.FaciltyName}");
                }
                Console.Write("Enter the facility id you want to search:");
                var facilityId = Convert.ToInt32(Console.ReadLine());
                var facilityName = facilityOnFloorList.FirstOrDefault(x => x.FacilityId == facilityId).FaciltyName;

                var filteredSeatList = unalloSeatList.Where(x => x.FaciltyFloor == floorNo && x.FaciltyName.Equals(facilityName) ).ToList();
                var filteredCabinList = unalloCabinList.Where(x => x.FaciltyFloor == floorNo && x.FaciltyName.Equals(facilityName)).ToList();

                Console.WriteLine("Unallocated seat report:");
                foreach (var unallo in filteredSeatList)
                {
                    Console.WriteLine($"{unallo.SeatId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.SeatName}");
                }

                Console.WriteLine("Unallocated cabin report:");
                foreach (var unallo in filteredCabinList)
                {
                    Console.WriteLine($"{unallo.CabinId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.CabinName}");
                }
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
