﻿using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _context;

        public CityService(IRepository<City> context)
        {
            _context = context;
        }
        public int AddCities(CityDTO cityDTO)
        {
            if (cityDTO.CityAbbrv == "string" || cityDTO.CityAbbrv == "string")
                throw new Exception("Cannot add city");
            else
            {
                var city = new City
                {
                    CityName = cityDTO.CityName,
                    CityAbbrv = cityDTO.CityAbbrv,
                };
                _context.Add(city);
                _context.Save();
                return city.CityId;
            }
        }

        public List<City> GetCities()
        {
            var item = _context.GetAll();
            if (item.Count == 0) throw new Exception("No records found");
            else return item;
        }
    }
}
