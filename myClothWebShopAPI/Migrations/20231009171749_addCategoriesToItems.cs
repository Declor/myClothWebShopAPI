using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCategoriesToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description" },
                values: new object[] { "Shoes", "most seller" });

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Shoes");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description" },
                values: new object[] { "T-Shirt", "the hit of the summer" });

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Category",
                value: "T-Shirt");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Category",
                value: "Coats & Jackets");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description" },
                values: new object[] { "Coats & Jackets", "the hit of the season" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "Description" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "Description" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Category",
                value: "");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "Description" },
                values: new object[] { "", "" });
        }
    }
}
