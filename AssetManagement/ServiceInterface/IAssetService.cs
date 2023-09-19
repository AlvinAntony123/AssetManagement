using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IAssetService
    {
        List<Asset> GetAssets();

        int AddAssets(AssetDTO asset);

    }
}
