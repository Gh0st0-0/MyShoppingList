using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingList.Migrations
{
    /// <inheritdoc />
    public partial class ListOwnerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListOwner",
                table: "MyShopingLists");

            migrationBuilder.AddColumn<int>(
                name: "ListOwnerId",
                table: "MyShopingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ListOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOwners", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 1,
                column: "ListOwnerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 2,
                column: "ListOwnerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 3,
                column: "ListOwnerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 4,
                column: "ListOwnerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 5,
                column: "ListOwnerId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MyShopingLists_ListOwnerId",
                table: "MyShopingLists",
                column: "ListOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyShopingLists_ListOwners_ListOwnerId",
                table: "MyShopingLists",
                column: "ListOwnerId",
                principalTable: "ListOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyShopingLists_ListOwners_ListOwnerId",
                table: "MyShopingLists");

            migrationBuilder.DropTable(
                name: "ListOwners");

            migrationBuilder.DropIndex(
                name: "IX_MyShopingLists_ListOwnerId",
                table: "MyShopingLists");

            migrationBuilder.DropColumn(
                name: "ListOwnerId",
                table: "MyShopingLists");

            migrationBuilder.AddColumn<string>(
                name: "ListOwner",
                table: "MyShopingLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 1,
                column: "ListOwner",
                value: "Alice");

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 2,
                column: "ListOwner",
                value: "Bob");

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 3,
                column: "ListOwner",
                value: "Charlie");

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 4,
                column: "ListOwner",
                value: "Alice");

            migrationBuilder.UpdateData(
                table: "MyShopingLists",
                keyColumn: "ID",
                keyValue: 5,
                column: "ListOwner",
                value: "Bob");
        }
    }
}
