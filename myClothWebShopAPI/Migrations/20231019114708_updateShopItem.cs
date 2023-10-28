using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myClothWebShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateShopItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e627884-a7ad-4749-8dfb-f6d97a97a7c1", "AQAAAAIAAYagAAAAEEZUZqJH6vtNES3Eg+C2N+Alxn8X93VbUCsgyyrJ5thMdVeOeG5pteg3jXvyJZb6ew==", "f02468d9-797c-4650-8a1f-7713842474cb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68fe3f78-5e4b-495d-8e9d-8cbd47947231", "AQAAAAIAAYagAAAAEDDvxiQZKn9RCmVDd4E+IM52jdu/1WRM42P9yqvjpfxUM9vJR+mCmK7II1i1niat7g==", "d2f5ae11-14fd-40b8-a171-4e1bef8b255a" });
        }
    }
}
