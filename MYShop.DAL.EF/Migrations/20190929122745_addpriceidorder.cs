using Microsoft.EntityFrameworkCore.Migrations;

namespace MYShop.DAL.EF.Migrations
{
    public partial class addpriceidorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priceid",
                table: "CartLine",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priceid",
                table: "CartLine");
        }
    }
}
