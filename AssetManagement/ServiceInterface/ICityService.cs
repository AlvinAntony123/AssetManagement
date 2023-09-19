using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface ICityService
    {
        List<City> GetCities();

        int AddCities(CityDTO city);
    }
}
