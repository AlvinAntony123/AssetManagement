using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW Overview AS
                                SELECT C.CityAbbrv, B.BuildingAbbrv, F.FaciltyFloor, F.FaciltyName, S.SeatName, E.EmployeeName                      
                                FROM Facilities F                      
                                JOIN Cities C                     
                                ON F.CityId = C.CityId                      
                                JOIN Buildings B                     
                                ON F.BuildingId = B.BuildingId                     
                                JOIN Seats S                     
                                ON F.FacilityId = S.FacilityId                     
                                JOIN Employees E                     
                                ON S.EmployeeId = E.EmployeeId;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW Overview;");
        }
    }
}
