using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class addFileContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68fe3f78-5e4b-495d-8e9d-8cbd47947231", "AQAAAAIAAYagAAAAEDDvxiQZKn9RCmVDd4E+IM52jdu/1WRM42P9yqvjpfxUM9vJR+mCmK7II1i1niat7g==", "d2f5ae11-14fd-40b8-a171-4e1bef8b255a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cb12e79-ac5f-4351-accd-aad7fd0b5c0b", "AQAAAAIAAYagAAAAELaNAuLNmonrToRe0ygE1Xum8tYtjJHFk1EWW4VGFrHYPUL470QOa3MG5dHLJSf7Sg==", "8f8b3b36-3557-4a17-a655-f4a70e364fb5" });
        }
    }
}
