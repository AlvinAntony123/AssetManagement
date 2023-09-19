using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class cabinAllocated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW CabinAllocated AS
                                SELECT K.CabinId, C.CityAbbrv, B.BuildingAbbrv, F.FaciltyFloor, F.FaciltyName, K.CabinName, E.EmployeeName                      
                                FROM Facilities F                      
                                JOIN Cities C                     
                                ON F.CityId = C.CityId                      
                                JOIN Buildings B                     
                                ON F.BuildingId = B.BuildingId                     
                                JOIN Cabins K                     
                                ON F.FacilityId = K.FacilityId                     
                                JOIN Employees E                     
                                ON K.EmployeeId = E.EmployeeId;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW CabinAllocated;");
        }
    }
}
