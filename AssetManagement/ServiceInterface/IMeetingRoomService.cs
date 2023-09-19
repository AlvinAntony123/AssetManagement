using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;

namespace AssetManagementAPI.ServiceInterface
{
    public interface IMeetingRoomService
    {
        IQueryable<MeetingRoom> GetMeetingRooms();

        int AddMeetingRooms(MeetingRoomDTO item);
    }
}
