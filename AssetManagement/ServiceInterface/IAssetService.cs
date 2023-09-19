using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IAssetService
    {
        IQueryable<Asset> GetAssets();

        int AddAssets(AssetDTO asset);

    }
}
