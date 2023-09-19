using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class unallocatedview2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW Unallocated AS
                                SELECT DISTINCT(S.SeatId), C.CityAbbrv, B.BuildingAbbrv, F.FaciltyFloor, F.FaciltyName, S.SeatName                      
                                FROM Facilities F                      
                                JOIN Cities C                     
                                ON F.CityId = C.CityId                      
                                JOIN Buildings B                     
                                ON F.BuildingId = B.BuildingId                     
                                JOIN Seats S                     
                                ON F.FacilityId = S.FacilityId                     
                                JOIN Employees E                     
                                ON S.EmployeeId IS NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW Unallocated;");
        }
    }
}
