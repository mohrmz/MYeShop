using Microsoft.EntityFrameworkCore.Migrations;

namespace MYShop.DAL.EF.Migrations
{
    public partial class addshortproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShort",
                table: "Properties",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShort",
                table: "Properties");
        }
    }
}
