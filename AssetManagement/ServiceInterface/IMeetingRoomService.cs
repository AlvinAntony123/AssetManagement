using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IMeetingRoomService
    {
        List<MeetingRoom> GetMeetingRooms();

        int AddMeetingRooms(MeetingRoomDTO item);
    }
}
