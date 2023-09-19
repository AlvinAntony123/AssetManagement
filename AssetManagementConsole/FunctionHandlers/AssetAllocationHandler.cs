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
    public class AssetAllocationHandler
    {
        private readonly IEnitityManager<MeetingRoomAsset> meetingAssetManager;
        private readonly AssetHandler assetHandler;
        public AssetAllocationHandler()
        {
            meetingAssetManager = new EntityManager<MeetingRoomAsset>("api/meetingroomasset");
            assetHandler = new AssetHandler();
        }
        public void AllocateAsset(int roomId)
        {
            while (true)
            {
                assetHandler.GetAssets();
                Console.WriteLine("1.Do you want to add existing asset\n2.Do you want to add new asset");
                Console.Write("Enter your option:");
                var op1 = Convert.ToInt32(Console.ReadLine());
                var assetId = 0;
                if (op1 == 1)
                {
                    Console.WriteLine("Enter the asset id you want to add: ");
                    assetId = Convert.ToInt32(Console.ReadLine());
                }
                else if(op1 == 2)
                {
                    assetId = assetHandler.AddAsset();
                }
                Console.WriteLine("Enter the number of asset to add: ");
                var assetCount = Convert.ToInt32(Console.ReadLine());
                var currAsset = new MeetingRoomAsset
                {
                    MeetingRoomId = roomId,
                    AssetId = assetId,
                    NoOfItems = assetCount
                };
                meetingAssetManager.Add(currAsset);

                Console.Write("Do you want to add more asset to room(0/1):");
                var op = Convert.ToInt32(Console.ReadLine());
                if (op == 0) break;
            }
        }
    }
}
