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
    public class BuildingHandler
    {
        private readonly IEnitityManager<Building> buildingManager;
        public BuildingHandler()
        {
            buildingManager = new EntityManager<Building>("api/building");
        }

        public int AddNewBuilding()
        {
            Console.Write("Enter the name of building: ");
            var buildingName = Console.ReadLine();
            Console.WriteLine("Enter a building abbreviation: ");
            var buildingAbbrv = Console.ReadLine();
            var buildingObj = new Building
            {
                BuildingName = buildingName,
                BuildingAbbrv = buildingAbbrv
            };

            int id = buildingManager.Add(buildingObj);

            if(id == -1)
            {
                Console.WriteLine("Could not add building");
                return -1;
            }
            else
            {
                return id;
            }
        }

        public void GetBuildings()
        {
            var buildingList = buildingManager.Get().ToList();
            if(buildingList != null)
            {
                foreach (var building in buildingList)
                {
                    Console.WriteLine($"{building.BuildingId}. {building.BuildingName}");
                }
            }
        }
    }
}
