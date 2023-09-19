using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IMeetingRoomAssetService
    {
        IQueryable<MeetingRoomAsset> GetMeetingRoomAssets();

        void AddMeetingRoomAssests(MeetingRoomAssetDTO meetingRoomAsset);

        void UpdateAsset(MeetingRoomAsset meetingRoomAsset);
    }
}
