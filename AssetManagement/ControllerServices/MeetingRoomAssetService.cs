using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class MeetingRoomAssetService : IMeetingRoomAssetService
    {
        private readonly IRepository<MeetingRoomAsset> _context;

        public MeetingRoomAssetService(IRepository<MeetingRoomAsset> context)
        {
            _context = context;
        }
        public void AddMeetingRoomAssests(MeetingRoomAssetDTO dtoItem)
        {
            if(dtoItem.MeetingRoomId == 0 || dtoItem.AssetId == 0)
            {
                throw new Exception("Cannot add asset to meeting room");
            }
            else
            {
                var item = new MeetingRoomAsset
                {
                    MeetingRoomId = dtoItem.MeetingRoomId,
                    AssetId = dtoItem.AssetId,
                    NoOfItems = dtoItem.NoOfItems,

                };
                _context.Add(item);
                _context.Save();
            }
        }

        public List<MeetingRoomAsset> GetMeetingRoomAssets()
        {
            var item = _context.GetAll();
            if (item == null) { throw new Exception("No records found"); }
            else return item;
        }

        public void UpdateAsset(MeetingRoomAsset item)
        {
            if(item.MeetingRoomAssetId == 0)
                throw new Exception("Cannot update asset number");
            else
            {
                var currMeetingAsset = _context.GetById(item.MeetingRoomAssetId);
                if (currMeetingAsset != null)
                {
                    currMeetingAsset.NoOfItems = item.NoOfItems;
                }
                _context.Save();
            }
        }
    }
}
