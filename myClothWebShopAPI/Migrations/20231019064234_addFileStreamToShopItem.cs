using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class addFileStreamToShopItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cb12e79-ac5f-4351-accd-aad7fd0b5c0b", "AQAAAAIAAYagAAAAELaNAuLNmonrToRe0ygE1Xum8tYtjJHFk1EWW4VGFrHYPUL470QOa3MG5dHLJSf7Sg==", "8f8b3b36-3557-4a17-a655-f4a70e364fb5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dac233fe-fa5e-4d55-9e48-fe1f8bbe22ad", "AQAAAAIAAYagAAAAEEM/u2JzN+dl3c9fnPfXY99WlL1AeCBhUrensjgBw6h69AB2Wk9nDYA6Cq/KZ7qaew==", "e358c527-2ea5-4269-af07-9c6e91dc515e" });
        }
    }
}
