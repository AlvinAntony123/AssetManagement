using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementAPI.Migrations
{
    public partial class FacilityView1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW FacilityView AS
                                SELECT F.FacilityId, C.CityAbbrv, B.BuildingAbbrv, F.FaciltyFloor, F.FaciltyName                      
                                FROM Facilities F                      
                                JOIN Cities C                     
                                ON F.CityId = C.CityId                      
                                JOIN Buildings B                     
                                ON F.BuildingId = B.BuildingId;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW FacilityView;");
        }
    }
}
