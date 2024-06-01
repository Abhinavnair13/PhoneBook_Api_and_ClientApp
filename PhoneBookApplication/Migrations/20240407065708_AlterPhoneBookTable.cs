using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookApplication.Migrations
{
    public partial class AlterPhoneBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "PhoneBooks",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "PhoneBooks");
        }
    }
}
