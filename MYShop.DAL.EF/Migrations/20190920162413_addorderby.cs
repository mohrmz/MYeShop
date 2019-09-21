using Microsoft.EntityFrameworkCore.Migrations;

namespace MYShop.DAL.EF.Migrations
{
    public partial class addorderby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderby",
                table: "Properties",
                nullable: false,
                defaultValue: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderby",
                table: "Properties");
        }
    }
}
