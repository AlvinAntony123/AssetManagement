using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IMeetingRoomAssetService
    {
        List<MeetingRoomAsset> GetMeetingRoomAssets();

        void AddMeetingRoomAssests(MeetingRoomAssetDTO meetingRoomAsset);

        void UpdateAsset(MeetingRoomAsset meetingRoomAsset);
    }
}
