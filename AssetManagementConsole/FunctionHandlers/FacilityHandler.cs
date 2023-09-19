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
    public class FacilityHandler
    {
        private readonly CityHandler cityHandler;
        private readonly BuildingHandler buildingHandler;
        private readonly IEnitityManager<Facility> facilityManager;
        private readonly IReportManager<FacilityViewModel> reportManager;
        public FacilityHandler()
        {
            cityHandler = new CityHandler();
            buildingHandler = new BuildingHandler();
            facilityManager = new EntityManager<Facility>("api/facility");
            reportManager = new ReportManager<FacilityViewModel>("api/report/facilitylist");
        }

        public List<FacilityViewModel> GetFacilityList()
        {
            return reportManager.GenerateReport();
        }

        public void GetFacilities()
        {
            Console.WriteLine("Facility List:");
            var facilityList = GetFacilityList();
            if(facilityList != null)
            {
                foreach (FacilityViewModel facility in facilityList)
                {
                    Console.WriteLine($"{facility.FacilityId}. {facility.CityAbbrv}-{facility.BuildingAbbrv}-{facility.FaciltyFloor}-{facility.FaciltyName}");
                }
            }
        }
        public void OnboardFacility()
        {
            Console.Clear();
            Console.WriteLine("--------------------Onboard Facility------------------");
            cityHandler.GetCities();
            Console.WriteLine("1.Add to existing city\n2.Add to new city");
            Console.Write("Enter your option:");
            int op2 = Convert.ToInt32(Console.ReadLine());
            var cityId = 0;
            var buildingId = 0;
            if (op2 == 1)
            {
                Console.Write("Enter the city id of the city you want: ");
                cityId = Convert.ToInt32(Console.ReadLine());
            }
            else if (op2 == 2)
            {
                
                cityId = cityHandler.AddNewCity();
            }

            buildingHandler.GetBuildings();
            Console.WriteLine("1.Add to existing building\n2.Add to new building");
            Console.Write("Enter your option:");
            var op3 = Convert.ToInt32(Console.ReadLine());
            if (op3 == 1)
            {
                Console.Write("Enter the building id of the building you want: ");
                buildingId = Convert.ToInt32(Console.ReadLine());
            }
            else if (op3 == 2)
            {
                buildingId = buildingHandler.AddNewBuilding();
            }
            Console.Write("Enter the facility name: ");
            var facilityName = Console.ReadLine();
            Console.Write("Enter the facility floor: ");
            var facilityFloor = Convert.ToInt16(Console.ReadLine());

            var facilityObj = new Facility
            {
                FaciltyName = facilityName,
                FaciltyFloor = facilityFloor,
                CityId = cityId,
                BuildingId = buildingId
            };

            var requestNo = facilityManager.Add(facilityObj);

            if(requestNo == -1)
            {
                Console.WriteLine("Error in adding facility");
            }
            else
            {
                Console.WriteLine("Your facility has been added successfully");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
