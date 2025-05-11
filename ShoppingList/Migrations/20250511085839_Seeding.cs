using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingList.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MyShopingLists",
                columns: new[] { "ID", "ItemName", "ItemPrise", "ItemQuantity", "ListOwner" },
                values: new object[,]
                {
                    { 1, "Apples", 3.9900000000000002, 2.5, "Alice" },
                    { 2, "Bread", 2.4900000000000002, 1.0, "Bob" },
                    { 3, "Milk", 4.25, 1.5, "Charlie" },
                    { 4, "Eggs", 5.9900000000000002, 12.0, "Alice" },
                    { 5, "Chicken", null, 1.2, "Bob" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
