using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWhatWhereWhen.Data.Migrations
{
    public partial class SeedEventTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (0, 'Other')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (1, 'Music')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (2, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (3, 'Social')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (4, 'Business')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (5, 'Sport')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (6, 'Religious')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (7, 'Film')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (8, 'Cultural')");
            migrationBuilder.Sql("INSERT INTO EventType (Id, TypeName) VALUES (9, 'Dance')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
