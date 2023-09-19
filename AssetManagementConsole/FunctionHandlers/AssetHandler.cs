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
    public class AssetHandler
    {
        IEnitityManager<Asset> assetManager;
        public AssetHandler()
        {
            assetManager = new EntityManager<Asset>("api/asset");
        }

        public void GetAssets()
        {
            var assetList = assetManager.Get().ToList();
            if(assetList != null)
            {
                Console.WriteLine("Available Assets:");
                foreach (var asset in assetList)
                {
                    Console.WriteLine($"{asset.AssetId}. {asset.AssetName}");
                }
            }
        }

        public int AddAsset()
        {
            Console.Write("Enter the asset name:");
            var assetName = Console.ReadLine();

            var asset = new Asset
            {
                AssetName = assetName,
            };
            var id = assetManager.Add(asset);
            if(id == -1)
            {
                Console.WriteLine("Could not add asset");
                return -1;
            }
            else
            {
                Console.WriteLine("Asset added successfully");
                return id;
            }
        }
    }
}
