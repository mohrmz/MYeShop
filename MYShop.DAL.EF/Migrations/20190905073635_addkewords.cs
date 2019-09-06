using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MYShop.DAL.EF.Migrations
{
    public partial class addkewords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comment_Products_ProductId",
            //    table: "Comment");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Comment",
            //    table: "Comment");

            //migrationBuilder.RenameTable(
            //    name: "Comment",
            //    newName: "Comments");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Comment_ProductId",
            //    table: "Comments",
            //    newName: "IX_Comments_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(MAX)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(MAX)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Keywords",
                table: "Products",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "nvarchar(MAX)",
                nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Clevel",
            //    table: "Categories",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "Date",
            //    table: "Comments",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<string>(
            //    name: "Lastname",
            //    table: "Comments",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Name",
            //    table: "Comments",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Phone",
            //    table: "Comments",
            //    nullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_Comments",
            //    table: "Comments",
            //    column: "CommentId");

            //migrationBuilder.CreateTable(
            //    name: "CategoryPrice",
            //    columns: table => new
            //    {
            //        CategoryPriceID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryPrice", x => x.CategoryPriceID);
            //        table.ForeignKey(
            //            name: "FK_CategoryPrice_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "CategoryID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductColors",
            //    columns: table => new
            //    {
            //        ProductColorID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductID = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Value = table.Column<string>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductColors", x => x.ProductColorID);
            //        table.ForeignKey(
            //            name: "FK_ProductColors_Products_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Products",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Price",
            //    columns: table => new
            //    {
            //        PriceID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductColorID = table.Column<int>(nullable: false),
            //        CategoryPriceID = table.Column<int>(nullable: false),
            //        ProductID = table.Column<int>(nullable: false),
            //        Value = table.Column<int>(nullable: false),
            //        NewValue = table.Column<int>(nullable: false),
            //        Discount = table.Column<int>(nullable: false),
            //        IsDeleted = table.Column<bool>(nullable: false),
            //        DateF = table.Column<string>(nullable: true),
            //        DateT = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Price", x => x.PriceID);
            //        table.ForeignKey(
            //            name: "FK_Price_CategoryPrice_CategoryPriceID",
            //            column: x => x.CategoryPriceID,
            //            principalTable: "CategoryPrice",
            //            principalColumn: "CategoryPriceID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Price_Products_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Products",
            //            principalColumn: "ProductID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryPrice_CategoryId",
            //    table: "CategoryPrice",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Price_CategoryPriceID",
            //    table: "Price",
            //    column: "CategoryPriceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Price_ProductID",
            //    table: "Price",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductColors_ProductID",
            //    table: "ProductColors",
            //    column: "ProductID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comments_Products_ProductId",
            //    table: "Comments",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "ProductID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_Products_ProductId",
            //    table: "Comments");

            //migrationBuilder.DropTable(
            //    name: "Price");

            //migrationBuilder.DropTable(
            //    name: "ProductColors");

            //migrationBuilder.DropTable(
            //    name: "CategoryPrice");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Comments",
            //    table: "Comments");

            //migrationBuilder.DropColumn(
            //    name: "Keywords",
            //    table: "Products");

            //migrationBuilder.DropColumn(
            //    name: "ShortDescription",
            //    table: "Products");

            //migrationBuilder.DropColumn(
            //    name: "Clevel",
            //    table: "Categories");

            //migrationBuilder.DropColumn(
            //    name: "Date",
            //    table: "Comments");

            //migrationBuilder.DropColumn(
            //    name: "Lastname",
            //    table: "Comments");

            //migrationBuilder.DropColumn(
            //    name: "Name",
            //    table: "Comments");

            //migrationBuilder.DropColumn(
            //    name: "Phone",
            //    table: "Comments");

            //migrationBuilder.RenameTable(
            //    name: "Comments",
            //    newName: "Comment");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Comments_ProductId",
            //    table: "Comment",
            //    newName: "IX_Comment_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Products_ProductId",
                table: "Comment",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
