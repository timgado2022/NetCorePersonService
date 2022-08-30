using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonService.Migrations
{
    public partial class addcommune : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "commune",
                table: "Persons",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "commune",
                table: "Persons");
        }
    }
}
