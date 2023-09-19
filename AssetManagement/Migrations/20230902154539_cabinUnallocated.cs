using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class cabinUnallocated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW CabinUnallocated AS
                                SELECT DISTINCT(K.CabinId), C.CityAbbrv, B.BuildingAbbrv, F.FaciltyFloor, F.FaciltyName, K.CabinName                      
                                FROM Facilities F                      
                                JOIN Cities C                     
                                ON F.CityId = C.CityId                      
                                JOIN Buildings B                     
                                ON F.BuildingId = B.BuildingId                     
                                JOIN Cabins K                     
                                ON F.FacilityId = K.FacilityId                     
                                JOIN Employees E                     
                                ON K.EmployeeId IS NULL;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW CabinUnallocated;");
        }
    }
}
