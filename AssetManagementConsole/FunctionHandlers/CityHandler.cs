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
    public class CityHandler
    {
        private readonly IEnitityManager<City> cityManager;
        public CityHandler()
        {
            cityManager = new EntityManager<City>("api/city");
        }

        public int AddNewCity()
        {
            Console.Write("Enter the name of city: ");
            var cityName = Console.ReadLine();
            Console.WriteLine("Enter a city abbreviation: ");
            var cityAbbrv = Console.ReadLine();
            var cityObj = new City
            {
                CityName = cityName,
                CityAbbrv = cityAbbrv
            };
            int id = cityManager.Add(cityObj);

            if(id == -1)
            {
                Console.WriteLine("Could not add city");
                return -1;
            }else
                return id;
        }

        public void GetCities()
        {
            var cityList = cityManager.Get().ToList();
            if(cityList != null)
            {
                foreach (var city in cityList)
                {
                    Console.WriteLine($"{city.CityId}. {city.CityName}");
                }
            }
        }
    }
}
