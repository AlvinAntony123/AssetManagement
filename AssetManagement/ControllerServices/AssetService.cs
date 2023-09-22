using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using System.Net;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using AssetManagementAPI.Exceptions;

namespace AssetManagementAPI.ControllerServices
{
    public class AssetService : IAssetService
    {
        private readonly IRepository<Asset> _context;

        public AssetService(IRepository<Asset> context)
        {
            _context = context;
        }
        public int AddAssets(AssetDTO asset)
        {
            if (asset.AssetName == "string")
            {
                throw new Exception("Record cannot be added");
            }
            var currAsset = _context.GetAll().Where(x => x.AssetName == asset.AssetName).FirstOrDefault();
            if (currAsset != null)
                throw new ObjectAlreadyExistException();
            var item = new Asset
            {
                AssetName = asset.AssetName
            };
            _context.Add(item);
            _context.Save();
            return item.AssetId;

        }


        public IQueryable<Asset> GetAssets()
        {
            var list = _context.GetAll();
            if (list.Count() == 0)
                throw new Exception("There is no records");
            return list;
        }
    }
}
