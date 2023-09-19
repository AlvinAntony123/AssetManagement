using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface ICityService
    {
        IQueryable<City> GetCities();

        int AddCities(CityDTO city);
    }
}
