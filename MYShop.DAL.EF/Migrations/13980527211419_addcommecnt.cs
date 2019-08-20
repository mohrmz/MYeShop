using Microsoft.EntityFrameworkCore.Migrations;

namespace MYShop.DAL.EF.Migrations
{
    public partial class addcommecnt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Comment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Comment");
        }
    }
}
