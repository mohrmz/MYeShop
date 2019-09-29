using Microsoft.EntityFrameworkCore.Migrations;

namespace MYShop.DAL.EF.Migrations
{
    public partial class addcategorypriceproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryPriceID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductColorID",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryPriceID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductColorID",
                table: "Products");
        }
    }
}
