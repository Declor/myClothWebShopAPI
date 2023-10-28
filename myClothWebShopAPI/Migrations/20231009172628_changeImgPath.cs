using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeImgPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Black High Sneakers.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Dunk Low Retro Sneakers.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Faded Logo Tee.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Oversized T-Shirt.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Сropped bomber jacket.jpg");

            migrationBuilder.UpdateData(
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "C:\\Users\\Declor\\source\\repos\\test-api\\test-api\\images\\product\\Leather Varsity Jacket.jpg");
        }
    }
}
