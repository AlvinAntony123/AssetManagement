using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class FacilityView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW FacilityView AS
                                SELECT F.FacilityId, C.CityAbbrv, B.BuildingAbbrv, F.FaciltyFloor, F.FaciltyName                      
                                FROM Facilities F                      
                                JOIN Cities C                     
                                ON F.CityId = C.CityId                      
                                JOIN Buildings B                     
                                ON F.BuildingId = B.BuildingId                     
                                JOIN Seats S                     
                                ON F.FacilityId = S.FacilityId;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW FacilityView;");
        }
    }
}
