using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonService.Migrations
{
    public partial class addPwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Persons",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Persons");
        }
    }
}
