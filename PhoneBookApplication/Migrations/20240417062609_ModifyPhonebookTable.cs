using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBookApplication.Migrations
{
    public partial class ModifyPhonebookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "PhoneBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "PhoneBooks");
        }
    }
}
