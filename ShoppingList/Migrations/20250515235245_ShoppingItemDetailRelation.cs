using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingList.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingItemDetailRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shopingItemDetailsId",
                table: "MyShopingLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingItemDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    itemMRP = table.Column<double>(type: "float", nullable: true),
                    ShopingListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItemDetail", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 1,
                column: "shopingItemDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 2,
                column: "shopingItemDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 3,
                column: "shopingItemDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 4,
                column: "shopingItemDetailsId",
                value: null);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 5,
                column: "shopingItemDetailsId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_MyShopingLists_shopingItemDetailsId",
                table: "MyShopingLists",
                column: "shopingItemDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyShopingLists_ShoppingItemDetail_shopingItemDetailsId",
                table: "MyShopingLists",
                column: "shopingItemDetailsId",
                principalTable: "ShoppingItemDetail",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyShopingLists_ShoppingItemDetail_shopingItemDetailsId",
                table: "MyShopingLists");

            migrationBuilder.DropTable(
                name: "ShoppingItemDetail");

            migrationBuilder.DropIndex(
                name: "IX_MyShopingLists_shopingItemDetailsId",
                table: "MyShopingLists");

            migrationBuilder.DropColumn(
                name: "shopingItemDetailsId",
                table: "MyShopingLists");
        }
    }
}
