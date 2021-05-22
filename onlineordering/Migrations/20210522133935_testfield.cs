using Microsoft.EntityFrameworkCore.Migrations;

namespace TGBS.Website.Migrations
{
    public partial class testfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestField",
                table: "Specials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestField",
                table: "Specials");
        }
    }
}
