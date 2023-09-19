using AssetManagementAPI.DTO;
using AssetManagementAPI.Models;
using AssetManagementConsole;
using AssetManagementConsole.FunctionHandlers;
using AssetManagementConsole.Interfaces;
using AssetManagementConsole.Managers;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        FacilityHandler facilityHandler = new FacilityHandler();
        SeatHandler seatHandler = new SeatHandler();
        MeetingRoomHandler meetingRoomHandler = new MeetingRoomHandler();
        CabinHandler cabinHandler = new CabinHandler();
        EmployeeHandler employeeHandler = new EmployeeHandler();
        ReportsHandler reportsHandler = new ReportsHandler();
        Console.WriteLine("----------------------SEAT ALLOCATION MANAGER-------------------------");
        while(true)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1.Onboard Facility\n2.Onboard Seats\n3.Onboard Meeting Rooms\n4.Onboard Cabins\n5.Add Employees\n6.Seat Allocation\n7.Seat Deallocation\n8.Cabin Allocation\n9.Cabin Deallocation\n10.Reports\n11.Exit");
            Console.Write("Choose your option: ");
            int op1 = Convert.ToInt32(Console.ReadLine());
            switch (op1)
            {
                case 1:
                    {
                        facilityHandler.OnboardFacility();
                    }
                    break;

                case 2:
                    {
                        seatHandler.OnboardSeats();
                    }
                    break;

                case 3:
                    {
                        meetingRoomHandler.OnboardMeetingRoom();
                    }
                    break;

                case 4:
                    {
                        cabinHandler.OnboardCabin();
                    }
                    break;

                case 5:
                    {
                        employeeHandler.AddEmployee();
                    }
                    break;

                case 6:
                    {
                        seatHandler.AllocateSeat();
                    }
                    break;

                case 7:
                    {
                        seatHandler.DeallocateSeat();
                    }
                    break;

                case 8:
                    {
                        cabinHandler.AllocateCabin();
                    }
                    break;

                case 9:
                    {
                        cabinHandler.DeallocateCabin();
                    }
                    break;

                case 10:
                    {
                        reportsHandler.GenerateReport();
                    }
                    break;

                case 11:
                    System.Environment.Exit(0);
                    break;

                default: Console.WriteLine("Invalid option");
                    break;
            }
            Console.Clear();
        }
    }

}