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
    public class MeetingRoomHandler
    {
        private readonly IEnitityManager<MeetingRoom> meetingroomManager;
        private readonly FacilityHandler facilityHandler;
        private readonly AssetAllocationHandler assetAllocationHandler;
        public MeetingRoomHandler()
        {
            meetingroomManager = new EntityManager<MeetingRoom>("api/meetingroom");
            facilityHandler = new FacilityHandler();
            assetAllocationHandler = new AssetAllocationHandler();
        }
        public void OnboardMeetingRoom()
        {
            Console.Clear();
            Console.WriteLine("--------------------Onboard Meeting Room------------------");
            facilityHandler.GetFacilities();
            Console.WriteLine("Choose the facility id:");
            var facilityId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of meeting rooms to add:");
            var noOfRooms = Convert.ToInt32(Console.ReadLine());
            var meetingroomList = meetingroomManager.Get().Where(x => x.FacilityId == facilityId).ToList().Count;
            int roomCount = meetingroomList + 1;
            int roomId = 0;
            for (int i = 0; i < noOfRooms; i++)
            {
                var roomName = "M" + roomCount++;
                Console.Write("Enter the no. of seats for meeting room:");
                var seatNo = Convert.ToInt32(Console.ReadLine());

                var meetingRoom = new MeetingRoom
                {
                    FacilityId = facilityId,
                    MeetingRoomName = roomName,
                    TotalSeats = seatNo
                };

                roomId = meetingroomManager.Add(meetingRoom);
                if(roomId == -1)
                {
                    Console.WriteLine("Error in adding meeting room");
                    break;
                }else
                    assetAllocationHandler.AllocateAsset(roomId);
            }
            if(roomId != -1)
            {
                Console.WriteLine("Your meeting rooms has been added successfully");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
