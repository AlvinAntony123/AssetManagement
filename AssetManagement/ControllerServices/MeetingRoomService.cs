using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;

namespace AssetManagementAPI.ControllerServices
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IRepository<MeetingRoom> _context;

        public MeetingRoomService(IRepository<MeetingRoom> context)
        {
            _context = context;
        }
        public int AddMeetingRooms(MeetingRoomDTO dtoItem)
        {
            if (dtoItem.FacilityId == 0)
                throw new Exception("Cannot add meeting room");
            else
            {
                var item = new MeetingRoom
                {
                    MeetingRoomName = dtoItem.MeetingRoomName,
                    FacilityId = dtoItem.FacilityId,
                    TotalSeats = dtoItem.TotalSeats,
                };
                _context.Add(item);
                _context.Save();
                return item.MeetingRoomId;
            }
        }

        public List<MeetingRoom> GetMeetingRooms()
        {
            var item =  _context.GetAll();
            if (item == null)
            {
                throw new Exception("No records found");
            }
            else return item;
        }
    }
}
