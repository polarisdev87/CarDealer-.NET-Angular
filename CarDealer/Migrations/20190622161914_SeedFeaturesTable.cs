using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Migrations
{
    public partial class SeedFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('360 Degree Camera')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Built-in 4G LTE Wi-Fi hotspot')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Apple CarPlay')");
            migrationBuilder.Sql("INSERT INTO Features (Name) VALUES ('Autopilot for Self-Driving')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features");
        }
    }
}
