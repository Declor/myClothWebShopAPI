using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class addItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShopItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "", "", "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Black High Sneakers", "Black High Sneakers", 80.989999999999995 },
                    { 2, "", "", "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Dunk Low Retro Sneakers", "Dunk Low Retro Sneakers", 101.5 },
                    { 3, "", "", "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Faded Logo Tee", "Faded Logo Tee", 30.5 },
                    { 4, "", "", "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Oversized T-Shirt", "Oversized T-Shirt", 23.800000000000001 },
                    { 5, "", "", "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Сropped bomber jacket", "Сropped bomber jacket", 71.989999999999995 },
                    { 6, "", "", "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Leather Varsity Jacket", "Leather Varsity Jacket", 65.75 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
