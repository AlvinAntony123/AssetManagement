﻿using AssetManagementAPI.DTO;
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
    public class CabinHandler
    {
        private readonly IEnitityManager<Cabin> cabinManager;
        private readonly FacilityHandler facilityHandler;
        private readonly IAllocationManager<CabinAllocateDTO> cabinAllocationManager;
        private readonly ReportsHandler reportManager;
        private readonly EmployeeHandler employeeHandler;
        public CabinHandler()
        {
            cabinManager = new EntityManager<Cabin>("api/cabin");
            facilityHandler = new FacilityHandler();
            cabinAllocationManager = new AllocationManager<CabinAllocateDTO>("api/cabin");
            reportManager = new ReportsHandler();
            employeeHandler = new EmployeeHandler();
        }
        public void OnboardCabin()
        {
            Console.Clear();
            Console.WriteLine("--------------------Onboard Cabin------------------");
            facilityHandler.GetFacilities();
            Console.WriteLine("Choose the facility id:");
            var facilityId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of cabins to add:");
            var noOfCabins = Convert.ToInt32(Console.ReadLine());
            var cabinListCount = cabinManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            int cabinCount = cabinListCount + 1;
            int requestNo = cabinManager.AddMany(noOfCabins,facilityId,cabinCount);
            if (requestNo != -1)
            {
                Console.WriteLine("Your cabins has been added successfully");
            }
            else
                Console.WriteLine("Error in adding cabins");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void AllocateCabin()
        {         
            Console.Clear();
            Console.WriteLine("--------------------Allocate Cabin------------------");
            var unallocatedList = reportManager.GetUnallocatedCabinList();
            var employeeList = employeeHandler.GetEmployeeList().Where(x => x.IsAllocated == false).ToList();
            Console.WriteLine("The unallocated seat list: ");
            foreach (var unallo in unallocatedList)
            {
                Console.WriteLine($"{unallo.CabinId}. {unallo.CityAbbrv}-{unallo.BuildingAbbrv}-{unallo.FaciltyFloor}-{unallo.FaciltyName}-{unallo.CabinName}");
            }
            Console.WriteLine("Enter the cabin id you want to allocate: ");
            var cabinId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The unallocated employee list:");
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"{emp.EmployeeId}. {emp.EmployeeName}");
            }
            Console.WriteLine("Enter the employee id to allocate: ");
            var empId = Convert.ToInt32(Console.ReadLine());
            var requestNo = cabinAllocationManager.Allocate(cabinId, empId);
            if(requestNo != -1)
            {
                Console.WriteLine("Cabin allocated successfully successfully");
            }
            else
            {
                Console.WriteLine("Could not allocate the cabin");
            }
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
        }

        public void DeallocateCabin()
        {
            Console.Clear();
            Console.WriteLine("--------------------Deallocate Cabin------------------");
            var allocatedList = reportManager.GetAllocatedCabinList().ToList();
            Console.WriteLine("The allocated cabin list: ");
            foreach (var allo in allocatedList)
            {
                Console.WriteLine($"{allo.CabinId}. {allo.CityAbbrv}-{allo.BuildingAbbrv}-{allo.FaciltyFloor}-{allo.FaciltyName}-{allo.CabinName}-{allo.EmployeeName}");
            }
            Console.WriteLine("Enter the cabin id you want to deallocate: ");
            var cabinId = Convert.ToInt32(Console.ReadLine());

            var requestNo = cabinAllocationManager.Deallocate(cabinId);
            if(requestNo != -1 )
            {
                Console.WriteLine("Cabin deallocated successfully successfully");
            }
            else
            {
                Console.WriteLine("Cabin cannot be deallocated");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
