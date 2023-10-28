using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeImgPaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItems\\Black High Sneakers.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItems\\Dunk Low Retro Sneakers.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItems\\Faded Logo Tee.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItems\\Oversized T-Shirt.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItems\\Сropped bomber jacket.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItems\\Leather Varsity Jacket.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItem\\Black High Sneakers.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItem\\Dunk Low Retro Sneakers.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItem\\Faded Logo Tee.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItem\\Oversized T-Shirt.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItem\\Сropped bomber jacket.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\shopItem\\Leather Varsity Jacket.jpg");
        }
    }
}
