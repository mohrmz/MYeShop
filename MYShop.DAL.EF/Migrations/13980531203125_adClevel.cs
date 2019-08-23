using Microsoft.EntityFrameworkCore.Migrations;

namespace MYShop.DAL.EF.Migrations
{
    public partial class adClevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clevel",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clevel",
                table: "Categories");
        }
    }
}
