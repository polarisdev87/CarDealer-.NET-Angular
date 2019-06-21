using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Mercedes-Benz')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Porsche')");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('S-Klasse Limousine', (SELECT Id FROM Makes WHERE Name = 'Mercedes-Benz'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('G-Klasse', (SELECT Id FROM Makes WHERE Name = 'Mercedes-Benz'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('AMG GT 63 S 4MATIC+', (SELECT Id FROM Makes WHERE Name = 'Mercedes-Benz'))");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('911 Speedster', (SELECT Id FROM Makes WHERE Name = 'Porsche'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Panamera GTS Sport Turismo',( SELECT Id FROM Makes WHERE Name = 'Porsche'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes");
        }
    }
}
